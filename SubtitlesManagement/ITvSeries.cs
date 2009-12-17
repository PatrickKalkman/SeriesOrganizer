namespace Chalk.SubtitlesManagement
{
   /// <summary>
   /// This interface describes the api that is offered by www.bierdopje.com for interacting with
   /// the content of the website. 
   /// </summary>
   internal interface ITvSeries
   {
//      [WebInvoke(UriTemplate = "/GetShowById/{showId}", Method = "Get")]
      string GetShowById(string showId);

//      [WebInvoke(UriTemplate = "/GetShowByTVDBID/{showId}", Method = "Get")]
      string GetShowByTvDbId(string showId);

//      [WebInvoke(UriTemplate = "/FindShowByName/{name}", Method = "Get")]
      string FindShowByName(string name);

//      [WebInvoke(UriTemplate = "/GetEpisodesForSeason/{showId}/{season}", Method = "Get")]
      string GetEpisodesForSeason(string showId, string season);

//      [WebInvoke(UriTemplate = "/GetAllEpisodesForShow/{showId}", Method = "Get")]
      string GetAllEpisodesForShow(string showId);

//      [WebInvoke(UriTemplate = "/GetEpisodeById/{episodeId}", Method = "Get")]
      string GetEpisodeById(string episodeId);

//      [WebInvoke(UriTemplate = "/GetAllSubsForEpisode/{episodeId}/{language}", Method = "Get")]
      string GetAllSubsForEpisode(string episodeId, string language);

//      [WebInvoke(UriTemplate = "/GetAllSubsFor/{showId}/{season}/{episodeId}/{language}/{isTvDbId}", Method = "Get")]
      string GetAllSubsFor(string showId, string season, string episodeId, string language, string isTvDbId);
   }
}