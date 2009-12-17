namespace Chalk.SubtitlesManagement
{
   /// <summary>
   /// This interface describes the api that is offered by www.bierdopje.com for interacting with
   /// the content of the website. 
   /// </summary>
   internal interface ITvSeries
   {
      string GetShowById(string showId);

      string GetShowByTvDbId(string showId);

      string FindShowByName(string name);

      string GetEpisodesForSeason(string showId, string season);

      string GetAllEpisodesForShow(string showId);

      string GetEpisodeById(string episodeId);

      string GetAllSubsForEpisode(string episodeId, string language);

      string GetAllSubsFor(string showId, string season, string episodeId, string language, string isTvDbId);
   }
}