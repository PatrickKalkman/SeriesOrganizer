using System;
using System.Collections.Generic;
using System.IO;
using Chalk.SubtitlesManagement;

namespace Chalk.SerieOrganizer
{
   public class SerieOrganizer
   {
      private readonly SerieCollector serieCollector;
      private readonly SerieMover serieMover;
      private readonly SubtitleDownloader subtitleDownloader;

      public SerieOrganizer(SerieCollector serieCollector, SerieMover serieMover, SubtitleDownloader subtitleDownloader)
      {
         this.serieCollector = serieCollector;
         this.serieMover = serieMover;
         this.subtitleDownloader = subtitleDownloader;
      }

      public void Organize()
      {
         List<Serie> serieList = serieCollector.Collect();
         Console.WriteLine("Found {0} files.", serieList.Count);
         foreach (Serie serie in serieList)
         {
            if (serie.IsValid)
            {
               Console.WriteLine("Downloading Subtitles for {0}.", serie.FileName);
               subtitleDownloader.DownloadSubtitle(serie.Name, new FileInfo(serie.FullName).DirectoryName, serie.Episode, serie.Season);
               Console.WriteLine("Moving {0} to right location.", serie.FileName);
               serieMover.Move(serie);
            }
         }
      }
   }
}