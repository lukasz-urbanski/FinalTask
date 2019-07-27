using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace FinalTask
{
    public class ZipPackageDetails
    {
        public string SourceLanguage { get; private set; }
        public HashSet<string> LanguagePairs { get; private set; }
        public int JobId { get; private set; }
        public ICollection<ZipEntry> ListOfTargetXliffs { get; set; }

        public ZipPackageDetails(FileInfo fullPathToZipArchive)
        {
            ZipFile zipFileUsed = ZipFile.Read(fullPathToZipArchive.FullName);

            this.SourceLanguage = GetStringBasedOnRegex(zipFileUsed.Entries, new Regex(@"SRC\/([A-Z-_]*)\/"));

            this.LanguagePairs = new HashSet<string>();

            foreach (ZipEntry e in zipFileUsed)
            {
                LanguagePairs.Add(GetStringBasedOnRegex(zipFileUsed.Entries, new Regex(@"TGT\/([A-Z-_]*)\/")));
            }

            string pattern = @"\d+";
            this.JobId = Int32.Parse(Regex.Match(fullPathToZipArchive.Name, pattern).Value);

            this.ListOfTargetXliffs = new List<ZipEntry>();

            foreach (var lp in LanguagePairs)
            {
                ListOfTargetXliffs = zipFileUsed.SelectEntries("name = *.sdlxliff", $"TGT/{lp}");
            }
            
            //ZipEntry ze = zf.SelectEntries("name = *.sdlxliff", "TGT/EN-GB_NL").FirstOrDefault;
        }

        private string GetStringBasedOnRegex(ICollection<ZipEntry> zipEntries, Regex regexToFind)
        {
            string resultString = "";
            foreach (var e in zipEntries)
            {
                MatchCollection matches = regexToFind.Matches(e.FileName);
                if (matches.Count > 0)
                {
                    GroupCollection groups = matches[0].Groups;
                    if (resultString.Length == 0 && groups[1].Length != 0)
                    {
                        resultString = groups[1].Value;
                    }

                }
            }
            return resultString;
        }
    }
}