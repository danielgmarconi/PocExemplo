using System;
using System.Text;
using System.IO;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Demo2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Geração de PDF
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            using (MemoryStream ObjememoryStream = new MemoryStream())
            {
                PdfWriter.GetInstance(pdfDoc, ObjememoryStream);
                pdfDoc.Open();
                pdfDoc.Add(new Paragraph("Teste Demo 2"));
                pdfDoc.Close();
                byte[] Filebytes = ObjememoryStream.ToArray();
                ObjememoryStream.Close();
                using (MemoryStream inputData = new MemoryStream(Filebytes)) 
                {
                    PdfReader reader = new PdfReader(inputData);
                    PdfStamper stamper = new PdfStamper(reader, new FileStream("TesteiTextSharpProtect.pdf", FileMode.Create));
                    stamper.SetEncryption(Encoding.ASCII.GetBytes("1234"), Encoding.ASCII.GetBytes("owner"), PdfWriter.AllowPrinting, PdfWriter.ENCRYPTION_AES_128);
                    stamper.Close();
                }
            }
        }
    }
}
