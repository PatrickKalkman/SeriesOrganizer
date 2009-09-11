using System.IO;

namespace Chalk.SerieOrganizer
{
   internal class SerieMover
   {
      private readonly string destination;

      public SerieMover(OrganisationConfiguration configuration)
      {
         this.destination = configuration.DestinationDirectory;
      }

      public void Move(Serie serie)
      {
         if (serie.IsValid)
         {
            string destinationDirectory = Path.Combine(destination, serie.Name);
            if (!Directory.Exists(destinationDirectory))
            {
               Directory.CreateDirectory(destinationDirectory);
            }
            File.Move(serie.FullName, Path.Combine(destinationDirectory, serie.FileName));
         }
      }
   }
}