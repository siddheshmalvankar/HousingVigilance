using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace Infra.HousingVigilance.Helpers
{
    public enum PasswordHasherCompatibilityMode
    {
        /// <summary>
        /// Indicates hashing passwords in a way that is compatible with ASP.NET Identity versions 1 and 2.
        /// </summary>
        IdentityV2,

        /// <summary>
        /// Indicates hashing passwords in a way that is compatible with ASP.NET Identity version 3.
        /// </summary>
        IdentityV3
    }

    /// <summary>
    /// Specifies the PRF which should be used for the key derivation algorithm.
    /// </summary>
    public enum KeyDerivationPrf
    {
        /// <summary>
        /// The HMAC algorithm (RFC 2104) using the SHA-1 hash function (FIPS 180-4).
        /// </summary>
        HMACSHA1,

        /// <summary>
        /// The HMAC algorithm (RFC 2104) using the SHA-256 hash function (FIPS 180-4).
        /// </summary>
        HMACSHA256,

        /// <summary>
        /// The HMAC algorithm (RFC 2104) using the SHA-512 hash function (FIPS 180-4).
        /// </summary>
        HMACSHA512,
    }

    /// <summary>
    /// Provides algorithms for performing key derivation.
    /// </summary>
    public static class KeyDerivation
    {
        /// <summary>
        /// Performs key derivation using the PBKDF2 algorithm.
        /// </summary>
        /// <param name="password">The password from which to derive the key.</param>
        /// <param name="salt">The salt to be used during the key derivation process.</param>
        /// <param name="prf">The pseudo-random function to be used in the key derivation process.</param>
        /// <param name="iterationCount">The number of iterations of the pseudo-random function to apply
        /// during the key derivation process.</param>
        /// <param name="numBytesRequested">The desired length (in bytes) of the derived key.</param>
        /// <returns>The derived key.</returns>
        /// <remarks>
        /// The PBKDF2 algorithm is specified in RFC 2898.
        /// </remarks>
        public static byte[] Pbkdf2(string password, byte[] salt, KeyDerivationPrf prf, int iterationCount, int numBytesRequested)
        {
            // parameter checking
            if (prf < KeyDerivationPrf.HMACSHA1 || prf > KeyDerivationPrf.HMACSHA512)
            {
                throw new ArgumentOutOfRangeException("prf");
            }
            if (iterationCount <= 0)
            {
                throw new ArgumentOutOfRangeException("iterationCount");
            }
            if (numBytesRequested <= 0)
            {
                throw new ArgumentOutOfRangeException("numBytesRequested");
            }

            return Pbkdf2Util.Pbkdf2Provider.DeriveKey(password, salt, prf, iterationCount, numBytesRequested);
        }
    }

    /// <summary>
    /// Internal base class used for abstracting away the PBKDF2 implementation since the implementation is OS-specific.
    /// </summary>
    internal static class Pbkdf2Util
    {
        public static readonly IPbkdf2Provider Pbkdf2Provider = GetPbkdf2Provider();

        private static IPbkdf2Provider GetPbkdf2Provider()
        {

            // slowest implementation (refer original source - there are OS specific implementations)
            return new ManagedPbkdf2Provider();
        }
    }

    /// <summary>
    /// Internal interface used for abstracting away the PBKDF2 implementation since the implementation is OS-specific.
    /// </summary>
    internal interface IPbkdf2Provider
    {
        byte[] DeriveKey(string password, byte[] salt, KeyDerivationPrf prf, int iterationCount, int numBytesRequested);
    }

    /// <summary>
    /// A PBKDF2 provider which utilizes the managed hash algorithm classes as PRFs.
    /// This isn't the preferred provider since the implementation is slow, but it is provided as a fallback.
    /// </summary>
    internal sealed class ManagedPbkdf2Provider : IPbkdf2Provider
    {
        public byte[] DeriveKey(string password, byte[] salt, KeyDerivationPrf prf, int iterationCount, int numBytesRequested)
        {
            // PBKDF2 is defined in NIST SP800-132, Sec. 5.3.
            // http://csrc.nist.gov/publications/nistpubs/800-132/nist-sp800-132.pdf

            byte[] retVal = new byte[numBytesRequested];
            int numBytesWritten = 0;
            int numBytesRemaining = numBytesRequested;

            // For each block index, U_0 := Salt || block_index
            byte[] saltWithBlockIndex = new byte[checked(salt.Length + sizeof(uint))];
            Buffer.BlockCopy(salt, 0, saltWithBlockIndex, 0, salt.Length);

            using (var hashAlgorithm = PrfToManagedHmacAlgorithm(prf, password))
            {
                for (uint blockIndex = 1; numBytesRemaining > 0; blockIndex++)
                {
                    // write the block index out as big-endian
                    saltWithBlockIndex[saltWithBlockIndex.Length - 4] = (byte)(blockIndex >> 24);
                    saltWithBlockIndex[saltWithBlockIndex.Length - 3] = (byte)(blockIndex >> 16);
                    saltWithBlockIndex[saltWithBlockIndex.Length - 2] = (byte)(blockIndex >> 8);
                    saltWithBlockIndex[saltWithBlockIndex.Length - 1] = (byte)blockIndex;

                    // U_1 = PRF(U_0) = PRF(Salt || block_index)
                    // T_blockIndex = U_1
                    byte[] U_iter = hashAlgorithm.ComputeHash(saltWithBlockIndex); // this is U_1
                    byte[] T_blockIndex = U_iter;

                    for (int iter = 1; iter < iterationCount; iter++)
                    {
                        U_iter = hashAlgorithm.ComputeHash(U_iter);
                        XorBuffers(src: U_iter, dest: T_blockIndex);
                        // At this point, the 'U_iter' variable actually contains U_{iter+1} (due to indexing differences).
                    }

                    // At this point, we're done iterating on this block, so copy the transformed block into retVal.
                    int numBytesToCopy = Math.Min(numBytesRemaining, T_blockIndex.Length);
                    Buffer.BlockCopy(T_blockIndex, 0, retVal, numBytesWritten, numBytesToCopy);
                    numBytesWritten += numBytesToCopy;
                    numBytesRemaining -= numBytesToCopy;
                }
            }

            // retVal := T_1 || T_2 || ... || T_n, where T_n may be truncated to meet the desired output length
            return retVal;
        }

        private static KeyedHashAlgorithm PrfToManagedHmacAlgorithm(KeyDerivationPrf prf, string password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            try
            {
                switch (prf)
                {
                    case KeyDerivationPrf.HMACSHA1:
                        return new HMACSHA1(passwordBytes);
                    case KeyDerivationPrf.HMACSHA256:
                        return new HMACSHA256(passwordBytes);
                    case KeyDerivationPrf.HMACSHA512:
                        return new HMACSHA512(passwordBytes);
                    default:
                        throw new ApplicationException("Failed to encrypt password - Unrecognized PRF.");
                }
            }
            finally
            {
                // The HMAC ctor makes a duplicate of this key; we clear original buffer to limit exposure to the GC.
                Array.Clear(passwordBytes, 0, passwordBytes.Length);
            }
        }

        private static void XorBuffers(byte[] src, byte[] dest)
        {
            // Note: dest buffer is mutated.
            for (int i = 0; i < src.Length; i++)
            {
                dest[i] ^= src[i];
            }
        }
    }

    //
    // Summary:
    //     Return result for IPasswordHasher
    public enum PasswordVerificationResult
    {
        //
        // Summary:
        //     Password verification failed
        Failed = 0,
        //
        // Summary:
        //     Success
        Success = 1,
        //
        // Summary:
        //     Success but should update and rehash the password
        SuccessRehashNeeded = 2
    }

    /// <summary>
    /// Implements the standard Identity password hashing.
    /// </summary>
    /// <typeparam name="TUser">The type used to represent a user.</typeparam>
    public class PasswordHasher
    {
        /* =======================
        * HASHED PASSWORD FORMATS
        * =======================
        *        
        *
        * Version 3:
        * PBKDF2 with HMAC-SHA256, 128-bit salt, 256-bit subkey, 10000 iterations.
        * Format: { 0x01, prf (UInt32), iter count (UInt32), salt length (UInt32), salt, subkey }
        * (All UInt32s are stored big-endian.)
        */

        private readonly PasswordHasherCompatibilityMode _compatibilityMode;
        private readonly int _iterCount;
        private static readonly RandomNumberGenerator _rng = RandomNumberGenerator.Create();

        /// <summary>
        /// Creates a new instance of <see cref="PasswordHasher{TUser}"/>.
        /// </summary>
        /// <param name="options">The options for this instance.</param>
        public PasswordHasher()
        {
            _compatibilityMode = PasswordHasherCompatibilityMode.IdentityV3;
            _iterCount = 10000;
        }

        public virtual string HashPassword(string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            return Convert.ToBase64String( HashPasswordV3(password, _rng));
        }

        /// <summary>
        /// Returns a <see cref="PasswordVerificationResult"/> indicating the result of a password hash comparison.
        /// </summary>
        /// <param name="user">The user whose password should be verified.</param>
        /// <param name="hashedPassword">The hash value for a user's stored password.</param>
        /// <param name="providedPassword">The password supplied for comparison.</param>
        /// <returns>A <see cref="PasswordVerificationResult"/> indicating the result of a password hash comparison.</returns>
        /// <remarks>Implementations of this method should be time consistent.</remarks>
        public virtual PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            if (hashedPassword == null)
            {
                throw new ArgumentNullException("hashedPassword");
            }
            if (providedPassword == null)
            {
                throw new ArgumentNullException("providedPassword");
            }

            byte[] decodedHashedPassword = Convert.FromBase64String(hashedPassword);

            // read the format marker from the hashed password
            if (decodedHashedPassword.Length == 0)
            {
                return PasswordVerificationResult.Failed;
            }

            int embeddedIterCount;
            if (VerifyHashedPasswordV3(decodedHashedPassword, providedPassword, out embeddedIterCount))
            {
                // If this hasher was configured with a higher iteration count, change the entry now.
                return (embeddedIterCount < _iterCount)
                    ? PasswordVerificationResult.SuccessRehashNeeded
                    : PasswordVerificationResult.Success;
            }
            else
            {
                return PasswordVerificationResult.Failed;
            }
        }

        

        // Compares two byte arrays for equality. The method is specifically written so that the loop is not optimized.
        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        private static bool ByteArraysEqual(byte[] a, byte[] b)
        {
            if (a == null && b == null)
            {
                return true;
            }
            if (a == null || b == null || a.Length != b.Length)
            {
                return false;
            }
            var areSame = true;
            for (var i = 0; i < a.Length; i++)
            {
                areSame &= (a[i] == b[i]);
            }
            return areSame;
        }

        private byte[] HashPasswordV3(string password, RandomNumberGenerator rng)
        {
            return HashPasswordV3(password, rng,
                prf: KeyDerivationPrf.HMACSHA256,
                iterCount: _iterCount,
                saltSize: 128 / 8,
                numBytesRequested: 256 / 8);
        }

        private static byte[] HashPasswordV3(string password, RandomNumberGenerator rng, KeyDerivationPrf prf, int iterCount, int saltSize, int numBytesRequested)
        {
            // Produce a version 3 (see comment above) text hash.
            byte[] salt = new byte[saltSize];
            rng.GetBytes(salt);
            byte[] subkey = KeyDerivation.Pbkdf2(password, salt, prf, iterCount, numBytesRequested);

            var outputBytes = new byte[13 + salt.Length + subkey.Length];
            outputBytes[0] = 0x01; // format marker
            WriteNetworkByteOrder(outputBytes, 1, (uint)prf);
            WriteNetworkByteOrder(outputBytes, 5, (uint)iterCount);
            WriteNetworkByteOrder(outputBytes, 9, (uint)saltSize);
            Buffer.BlockCopy(salt, 0, outputBytes, 13, salt.Length);
            Buffer.BlockCopy(subkey, 0, outputBytes, 13 + saltSize, subkey.Length);
            return outputBytes;
        }

        private static uint ReadNetworkByteOrder(byte[] buffer, int offset)
        {
            return ((uint)(buffer[offset + 0]) << 24)
                | ((uint)(buffer[offset + 1]) << 16)
                | ((uint)(buffer[offset + 2]) << 8)
                | ((uint)(buffer[offset + 3]));
        }

        private static bool VerifyHashedPasswordV3(byte[] hashedPassword, string password, out int iterCount)
        {
            iterCount = default(int);

            try
            {
                // Read header information
                KeyDerivationPrf prf = (KeyDerivationPrf)ReadNetworkByteOrder(hashedPassword, 1);
                iterCount = (int)ReadNetworkByteOrder(hashedPassword, 5);
                int saltLength = (int)ReadNetworkByteOrder(hashedPassword, 9);

                // Read the salt: must be >= 128 bits
                if (saltLength < 128 / 8)
                {
                    return false;
                }
                byte[] salt = new byte[saltLength];
                Buffer.BlockCopy(hashedPassword, 13, salt, 0, salt.Length);

                // Read the subkey (the rest of the payload): must be >= 128 bits
                int subkeyLength = hashedPassword.Length - 13 - salt.Length;
                if (subkeyLength < 128 / 8)
                {
                    return false;
                }
                byte[] expectedSubkey = new byte[subkeyLength];
                Buffer.BlockCopy(hashedPassword, 13 + salt.Length, expectedSubkey, 0, expectedSubkey.Length);

                // Hash the incoming password and verify it
                byte[] actualSubkey = KeyDerivation.Pbkdf2(password, salt, prf, iterCount, subkeyLength);
                return ByteArraysEqual(actualSubkey, expectedSubkey);
            }
            catch
            {
                // This should never occur except in the case of a malformed payload, where
                // we might go off the end of the array. Regardless, a malformed payload
                // implies verification failed.
                return false;
            }
        }

        private static void WriteNetworkByteOrder(byte[] buffer, int offset, uint value)
        {
            buffer[offset + 0] = (byte)(value >> 24);
            buffer[offset + 1] = (byte)(value >> 16);
            buffer[offset + 2] = (byte)(value >> 8);
            buffer[offset + 3] = (byte)(value >> 0);
        }
    }
}
