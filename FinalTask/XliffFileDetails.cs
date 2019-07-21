using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FinalTask
{
    public class XliffFileDetails
    {
        public string SourceLanguage { get; private set; }
        public string TargetLanguage { get; private set; }
        public string OriginalFileName { get; private set; }
        public string JobId { get; private set; }
        public readonly XNamespace xNamesapce = "urn:oasis:names:tc:xliff:document:1.2";

        public XliffFileDetails(string filename)
        {
            XDocument document = XDocument.Load(filename);
            string original = document.Root.Element(xNamesapce + "file").Attribute("original").Value;
            string[]originalSplitted = original.Split('\\');

            this.SourceLanguage = document.Root.Element(xNamesapce + "file").Attribute("source-language").Value;
            this.TargetLanguage = document.Root.Element(xNamesapce + "file").Attribute("target-language").Value;
            this.OriginalFileName = originalSplitted[originalSplitted.Length - 1];
            this.JobId = Regex.Split(original, @"\D+")[1];
        }
    }
}