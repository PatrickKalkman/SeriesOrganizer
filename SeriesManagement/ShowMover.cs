using System.IO;

namespace Chalk.ShowOrganizer
{
   public class ShowMover
   {
      private readonly string destination;

      public ShowMover(OrganisationConfigurationType configuration)
      {
         this.destination = configuration.DestinationDirectory;
      }

      public void Move(Show Show)
      {
         if (Show.IsValid)
         {
            string destinationDirectory = CreateDestinationDirectory(Show);

            string destinationFileName = Path.Combine(destinationDirectory, Show.FileName);
            if (File.Exists(destinationFileName))
               File.Delete(destinationFileName);

            File.Move(Show.FullName, destinationFileName);
            string sourceDirectory = new FileInfo(Show.FullName).DirectoryName;
            if (sourceDirectory != null)
            {
               FileInfo[] subTitles = new DirectoryInfo(sourceDirectory).GetFiles("*.srt");
               foreach (FileInfo subTitle in subTitles)
               {
                  File.Move(subTitle.FullName, Path.Combine(destinationDirectory, subTitle.Name));
               }
            }
         }
      }

      private string CreateDestinationDirectory(Show Show)
      {
         string destinationDirectory = Path.Combine(destination, Show.Name);
         if (!Directory.Exists(destinationDirectory))
         {
            Directory.CreateDirectory(destinationDirectory);
         }
         return destinationDirectory;
      }
   }
}