using System;
using System.Collections.Generic;
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

      [Test]
      public void ShouldParseEpisodesCorrectly()
      {
         SubtitlesServiceResponseParser subtitlesServiceResponseParser = CreateSubtitlesServiceResponseParser();
         List<TvShowEpisode> episodes = subtitlesServiceResponseParser.GetEpisodes(TestResources.GetEpisodesForSeasonNotCached);
         Assert.AreEqual(11, episodes.Count);
      }

      [Test]
      public void ShouldParseCachedEpisodesCorrectly()
      {
         SubtitlesServiceResponseParser subtitlesServiceResponseParser = CreateSubtitlesServiceResponseParser();
         List<TvShowEpisode> episodes = subtitlesServiceResponseParser.GetEpisodes(TestResources.GetEpisodesForSeasonCached);
         Assert.AreEqual(11, episodes.Count);
      }

      private static SubtitlesServiceResponseParser CreateSubtitlesServiceResponseParser()
      {
         return new SubtitlesServiceResponseParser();
      }
   }
}