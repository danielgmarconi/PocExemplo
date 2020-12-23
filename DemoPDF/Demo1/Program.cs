using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace Demo1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Geração de PDF
            MemoryStream mms = new MemoryStream();
            PdfDocument doc = new PdfDocument();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);            
            doc.Info.Title = "Demo 1";
            PdfPage page = doc.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Verdana", 20, XFontStyle.BoldItalic);
            gfx.DrawString("Teste PDF", font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormats.Center);
            doc.Save(mms);
            // proteção de PDF
            doc = PdfReader.Open(mms);
            var securitySettings = doc.SecuritySettings;
            securitySettings.UserPassword = "1234";
            securitySettings.PermitAccessibilityExtractContent = false;
            securitySettings.PermitAnnotations = false;
            securitySettings.PermitAssembleDocument = false;
            securitySettings.PermitExtractContent = false;
            securitySettings.PermitFormsFill = true;
            securitySettings.PermitFullQualityPrint = false;
            securitySettings.PermitModifyDocument = true;
            securitySettings.PermitPrint = false;
            doc.Save("TestePDFSharpProtec.pdf");
        }
    }
}
