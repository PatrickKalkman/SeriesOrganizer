using System;
using Chalk.SubtitlesManagement;
using Chalk.SubtitlesManagement.Models;

namespace Chalk.SerieOrganizer
{
   class Program
   {
      static void Main(string[] args)
      {
         OrganisationConfigurationReader reader = new OrganisationConfigurationReader();
         OrganisationConfigurationType configuration = reader.Read();
         if (configuration != null)
         {
            Console.WriteLine("Starting Organizing {0}", configuration.DirectoryToOrganize);
            SerieCollector collector = new SerieCollector(configuration.DirectoryToOrganize);
            SerieMover mover = new SerieMover(configuration);
            SubtitleService subtitleService = SubtitleServiceFactory.CreateSubtitleService();
            SubtitleDownloader subtitleDownloader = new SubtitleDownloader(subtitleService);
            SerieOrganizer organizer = new SerieOrganizer(collector, mover, subtitleDownloader);
            organizer.Organize();
            SerieCleaner cleaner = new SerieCleaner(configuration);
            cleaner.RemoveNfoFiles();
            cleaner.CleanSrrFiles();
            cleaner.RemoveSampleFiles();
            cleaner.CleanEmptyDirectories();
            Console.WriteLine("Finished Organizing {0}", configuration.DirectoryToOrganize);
         }
         else
         {
            Console.WriteLine("Cannot read the configuration file.");
         }
      }
   }
}
