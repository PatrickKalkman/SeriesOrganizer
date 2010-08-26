using System;
using System.Collections.Generic;
using Chalk.SubtitlesManagement.Models;
using System.Globalization;

namespace Chalk.SubtitlesManagement
{
   /// <summary>
   /// This class provides services for downloading subtitles.
   /// </summary>
   public class ShowService
   {
      private readonly SubtitleServiceResponseDeserializer responseParser;
      private readonly ServiceChannelFactory serviceChannelFactory;

      internal ShowService(SubtitleServiceResponseDeserializer responseParser, ServiceChannelFactory serviceChannelFactory)
      {
         this.responseParser = responseParser;
         this.serviceChannelFactory = serviceChannelFactory;
      }

      public virtual List<TvShow> FindShowsByName(string name)
      {
         try
         {
            ITvShows bierdopjeService = CreateBierdopjeServiceChannel();
            string responseString = bierdopjeService.FindShowByName(name);
            return responseParser.GetTvShows(responseString);
         }
         catch (Exception error)
         {
            Console.WriteLine("Error {0}", error);
            return new List<TvShow>();
         }
      }

      public virtual TvShow FindShowByName(string name)
      {
         try
         {
            ITvShows bierdopjeService = CreateBierdopjeServiceChannel();
            string responseString = bierdopjeService.FindShowByName(name);
            List<TvShow> showsFound = responseParser.GetTvShows(responseString);
            
            if (showsFound.Count == 1)
               return showsFound[0];

            foreach (TvShow tvShow in showsFound)
            {
               if (string.Compare(name, tvShow.showName, true, CultureInfo.InvariantCulture) == 0)
                  return tvShow;
            }
            return null;
         }
         catch (Exception error)
         {
            Console.WriteLine("Error {0}", error);
            return null;
         }
      }


      public virtual bool TryGetShowById(int id, out TvShowBase tvShow)
      {
         ITvShows bierdopjeService = CreateBierdopjeServiceChannel();
         string responseString = bierdopjeService.GetShowById(id.ToString());
         tvShow = responseParser.GetTvShow(responseString);
         return tvShow.id != 0;
      }

      public virtual bool TryGetShowByTvDbId(int tvDbId, out TvShowBase tvShow)
      {
         ITvShows bierdopjeService = CreateBierdopjeServiceChannel();
         string responseString = bierdopjeService.GetShowByTvDbId(tvDbId.ToString());
         tvShow = responseParser.GetTvShow(responseString);
         return tvShow.id != 0;
      }

      public virtual List<TvShowEpisode> GetEpisodesForSeason(int showId, int season)
      {
         ITvShows bierdopjeService = CreateBierdopjeServiceChannel();
         string responseString = bierdopjeService.GetEpisodesForSeason(showId.ToString(), season.ToString());
         return responseParser.GetTvShowEpisodes(responseString);
      }

      public virtual List<TvShowEpisode> GetAllEpisodesForShow(int showId)
      {
         ITvShows bierdopjeService = CreateBierdopjeServiceChannel();
         string responseString = bierdopjeService.GetAllEpisodesForShow(showId.ToString());
         return responseParser.GetTvShowEpisodes(responseString);
      }

      public TvShowEpisode GetEpisodeById(int episodeId)
      {
         ITvShows bierdopjeService = CreateBierdopjeServiceChannel();
         string responseString = bierdopjeService.GetEpisodeById(episodeId.ToString());
         return responseParser.GetTvShowEpisode(responseString);
      }

      public List<TvShowEpisodeSubtitle> GetAllSubsForEpisode(int episodeId, string language)
      {
         ITvShows bierdopjeService = CreateBierdopjeServiceChannel();
         string responseString = bierdopjeService.GetAllSubsForEpisode(episodeId.ToString(), language);
         return responseParser.GetTvShowEpisodeSubtitles(responseString);
      }

      public List<TvShowEpisodeSubtitle> GetAllSubsFor(int showId, int season, int episodeId, string language, bool isTvBdId)
      {
         ITvShows bierdopjeService = CreateBierdopjeServiceChannel();
         string responseString = bierdopjeService.GetAllSubsFor(showId.ToString(), season.ToString(), episodeId.ToString(), language, isTvBdId.ToString());
         return responseParser.GetTvShowEpisodeSubtitles(responseString);
      }

      private ITvShows CreateBierdopjeServiceChannel()
      {
         return serviceChannelFactory.CreateChannel();
      }
   }
}