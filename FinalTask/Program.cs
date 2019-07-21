using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace FinalTask
{

    class Program
    {
        static void Main(string[] args)
        {
            FileInfo fileInfo = new FileInfo(ConfigurationManager.AppSettings["inputPathForSingleFixedFile"] + ConfigurationManager.AppSettings["inputFile"]);

            XliffFileDetails xliffFileDetails = new XliffFileDetails(fileInfo.FullName);

            // Just for test, but could you check if this is something I can begin to work with?
            List<XliffFileDetails> listOfFixedXliffs = new List<XliffFileDetails>();
            DirectoryInfo directoryInfo = new DirectoryInfo(ConfigurationManager.AppSettings["inputPathForAllFixedFiles"]);
            foreach (FileInfo fi in directoryInfo.GetFiles("*.sdlxliff", SearchOption.AllDirectories))
            {
                listOfFixedXliffs.Add(new XliffFileDetails(fi.FullName));
            }
            foreach(XliffFileDetails xliff in listOfFixedXliffs)
            {
                Console.WriteLine(xliff.SourceLanguage);
                Console.WriteLine(xliff.OriginalFileName);
            }
            Console.ReadKey();
        }
    }
}