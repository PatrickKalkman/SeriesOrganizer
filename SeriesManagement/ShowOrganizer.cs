using System;
using System.Collections.Generic;
using System.IO;
using Chalk.SubtitlesManagement;

namespace Chalk.ShowOrganizer
{
   public class ShowOrganizer
   {
      private readonly ShowCollector ShowCollector;
      private readonly ShowMover ShowMover;
      private readonly SubtitleDownloader subtitleDownloader;

      public ShowOrganizer(ShowCollector ShowCollector, ShowMover ShowMover, SubtitleDownloader subtitleDownloader)
      {
         this.ShowCollector = ShowCollector;
         this.ShowMover = ShowMover;
         this.subtitleDownloader = subtitleDownloader;
      }

      public void Organize()
      {
         List<Show> ShowList = ShowCollector.Collect();
         Console.WriteLine("Found {0} files.", ShowList.Count);
         foreach (Show Show in ShowList)
         {
            if (Show.IsValid)
            {
               Console.WriteLine("Downloading Subtitles for {0}.", Show.FileName);
               subtitleDownloader.DownloadSubtitle(Show.Name, new FileInfo(Show.FullName).DirectoryName, Show.Episode, Show.Season);
               Console.WriteLine("Moving {0} to right location.", Show.FileName);
               ShowMover.Move(Show);
            }
         }
      }
   }
}