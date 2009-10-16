using System;
using System.Collections.Generic;

namespace Chalk.SerieOrganizer
{
   public class SerieOrganizer
   {
      private readonly SerieCollector serieCollector;
      private readonly SerieMover serieMover;

      public SerieOrganizer(SerieCollector serieCollector, SerieMover serieMover)
      {
         this.serieCollector = serieCollector;
         this.serieMover = serieMover;
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