using System.IO;

namespace Chalk.SeriesOrganizer
{
   internal class SerieMover
   {
      private readonly string destination;

      public SerieMover(string destination)
      {
         this.destination = destination;
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