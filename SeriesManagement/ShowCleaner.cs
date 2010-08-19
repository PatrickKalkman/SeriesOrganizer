using System;
using System.IO;

namespace Chalk.ShowOrganizer
{
   public class ShowCleaner 
   {
      private readonly OrganisationConfigurationType configuration;

      public ShowCleaner(OrganisationConfigurationType configuration)
      {
         this.configuration = configuration;
      }

      public void CleanEmptyDirectories()
      {
         DirectoryInfo directoryToOrganize = new DirectoryInfo(configuration.DirectoryToOrganize);
         foreach (var directory in directoryToOrganize.GetDirectories("*"))
         {
            CleanEmptyDirectory(directory);
         }
      }

      private static void CleanEmptyDirectory(DirectoryInfo directoryInfo)
      {
         FileInfo[] files = directoryInfo.GetFiles();
         DirectoryInfo[] subDirectories = directoryInfo.GetDirectories();
         if (files.Length == 0 && subDirectories.Length > 0)
         {
            foreach (DirectoryInfo subDirectory in subDirectories)
            {
               CleanEmptyDirectory(subDirectory);
            }
         }
         
         files = directoryInfo.GetFiles();
         subDirectories = directoryInfo.GetDirectories();
         
         if (files.Length == 0 && subDirectories.Length == 0)
         {
            Console.WriteLine("Deleting {0}.", directoryInfo.FullName);
            directoryInfo.Delete();
         }
      }

      public void CleanSrrFiles()
      {
         Console.WriteLine("Deleting srr files.");
         DeleteFilesOfType("*srr");
      }

      public void RemoveNfoFiles()
      {
         Console.WriteLine("Deleting nfo files.");
         DeleteFilesOfType("*.nfo");
      }

      public void RemoveSampleFiles()
      {
         Console.WriteLine("Deleting sample files.");
         DeleteFilesOfType("*sample*.mkv");
      }

      private void DeleteFilesOfType(string typeOfFiles)
      {
         DirectoryInfo directoryToOrganize = new DirectoryInfo(configuration.DirectoryToOrganize);
         foreach (FileInfo file in directoryToOrganize.GetFiles(typeOfFiles, SearchOption.AllDirectories))
         {
            Console.WriteLine("Deleting {0} file {0}", typeOfFiles, file.Name);
            file.Delete();
         }
      }

   }
}
