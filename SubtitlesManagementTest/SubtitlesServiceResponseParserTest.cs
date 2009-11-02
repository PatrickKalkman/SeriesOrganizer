using System;
using System.Collections.Generic;
using Chalk.SubtitlesManagement.Models;
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
         subtitlesServiceResponseParser.GetTvShow(null);
      }

      [Test]
      [ExpectedException(typeof(ArgumentException))]
      public void ShouldThrowExceptionWhenResponseIsInvalid()
      {
         SubtitlesServiceResponseParser subtitlesServiceResponseParser = CreateSubtitlesServiceResponseParser();
         subtitlesServiceResponseParser.GetTvShow("34@#$@#$@#$@#$");
      }

      [Test]
      public void ShouldParseSingleTvShowCorrectly()
      {
         SubtitlesServiceResponseParser subtitlesServiceResponseParser = CreateSubtitlesServiceResponseParser();
         TvShowBase tvShow = subtitlesServiceResponseParser.GetTvShow(TestResources.SingleShowNotCached);
         Assert.AreEqual(12934, tvShow.id);
      }

      [Test]
      public void ShouldParseCachedSingleTvShowCorrectly()
      {
         SubtitlesServiceResponseParser subtitlesServiceResponseParser = CreateSubtitlesServiceResponseParser();
         TvShowBase tvShow = subtitlesServiceResponseParser.GetTvShow(TestResources.SingleShowCached);
         Assert.AreEqual(12934, tvShow.id);
      }

      [Test]
      public void ShouldParseEpisodesForSeasonCorrectly()
      {
         SubtitlesServiceResponseParser subtitlesServiceResponseParser = CreateSubtitlesServiceResponseParser();
         List<TvShowEpisode> episodes = subtitlesServiceResponseParser.GetTvShowEpisodes(TestResources.GetEpisodesForSeasonNotCached);
         Assert.AreEqual(11, episodes.Count);
      }

      [Test]
      public void ShouldParseCachedEpisodesCorrectly()
      {
         SubtitlesServiceResponseParser subtitlesServiceResponseParser = CreateSubtitlesServiceResponseParser();
         List<TvShowEpisode> episodes = subtitlesServiceResponseParser.GetTvShowEpisodes(TestResources.GetEpisodesForSeasonCached);
         Assert.AreEqual(11, episodes.Count);
      }

      [Test]
      public void ShouldParseEpisodesForShowCorrectly()
      {
         SubtitlesServiceResponseParser subtitlesServiceResponseParser = CreateSubtitlesServiceResponseParser();
         List<TvShowEpisode> episodes = subtitlesServiceResponseParser.GetTvShowEpisodes(TestResources.GetAllEpisodesForShowNotCached);
         Assert.AreEqual(11, episodes.Count);
      }

      [Test]
      public void ShouldParseCachedEpisodesForShowCorrectly()
      {
         SubtitlesServiceResponseParser subtitlesServiceResponseParser = CreateSubtitlesServiceResponseParser();
         List<TvShowEpisode> episodes = subtitlesServiceResponseParser.GetTvShowEpisodes(TestResources.GetAllEpisodesForShowCached);
         Assert.AreEqual(11, episodes.Count);
      }

      [Test]
      public void ShouldParseEpisodeCorrectly()
      {
         SubtitlesServiceResponseParser subtitlesServiceResponseParser = CreateSubtitlesServiceResponseParser();
         TvShowEpisode episode = subtitlesServiceResponseParser.GetTvShowEpisode(TestResources.GetEpisodeByIdNotCached);
         Assert.AreEqual(418319, episode.episodeId);
      }

      [Test]
      public void ShouldParseCachedEpisodeCorrectly()
      {
         SubtitlesServiceResponseParser subtitlesServiceResponseParser = CreateSubtitlesServiceResponseParser();
         TvShowEpisode episode = subtitlesServiceResponseParser.GetTvShowEpisode(TestResources.GetEpisodeByIdCached);
         Assert.AreEqual(418319, episode.episodeId);
      }

      [Test]
      public void ShouldParseSubtitlesCorrectly()
      {
         SubtitlesServiceResponseParser subtitlesServiceResponseParser = CreateSubtitlesServiceResponseParser();
         List<TvShowEpisodeSubtitle> tvShowEpisodeSubtitles = subtitlesServiceResponseParser.GetTvShowEpisodeSubtitles(TestResources.GetAllSubsForEpisodeNotCached);
         Assert.AreEqual(2, tvShowEpisodeSubtitles.Count);
      }

      [Test]
      public void ShouldParseCachedSubtitlesCorrectly()
      {
         SubtitlesServiceResponseParser subtitlesServiceResponseParser = CreateSubtitlesServiceResponseParser();
         List<TvShowEpisodeSubtitle> tvShowEpisodeSubtitles = subtitlesServiceResponseParser.GetTvShowEpisodeSubtitles(TestResources.GetAllSubsForEpisodeCached);
         Assert.AreEqual(2, tvShowEpisodeSubtitles.Count);
      }

      private static SubtitlesServiceResponseParser CreateSubtitlesServiceResponseParser()
      {
         return new SubtitlesServiceResponseParser();
      }
   }
}