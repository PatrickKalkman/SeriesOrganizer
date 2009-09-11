using System;

namespace Chalk.SerieOrganizer
{
   internal class SerieOrganizer
   {
      private readonly SerieCollector serieCollector;
      private readonly SerieFactory serieFactory;
      private readonly SerieMover serieMover;

      public SerieOrganizer(SerieCollector serieCollector, SerieFactory serieFactory, SerieMover serieMover)
      {
         this.serieCollector = serieCollector;
         this.serieFactory = serieFactory;
         this.serieMover = serieMover;
      }

      public void Organize()
      {
         throw new NotImplementedException();
      }
   }
}