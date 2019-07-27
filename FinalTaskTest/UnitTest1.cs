using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinalTask;

namespace FinalTaskTest
{
    [TestClass]
    public class UnitTest1
    {
        XliffFileDetails testxlif = new XliffFileDetails(new System.IO.FileInfo(@"C:\Users\Łukasz\Desktop\SDL\C#\FilesForFinalTask\TMS Archive replacer inputs\FixedBilingualFiles\ESE\NL\98223_to_translate_docx.sdlxliff"));

        ZipPackageDetails testzip = new ZipPackageDetails(new System.IO.FileInfo(@"C:\Users\Łukasz\Desktop\SDL\C#\FilesForFinalTask\TMS Archive replacer inputs\ArchiveSample - Kopia\ORG 1\jobs\4739_Two newsletters into Dutch.zip"));
        [TestMethod]
        public void ShouldReturnCorrectXliffDetils()
        {
            Assert.AreEqual("en-GB", testxlif.SourceLanguage);
            Assert.AreEqual("nl-NL", testxlif.TargetLanguage);
            Assert.AreEqual("to_translate.docx", testxlif.OriginalFileName);
            Assert.AreEqual("4739", testxlif.JobId);
        }
        [TestMethod]
        public void ShouldReturnCorrectZipDetail()
        {
            Assert.IsNotNull(testzip.LanguagePairs);
        }
    }
}