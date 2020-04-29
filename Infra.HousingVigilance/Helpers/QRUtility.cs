using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Infra.HousingVigilance.Helpers
{
    public class QRUtility
    {
        public string CreateQR(string uniqueText)
        {
            string qrCodeImageAsBase64 = string.Empty;
            try
            {
                QRCoder.QRCodeGenerator qrGenerator = new QRCoder.QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(uniqueText, QRCoder.QRCodeGenerator.ECCLevel.Q);
                Base64QRCode qrCode = new Base64QRCode(qrCodeData);
                qrCodeImageAsBase64 = qrCode.GetGraphic(10, Color.DarkBlue, Color.DarkGray, (Bitmap)Bitmap.FromFile(@"C:\myIco.png"));


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Details:{ex.Message}");
            }
            return qrCodeImageAsBase64;
        }
    }
}
