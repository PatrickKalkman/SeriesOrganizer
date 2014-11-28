using Chalk.SubtitlesManagement.Models;
using NUnit.Framework;
using ShowConversion;

namespace ShowConversionTest
{
    [TestFixture]
    public class TvShowRdfXmlConverterTest
    {
        [Test]
        public void ShouldGenerateCorrectRdfXmlFromTvShow()
        {
            TvShow show = TvShowTestUtilities.CreateNewTvShow();
            var tvShowRdfConverter = new TvShowRdfXmlConverter();
            string tvShowRdfXml = tvShowRdfConverter.Convert(show);
            string expectedResult = ShowConversionTest.ConvertedRDFFromShow.Replace("\r\n", "\n");
            string result = tvShowRdfXml.Replace("\r\n", "\n");
            Assert.AreEqual(expectedResult, result);
        }
    }
}