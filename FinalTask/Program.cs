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

            List<XliffFileDetails> listOfFixedXliffs = new List<XliffFileDetails>();
            DirectoryInfo directoryInfo = new DirectoryInfo(ConfigurationManager.AppSettings["inputPathForAllFixedFiles"]);

            foreach (FileInfo fi in directoryInfo.GetFiles("*.sdlxliff", SearchOption.AllDirectories))
            {
                listOfFixedXliffs.Add(new XliffFileDetails(fi));
            }

            Console.WriteLine($"List of updated XLIFF files taken from:{Environment.NewLine}{directoryInfo}{Environment.NewLine}");

            foreach (var v in listOfFixedXliffs)
            {
                Console.WriteLine($"file name: {v.FileName}{Environment.NewLine}" +
                    $"source language: {v.SourceLanguage}{Environment.NewLine}" +
                    $"target language: {v.TargetLanguage}{Environment.NewLine}" +
                    $"original file name: {v.OriginalFileName}{Environment.NewLine}" +
                    $"job id: {v.JobId}{Environment.NewLine}" +
                    $"save date: {v.LastSaved}{Environment.NewLine}");
            }

            Console.WriteLine();

            FileInfo zipFileInfo = new FileInfo(ConfigurationManager.AppSettings["inputPathZipArchive"] + ConfigurationManager.AppSettings["inputZipArchive"]);

            ZipPackageDetails zip = new ZipPackageDetails(zipFileInfo);

            Console.WriteLine($"List of old target XLIFF files taken from ziparchive:{Environment.NewLine}{zipFileInfo.FullName}{Environment.NewLine}");
            foreach (var v in zip.ListOfTargetXliffs)
            {
                Console.WriteLine($"file path: {v.FileName}{Environment.NewLine}" +
                    $"job id: {zip.JobId}{Environment.NewLine}" +
                    $"*save date*: {v.LastModified}{Environment.NewLine}");
            }
            int tempCounter = 0;
            foreach (var lp in zip.LanguagePairs)
            {
                tempCounter++;
                Console.WriteLine("language pair {0}: {1}", tempCounter, lp);
            }
            Console.ReadKey();
        }
    }
}