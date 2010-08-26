using System;
using System.Collections.Generic;
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
         TvShowRdfXmlConverter tvShowRdfConverter = new TvShowRdfXmlConverter();
         string tvShowRdfXml = tvShowRdfConverter.Convert(show);
         Assert.AreEqual(ShowConversionTest.ConvertedRDFFromShow, tvShowRdfXml);
      }


   }
}
