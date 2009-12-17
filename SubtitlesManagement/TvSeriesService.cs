using System;
using System.Net;

namespace Chalk.SubtitlesManagement
{
   public class TvSeriesService : ITvSeries 
   {
      private readonly string uri;

      public TvSeriesService(string uri)
      {
         this.uri = uri;
      }

      public string GetShowById(string showId)
      {
         using (WebClient client = new WebClient())
         {
            string requestUrl = string.Format("{0}/GetShowById/{1}", uri, showId);
            return client.DownloadString(requestUrl);
         }
      }

      public string GetShowByTvDbId(string showId)
      {
         throw new NotImplementedException();
      }

      public string FindShowByName(string name)
      {
         throw new NotImplementedException();
      }

      public string GetEpisodesForSeason(string showId, string season)
      {
         throw new NotImplementedException();
      }

      public string GetAllEpisodesForShow(string showId)
      {
         throw new NotImplementedException();
      }

      public string GetEpisodeById(string episodeId)
      {
         throw new NotImplementedException();
      }

      public string GetAllSubsForEpisode(string episodeId, string language)
      {
         throw new NotImplementedException();
      }

      public string GetAllSubsFor(string showId, string season, string episodeId, string language, string isTvDbId)
      {
         throw new NotImplementedException();
      }
   }
}
