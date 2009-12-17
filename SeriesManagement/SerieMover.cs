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
            string destinationDirectory = CreateDestinationDirectory(serie);

            string destinationFileName = Path.Combine(destinationDirectory, serie.FileName);
            if (File.Exists(destinationFileName))
               File.Delete(destinationFileName);

            File.Move(serie.FullName, destinationFileName);
         }
      }

      private string CreateDestinationDirectory(Serie serie)
      {
         string destinationDirectory = Path.Combine(destination, serie.Name);
         if (!Directory.Exists(destinationDirectory))
         {
            Directory.CreateDirectory(destinationDirectory);
         }
         return destinationDirectory;
      }
   }
}