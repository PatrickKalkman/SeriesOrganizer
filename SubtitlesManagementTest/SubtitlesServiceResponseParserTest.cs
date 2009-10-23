using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Chalk.SubtitlesManagement.Resources;

namespace Chalk.SubtitlesManagement
{
   [TestFixture]
   public class SubtitlesServiceResponseParserTest
   {
      [Test]
      [ExpectedException(typeof(ArgumentNullException))]
      public void ShouldThrowExceptionWhenResponseIsNullOrEmpty()
      {
         SubtitlesServiceResponseParser subtitlesServiceResponseParser = CreateSubtitlesServiceResponseParser();
         subtitlesServiceResponseParser.GetShow(null);
      }

      [Test]
      [ExpectedException(typeof(ArgumentException))]
      public void ShouldThrowExceptionWhenResponseIsInvalid()
      {
         SubtitlesServiceResponseParser subtitlesServiceResponseParser = CreateSubtitlesServiceResponseParser();
         subtitlesServiceResponseParser.GetShow("34@#$@#$@#$@#$");
      }

      [Test]
      public void ShouldParseSingleTvShowCorrectly()
      {
         SubtitlesServiceResponseParser subtitlesServiceResponseParser = CreateSubtitlesServiceResponseParser();
         TvShowBase tvShow = subtitlesServiceResponseParser.GetShow(TestResources.SingleShowNotCached);
         Assert.AreEqual(12934, tvShow.id);
      }

      [Test]
      public void ShouldParseCachedSingleTvShowCorrectly()
      {
         SubtitlesServiceResponseParser subtitlesServiceResponseParser = CreateSubtitlesServiceResponseParser();
         TvShowBase tvShow = subtitlesServiceResponseParser.GetShow(TestResources.SingleShowCached);
         Assert.AreEqual(12934, tvShow.id);
      }

      private static SubtitlesServiceResponseParser CreateSubtitlesServiceResponseParser()
      {
         return new SubtitlesServiceResponseParser();
      }
   }
}
