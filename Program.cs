using iTextSharp.text.pdf;
using PDFtoImage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace PDFTOJPG
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //string pdfFilePath = "C:\\Users\\Ursve\\Downloads\\Tamanna Glb\\IT Declaration.pdf"; 
            //byte[] pdfBytes = System.IO.File.ReadAllBytes(pdfFilePath);
            //string base64String = Convert.ToBase64String(pdfBytes);
            //PDFtoImage.Conversion.SaveJpeg("image.jpg", base64String);

            MergerPDF();
        }
        static void MergerPDF()
        {
            int numberOfPages = 0;
            string ErrorFile = "";
            int pagecount = 0;
            try
            {
                ArrayList sourcePathNpdfPaths = new ArrayList();
                sourcePathNpdfPaths.Add("C:\\Users\\Ursve\\Downloads\\Tamanna Glb\\IT Declaration.pdf");
                List<string> files = new List<string>();
                files.Add("C:\\Users\\Ursve\\Downloads\\Tamanna Glb\\IT Declaration.pdf");
                files.Add("C:\\Users\\Ursve\\Downloads\\Tamanna Glb\\OpTransactionHistory02-05-2024.pdf");
                foreach (var AppendPdfPath in files)
                {
                    sourcePathNpdfPaths.Add(AppendPdfPath);
                }
                string[] PDFs = (string[])sourcePathNpdfPaths.ToArray(typeof(string));
                PDFs = PDFs.Distinct().ToArray();
                using (var ms = new MemoryStream())
                {
                    var document = new iTextSharp.text.Document();
                    var copy = new PdfCopy(document, ms);
                    document.Open();

                    foreach (var pdfPath in PDFs)
                    {
                        try
                        {
                            PdfReader.unethicalreading = true;
                            var reader = new PdfReader(pdfPath);
                            copy.AddDocument(reader);
                            numberOfPages = numberOfPages + reader.NumberOfPages;

                            reader.Close();
                        }
                        catch (Exception ex)
                        {

                            PDFs = PDFs.Where(e => e != pdfPath).ToArray();

                            ErrorFile = ErrorFile + "," + System.IO.Path.GetFileName(pdfPath);

                        }
                    }

                    document.Close();

                    System.IO.File.WriteAllBytes("C:\\Users\\Ursve\\Downloads\\Tamanna Glb\\veera.pdf", ms.ToArray());
                }
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
