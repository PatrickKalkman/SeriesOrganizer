using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Chalk.SubtitlesManagement.Models;

namespace Chalk.SubtitlesManagement
{
   /// <summary>
   /// This class is responsible for downloading subtitles of a serie.
   /// </summary>
   public class SubtitleDownloader
   {
      private readonly SubtitleService subtitleService;

      public SubtitleDownloader(SubtitleService subtitleService)
      {
         this.subtitleService = subtitleService;
      }

      public void DownloadSubtitle(string name, string pathToStoreSubtitle, int episode, int season)
      {
         List<TvShow> foundShows = subtitleService.FindShowsByName(name);

         foreach (TvShow tvShow in foundShows)
         {
            if (String.Compare(tvShow.showName, name, true) == 0 || foundShows.Count == 1)
            {
               List<TvShowEpisode> episodesForShow = subtitleService.GetEpisodesForSeason(tvShow.id, season);
               foreach (TvShowEpisode tvShowEpisode in episodesForShow)
               {
                  if (tvShowEpisode.episode == episode.ToString())
                  {
                     if (tvShowEpisode.subsnl)
                     {
                        Console.WriteLine("Downloading dutch subtitles for {0}.", tvShowEpisode.title);
                        DownloadSubtitleForEpisode(tvShowEpisode, pathToStoreSubtitle, "nl");
                        break;
                     }
                     if (tvShowEpisode.subsen)
                     {
                        Console.WriteLine("Downloading english subtitles for {0}.", tvShowEpisode.title);
                        DownloadSubtitleForEpisode(tvShowEpisode, pathToStoreSubtitle, "en");
                        break;
                     }
                     Console.WriteLine("No subtitles found for {0} from {1}", tvShow.showName, tvShowEpisode.title);
                  }
               }
               break;
            }
         }

         if (foundShows.Count == 0)
            Console.WriteLine("No shows found with name {0}", name);
      }

      private void DownloadSubtitleForEpisode(TvShowEpisode tvShowEpisode, string pathToStoreSubtitle, string language)
      {
         List<TvShowEpisodeSubtitle> episodeSubtitles = subtitleService.GetAllSubsForEpisode(tvShowEpisode.episodeId, language);
         using (WebClient webClient = new WebClient())
         {
            foreach (TvShowEpisodeSubtitle tvShowEpisodeSubtitle in episodeSubtitles)
            {
               webClient.DownloadFile(tvShowEpisodeSubtitle.downloadLink, Path.Combine(pathToStoreSubtitle, tvShowEpisodeSubtitle.fileName) + ".srt");
            }
         }
      }
   }
}