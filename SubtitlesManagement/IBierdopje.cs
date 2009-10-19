using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Chalk.SubtitlesManagement
{
   [ServiceContract]
   interface IBierdopje
   {
      [OperationContract]
      [WebInvoke(UriTemplate = "/GetShowById/{showId}", Method = "Get")]
      TvShow GetShowById(int showId);

      [OperationContract]
      [WebInvoke(UriTemplate = "/GetShowByTVDBID/{showId}", Method = "Get")]
      TvShow GetShowByTvDbId(int showId);

      [OperationContract]
      [WebInvoke(UriTemplate = "/FindShowByName/{name}", Method = "Get")]
      TvShows FindShowByName(string name);

      [OperationContract]
      [WebInvoke(UriTemplate = "/GetEpisodesForSeason/{showId}/{season}", Method = "Get")]
      TvShows GetEpisodesForSeason(int showId, int season);

      [OperationContract]
      [WebInvoke(UriTemplate = "/GetAllEpisodesForShow/{showId}", Method = "Get")]
      TvShows GetAllEpisodesForShow(int showId);

      [OperationContract]
      [WebInvoke(UriTemplate = "/GetEpisodeById/{episodeId}", Method = "Get")]
      TvShows GetEpisodeById(int episodeId);

      [OperationContract]
      [WebInvoke(UriTemplate = "/GetAllSubsForEpisode/{episodeId}", Method = "Get")]
      TvShows GetAllSubsForEpisode(int episodeId);

      [OperationContract]
      [WebInvoke(UriTemplate = "/GetAllSubsFor/{showId}/{season}/{episodeId}/{language}/isTvDbId", Method = "Get")]
      TvShows GetAllSubsFor(int showId, int season, int episodeId, string language, bool isTvBdId);
   }

   internal class TvShows : List<TvShow>
   {
   }
}
