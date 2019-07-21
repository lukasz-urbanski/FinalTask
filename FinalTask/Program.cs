using System;
using System.IO;
using System.Xml.Linq;

namespace FinalTask
{

    class Program
    {
        static void Main(string[] args)
        {
            XNamespace xNamesapce = "urn:oasis:names:tc:xliff:document:1.2";
            Console.WriteLine("Path: ");
            string path = @"c:\Users\lurbanski\Desktop\Szkola\TMS Archive replacer inputs\FixedBilingualFiles\";

            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            FileInfo[] files = directoryInfo.GetFiles("*.sdlxliff", SearchOption.AllDirectories);

            XDocument document = XDocument.Load("docx.xml");

            string value = document.Root.Element(xNamesapce + "file").Attribute("source-language").Value;
            Console.WriteLine(value);
            Console.ReadKey();
        }
    }
}