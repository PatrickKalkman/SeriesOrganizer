using System;
using Chalk.SubtitlesManagement;
using Chalk.SubtitlesManagement.Models;

namespace Chalk.ShowOrganizer
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
            ShowCollector collector = new ShowCollector(configuration.DirectoryToOrganize);
            ShowMover mover = new ShowMover(configuration);
            ShowService subtitleService = SubtitleServiceFactory.CreateSubtitleService();
            SubtitleDownloader subtitleDownloader = new SubtitleDownloader(subtitleService);
            ShowOrganizer organizer = new ShowOrganizer(collector, mover, subtitleDownloader);
            organizer.Organize();
            ShowCleaner cleaner = new ShowCleaner(configuration);
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
