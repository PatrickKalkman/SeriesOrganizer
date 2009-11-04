using System;
using System.Collections.Generic;
using Chalk.SubtitlesManagement.Models;
using NUnit.Framework;
using Chalk.SubtitlesManagement.Resources;

namespace Chalk.SubtitlesManagement
{
   [TestFixture]
   public class SubtitlesServiceResponseDeserializerTest
   {
      [Test]
      [ExpectedException(typeof(ArgumentNullException))]
      public void ShouldThrowExceptionWhenResponseIsNullOrEmpty()
      {
         SubtitleServiceResponseDeserializer subtitlesServiceResponseParser = CreateSubtitlesServiceResponseParser();
         subtitlesServiceResponseParser.GetTvShow(null);
      }

      [Test]
      [ExpectedException(typeof(ArgumentNullException))]
      public void ShouldThrowExceptionWhenResponseIsEmpty()
      {
         SubtitleServiceResponseDeserializer subtitlesServiceResponseParser = CreateSubtitlesServiceResponseParser();
         subtitlesServiceResponseParser.GetTvShows(string.Empty);
      }

      [Test]
      [ExpectedException(typeof(ArgumentException))]
      public void ShouldThrowExceptionWhenResponseIsInvalid()
      {
         SubtitleServiceResponseDeserializer subtitlesServiceResponseParser = CreateSubtitlesServiceResponseParser();
         subtitlesServiceResponseParser.GetTvShow("34@#$@#$@#$@#$");
      }

      [Test]
      public void ShouldParseSingleTvShowCorrectly()
      {
         SubtitleServiceResponseDeserializer subtitlesServiceResponseParser = CreateSubtitlesServiceResponseParser();
         TvShowBase tvShow = subtitlesServiceResponseParser.GetTvShow(TestResources.SingleShowNotCached);
         Assert.AreEqual(12934, tvShow.id);
      }

      [Test]
      public void ShouldParseCachedSingleTvShowCorrectly()
      {
         SubtitleServiceResponseDeserializer subtitlesServiceResponseParser = CreateSubtitlesServiceResponseParser();
         TvShowBase tvShow = subtitlesServiceResponseParser.GetTvShow(TestResources.SingleShowCached);
         Assert.AreEqual(12934, tvShow.id);
      }

      [Test]
      public void ShouldParseEpisodesForSeasonCorrectly()
      {
         SubtitleServiceResponseDeserializer subtitlesServiceResponseParser = CreateSubtitlesServiceResponseParser();
         List<TvShowEpisode> episodes = subtitlesServiceResponseParser.GetTvShowEpisodes(TestResources.GetEpisodesForSeasonNotCached);
         Assert.AreEqual(11, episodes.Count);
      }

      [Test]
      public void ShouldParseCachedEpisodesCorrectly()
      {
         SubtitleServiceResponseDeserializer subtitlesServiceResponseParser = CreateSubtitlesServiceResponseParser();
         List<TvShowEpisode> episodes = subtitlesServiceResponseParser.GetTvShowEpisodes(TestResources.GetEpisodesForSeasonCached);
         Assert.AreEqual(11, episodes.Count);
      }

      [Test]
      public void ShouldParseEpisodesForShowCorrectly()
      {
         SubtitleServiceResponseDeserializer subtitlesServiceResponseParser = CreateSubtitlesServiceResponseParser();
         List<TvShowEpisode> episodes = subtitlesServiceResponseParser.GetTvShowEpisodes(TestResources.GetAllEpisodesForShowNotCached);
         Assert.AreEqual(11, episodes.Count);
      }

      [Test]
      public void ShouldParseCachedEpisodesForShowCorrectly()
      {
         SubtitleServiceResponseDeserializer subtitlesServiceResponseParser = CreateSubtitlesServiceResponseParser();
         List<TvShowEpisode> episodes = subtitlesServiceResponseParser.GetTvShowEpisodes(TestResources.GetAllEpisodesForShowCached);
         Assert.AreEqual(11, episodes.Count);
      }

      [Test]
      public void ShouldParseEpisodeCorrectly()
      {
         SubtitleServiceResponseDeserializer subtitlesServiceResponseParser = CreateSubtitlesServiceResponseParser();
         TvShowEpisode episode = subtitlesServiceResponseParser.GetTvShowEpisode(TestResources.GetEpisodeByIdNotCached);
         Assert.AreEqual(418319, episode.episodeId);
      }

      [Test]
      public void ShouldParseCachedEpisodeCorrectly()
      {
         SubtitleServiceResponseDeserializer subtitlesServiceResponseParser = CreateSubtitlesServiceResponseParser();
         TvShowEpisode episode = subtitlesServiceResponseParser.GetTvShowEpisode(TestResources.GetEpisodeByIdCached);
         Assert.AreEqual(418319, episode.episodeId);
      }

      [Test]
      public void ShouldParseSubtitlesCorrectly()
      {
         SubtitleServiceResponseDeserializer subtitlesServiceResponseParser = CreateSubtitlesServiceResponseParser();
         List<TvShowEpisodeSubtitle> tvShowEpisodeSubtitles = subtitlesServiceResponseParser.GetTvShowEpisodeSubtitles(TestResources.GetAllSubsForEpisodeNotCached);
         Assert.AreEqual(2, tvShowEpisodeSubtitles.Count);
      }

      [Test]
      public void ShouldParseCachedSubtitlesCorrectly()
      {
         SubtitleServiceResponseDeserializer subtitlesServiceResponseParser = CreateSubtitlesServiceResponseParser();
         List<TvShowEpisodeSubtitle> tvShowEpisodeSubtitles = subtitlesServiceResponseParser.GetTvShowEpisodeSubtitles(TestResources.GetAllSubsForEpisodeCached);
         Assert.AreEqual(2, tvShowEpisodeSubtitles.Count);
      }

      [Test]
      public void ShouldParseMultipleTvShowsCorrectly()
      {
         const int NumberOfTvShowsInResource = 11;
         SubtitleServiceResponseDeserializer subtitlesServiceResponseParser = CreateSubtitlesServiceResponseParser();
         List<TvShow> tvShows = subtitlesServiceResponseParser.GetTvShows(TestResources.FindShowsByNameNotCached);
         Assert.AreEqual(NumberOfTvShowsInResource, tvShows.Count);
      }

      [Test]
      public void ShouldParseMultipleTvShowsCachedCorrectly()
      {
         const int NumberOfTvShowsInResource = 11;
         SubtitleServiceResponseDeserializer subtitlesServiceResponseParser = CreateSubtitlesServiceResponseParser();
         List<TvShow> tvShows = subtitlesServiceResponseParser.GetTvShows(TestResources.FindShowsByNameCached);
         Assert.AreEqual(NumberOfTvShowsInResource, tvShows.Count);
      }

      private static SubtitleServiceResponseDeserializer CreateSubtitlesServiceResponseParser()
      {
         return new SubtitleServiceResponseDeserializer();
      }
   }
}