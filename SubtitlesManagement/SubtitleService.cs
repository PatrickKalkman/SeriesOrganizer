using System;
using System.Collections.Generic;
using Chalk.SubtitlesManagement.Models;

namespace Chalk.SubtitlesManagement
{
   /// <summary>
   /// This class provides services for downloading subtitles.
   /// </summary>
   public class SubtitleService
   {
      private readonly SubtitleServiceResponseDeserializer responseParser;
      private readonly ServiceChannelFactory serviceChannelFactory;

      internal SubtitleService(SubtitleServiceResponseDeserializer responseParser, ServiceChannelFactory serviceChannelFactory)
      {
         this.responseParser = responseParser;
         this.serviceChannelFactory = serviceChannelFactory;
      }

      public List<TvShow> FindShowsByName(string name)
      {
         try
         {
            ITvSeries bierdopjeService = CreateBierdopjeServiceChannel();
            string responseString = bierdopjeService.FindShowByName(name);
            return responseParser.GetTvShows(responseString);
         }
         catch (Exception error)
         {
            Console.WriteLine("Error {0}", error);
            return new List<TvShow>();
         }
      }

      public virtual bool TryGetShowById(int id, out TvShowBase tvShow)
      {
         ITvSeries bierdopjeService = CreateBierdopjeServiceChannel();
         string responseString = bierdopjeService.GetShowById(id.ToString());
         tvShow = responseParser.GetTvShow(responseString);
         return tvShow.id != 0;
      }

      public virtual bool TryGetShowByTvDbId(int tvDbId, out TvShowBase tvShow)
      {
         ITvSeries bierdopjeService = CreateBierdopjeServiceChannel();
         string responseString = bierdopjeService.GetShowByTvDbId(tvDbId.ToString());
         tvShow = responseParser.GetTvShow(responseString);
         return tvShow.id != 0;
      }

      public virtual List<TvShowEpisode> GetEpisodesForSeason(int showId, int season)
      {
         ITvSeries bierdopjeService = CreateBierdopjeServiceChannel();
         string responseString = bierdopjeService.GetEpisodesForSeason(showId.ToString(), season.ToString());
         return responseParser.GetTvShowEpisodes(responseString);
      }

      public virtual List<TvShowEpisode> GetAllEpisodesForShow(int showId)
      {
         ITvSeries bierdopjeService = CreateBierdopjeServiceChannel();
         string responseString = bierdopjeService.GetAllEpisodesForShow(showId.ToString());
         return responseParser.GetTvShowEpisodes(responseString);
      }

      public TvShowEpisode GetEpisodeById(int episodeId)
      {
         ITvSeries bierdopjeService = CreateBierdopjeServiceChannel();
         string responseString = bierdopjeService.GetEpisodeById(episodeId.ToString());
         return responseParser.GetTvShowEpisode(responseString);
      }

      public List<TvShowEpisodeSubtitle> GetAllSubsForEpisode(int episodeId, string language)
      {
         ITvSeries bierdopjeService = CreateBierdopjeServiceChannel();
         string responseString = bierdopjeService.GetAllSubsForEpisode(episodeId.ToString(), language);
         return responseParser.GetTvShowEpisodeSubtitles(responseString);
      }

      public List<TvShowEpisodeSubtitle> GetAllSubsFor(int showId, int season, int episodeId, string language, bool isTvBdId)
      {
         ITvSeries bierdopjeService = CreateBierdopjeServiceChannel();
         string responseString = bierdopjeService.GetAllSubsFor(showId.ToString(), season.ToString(), episodeId.ToString(), language, isTvBdId.ToString());
         return responseParser.GetTvShowEpisodeSubtitles(responseString);
      }

      private ITvSeries CreateBierdopjeServiceChannel()
      {
         return serviceChannelFactory.CreateChannel();
      }
   }
}