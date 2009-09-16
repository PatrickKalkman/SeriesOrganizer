using System.IO;

namespace Chalk.SerieOrganizer
{
   public class SerieMover
   {
      private readonly string destination;

      public SerieMover(OrganisationConfigurationType configuration)
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