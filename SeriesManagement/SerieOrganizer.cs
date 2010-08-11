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
      private readonly SubtitleService subtitleService;

      public SerieOrganizer(SerieCollector serieCollector, SerieMover serieMover, SubtitleService subtitleService)
      {
         this.serieCollector = serieCollector;
         this.serieMover = serieMover;
         this.subtitleService = subtitleService;
      }

      public void Organize()
      {
         List<Serie> serieList = serieCollector.Collect();
         Console.WriteLine("Found {0} files.", serieList.Count);
         foreach (Serie serie in serieList)
         {
            if (serie.IsValid)
            {
               Console.WriteLine("Processing {0}", serie.FileName);
               subtitleService.DownloadSubtitle(serie.Name, new FileInfo(serie.FullName).DirectoryName, serie.Episode, serie.Season); 
               serieMover.Move(serie);
            }
            else
            {
               Console.WriteLine("Serie {0} is not a valid serie", serie.FileName);
            }
         }
      }
   }
}