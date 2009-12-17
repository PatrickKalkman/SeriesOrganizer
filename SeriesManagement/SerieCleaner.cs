using System;
using System.IO;

namespace Chalk.SerieOrganizer
{
   public class SerieCleaner 
   {
      private readonly OrganisationConfigurationType configuration;

      public SerieCleaner(OrganisationConfigurationType configuration)
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
         DirectoryInfo directoryToOrganize = new DirectoryInfo(configuration.DirectoryToOrganize);
         foreach (FileInfo srrFile in directoryToOrganize.GetFiles("*.srr", SearchOption.AllDirectories))
         {
            Console.WriteLine("Deleting srr file {0}", srrFile.Name);
            srrFile.Delete();
         }
      }

      public void RemoveNfoFiles()
      {
         DirectoryInfo directoryToOrganize = new DirectoryInfo(configuration.DirectoryToOrganize);
         foreach (FileInfo nfoFile in directoryToOrganize.GetFiles("*.nfo", SearchOption.AllDirectories))
         {
            Console.WriteLine("Deleting nfo file {0}", nfoFile.Name);
            nfoFile.Delete();
         }
      }

      public void RemoveSampleFiles()
      {
         DirectoryInfo directoryToOrganize = new DirectoryInfo(configuration.DirectoryToOrganize);
         foreach (FileInfo sampleFile in directoryToOrganize.GetFiles("*sample*.mkv", SearchOption.AllDirectories))
         {
            Console.WriteLine("Deleting sample file {0}", sampleFile.Name);
            sampleFile.Delete();
         }
      }
   }
}