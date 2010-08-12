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

      public string GetShowByTvDbId(string tvDbShowId)
      {
         using (WebClient client = new WebClient())
         {
            string requestUrl = string.Format("{0}/GetShowByTVDBID/{1}", uri, tvDbShowId);
            return client.DownloadString(requestUrl);
         }
      }

      public string FindShowByName(string name)
      {
         using (WebClient client = new WebClient())
         {
            string requestUrl = string.Format("{0}/FindShowByName/{1}", uri, name);
            return client.DownloadString(requestUrl);
         }
      }

      public string GetEpisodesForSeason(string showId, string season)
      {
         using (WebClient client = new WebClient())
         {
            string requestUrl = string.Format("{0}/GetEpisodesForSeason/{1}/{2}", uri, showId, season);
            return client.DownloadString(requestUrl);
         }
      }

      public string GetAllEpisodesForShow(string showId)
      {
         using (WebClient client = new WebClient())
         {
            string requestUrl = string.Format("{0}/GetAllEpisodesForShow/{1}", uri, showId);
            return client.DownloadString(requestUrl);
         }
      }

      public string GetEpisodeById(string episodeId)
      {
         using (WebClient client = new WebClient())
         {
            string requestUrl = string.Format("{0}/GetEpisodeById/{1}", uri, episodeId);
            return client.DownloadString(requestUrl);
         }
      }

      public string GetAllSubsForEpisode(string episodeId, string language)
      {
         using (WebClient client = new WebClient())
         {
            string requestUrl = string.Format("{0}/GetAllSubsForEpisode/{1}/{2}", uri, episodeId, language);
            return client.DownloadString(requestUrl);
         }
      }

      public string GetAllSubsFor(string showId, string season, string episodeId, string language, string isTvDbId)
      {
         using (WebClient client = new WebClient())
         {
            string requestUrl = string.Format("{0}/GetAllSubsFor/{1}/{2}/{3}/{4}/{5}", uri, showId, season, episodeId, language, isTvDbId);
            return client.DownloadString(requestUrl);
         }
      }
   }
}
