using PDFtoImage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PDFTOJPG
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string pdfFilePath = "C:\\Users\\Ursve\\Downloads\\Tamanna Glb\\IT Declaration.pdf"; 
            byte[] pdfBytes = File.ReadAllBytes(pdfFilePath);
            string base64String = Convert.ToBase64String(pdfBytes);
            PDFtoImage.Conversion.SaveJpeg("image.jpg", base64String);
        }
    }
}
