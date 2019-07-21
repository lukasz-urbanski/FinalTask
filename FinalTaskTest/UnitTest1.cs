using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinalTask;

namespace FinalTaskTest
{
    [TestClass]
    public class UnitTest1
    {
        XliffFileDetails testxlif = new XliffFileDetails(@"C:\Users\Łukasz\Desktop\SDL\C#\FilesForFinalTask\TMS Archive replacer inputs\FixedBilingualFiles\ESE\NL\98223_to_translate_docx.sdlxliff");
        [TestMethod]
        public void ShouldReturnSourceLanguage()
        {
            Assert.AreEqual("en-GB", testxlif.SourceLanguage);
        }
        [TestMethod]
        public void ShouldReturnTargetLanguage()
        {
            Assert.AreEqual("nl-NL", testxlif.TargetLanguage);
        }        
        [TestMethod]
        public void ShouldReturnOriginalFileName()
        {
            Assert.AreEqual("to_translate.docx", testxlif.OriginalFileName);
        }
        [TestMethod]
        public void JobId()
        {
            Assert.AreEqual("4739", testxlif.JobId);
        }
    }
}