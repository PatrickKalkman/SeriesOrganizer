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

      [Test]
      public void ShouldParseEpisodesCorrectly2()
      {
         SubtitlesServiceResponseParser subtitlesServiceResponseParser = CreateSubtitlesServiceResponseParser();
         List<TvShowEpisode> episodes = subtitlesServiceResponseParser.GetEpisodes(TestResources.GetAllEpisodesForShowNotCached);
         Assert.AreEqual(11, episodes.Count);
      }

      [Test]
      public void ShouldParseCachedEpisodesCorrectly2()
      {
         SubtitlesServiceResponseParser subtitlesServiceResponseParser = CreateSubtitlesServiceResponseParser();
         List<TvShowEpisode> episodes = subtitlesServiceResponseParser.GetEpisodes(TestResources.GetAllEpisodesForShowCached);
         Assert.AreEqual(11, episodes.Count);
      }

      [Test]
      public void ShouldParseEpisodeCorrectly()
      {
         SubtitlesServiceResponseParser subtitlesServiceResponseParser = CreateSubtitlesServiceResponseParser();
         TvShowEpisode episode = subtitlesServiceResponseParser.GetEpisode(TestResources.GetEpisodeByIdNotCached);
         Assert.AreEqual(418319, episode.episodeId);
      }

      [Test]
      public void ShouldParseCachedEpisodeCorrectly()
      {
         SubtitlesServiceResponseParser subtitlesServiceResponseParser = CreateSubtitlesServiceResponseParser();
         TvShowEpisode episode = subtitlesServiceResponseParser.GetEpisode(TestResources.GetEpisodeByIdCached);
         Assert.AreEqual(418319, episode.episodeId);
      }

      [Test]
      public void ShouldParseSubtitlesCorrectly()
      {
         SubtitlesServiceResponseParser subtitlesServiceResponseParser = CreateSubtitlesServiceResponseParser();
         List<TvShowEpisodeSubtitle> tvShowEpisodeSubtitles = subtitlesServiceResponseParser.GetSubtitle(TestResources.GetAllSubsForEpisodeNotCached);
         Assert.AreEqual(2, tvShowEpisodeSubtitles.Count);
      }

      [Test]
      public void ShouldParseCachedSubtitlesCorrectly()
      {
         SubtitlesServiceResponseParser subtitlesServiceResponseParser = CreateSubtitlesServiceResponseParser();
         List<TvShowEpisodeSubtitle> tvShowEpisodeSubtitles = subtitlesServiceResponseParser.GetSubtitle(TestResources.GetAllSubsForEpisodeCached);
         Assert.AreEqual(2, tvShowEpisodeSubtitles.Count);
      }

      private static SubtitlesServiceResponseParser CreateSubtitlesServiceResponseParser()
      {
         return new SubtitlesServiceResponseParser();
      }
   }
}