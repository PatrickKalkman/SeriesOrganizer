using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Xml;

namespace Chalk.SubtitlesManagement
{
   [ServiceContract]
   interface IBierdopje
   {
      [OperationContract]
      [WebInvoke(UriTemplate = "/GetShowById/{showId}", Method = "Get")]
      Stream GetShowById(string showId);

      [OperationContract]
      [WebInvoke(UriTemplate = "/GetShowByTVDBID/{showId}", Method = "Get")]
      Stream GetShowByTvDbId(string showId);

      [OperationContract]
      [WebInvoke(UriTemplate = "/FindShowByName/{name}", Method = "Get")]
      TvShows FindShowByName(string name);

      [OperationContract]
      [WebInvoke(UriTemplate = "/GetEpisodesForSeason/{showId}/{season}", Method = "Get")]
      TvShows GetEpisodesForSeason(string showId, string season);

      [OperationContract]
      [WebInvoke(UriTemplate = "/GetAllEpisodesForShow/{showId}", Method = "Get")]
      TvShows GetAllEpisodesForShow(string showId);

      [OperationContract]
      [WebInvoke(UriTemplate = "/GetEpisodeById/{episodeId}", Method = "Get")]
      TvShows GetEpisodeById(string episodeId);

      [OperationContract]
      [WebInvoke(UriTemplate = "/GetAllSubsForEpisode/{episodeId}", Method = "Get")]
      TvShows GetAllSubsForEpisode(string episodeId);

      [OperationContract]
      [WebInvoke(UriTemplate = "/GetAllSubsFor/{showId}/{season}/{episodeId}/{language}/isTvDbId", Method = "Get")]
      TvShows GetAllSubsFor(string showId, string season, string episodeId, string language, string isTvBdId);
   }

   internal class TvShows : List<TvShow>
   {
   }
}
