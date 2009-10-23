using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Chalk.SubtitlesManagement
{
   [ServiceContract]
   public interface ITvSeries
   {
      [OperationContract]
      [WebInvoke(UriTemplate = "/GetShowById/{showId}", Method = "Get")]
      Stream GetShowById(string showId);

      [OperationContract]
      [WebInvoke(UriTemplate = "/GetShowByTVDBID/{showId}", Method = "Get")]
      Stream GetShowByTvDbId(string showId);

      [OperationContract]
      [WebInvoke(UriTemplate = "/FindShowByName/{name}", Method = "Get")]
      Stream FindShowByName(string name);

      [OperationContract]
      [WebInvoke(UriTemplate = "/GetEpisodesForSeason/{showId}/{season}", Method = "Get")]
      Stream GetEpisodesForSeason(string showId, string season);

      [OperationContract]
      [WebInvoke(UriTemplate = "/GetAllEpisodesForShow/{showId}", Method = "Get")]
      Stream GetAllEpisodesForShow(string showId);

      [OperationContract]
      [WebInvoke(UriTemplate = "/GetEpisodeById/{episodeId}", Method = "Get")]
      Stream GetEpisodeById(string episodeId);

      [OperationContract]
      [WebInvoke(UriTemplate = "/GetAllSubsForEpisode/{episodeId}", Method = "Get")]
      Stream GetAllSubsForEpisode(string episodeId);

      [OperationContract]
      [WebInvoke(UriTemplate = "/GetAllSubsFor/{showId}/{season}/{episodeId}/{language}/isTvDbId", Method = "Get")]
      Stream GetAllSubsFor(string showId, string season, string episodeId, string language, string isTvBdId);
   }
}
