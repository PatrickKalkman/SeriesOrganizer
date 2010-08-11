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
            Console.WriteLine("Reading {0}", configuration.DirectoryToOrganize);
            SerieCollector collector = new SerieCollector(configuration.DirectoryToOrganize);
            SerieMover mover = new SerieMover(configuration);
            SubtitleService subtitleService = SubtitleServiceFactory.CreateSubtitleService();
            SerieOrganizer organizer = new SerieOrganizer(collector, mover, subtitleService);
            organizer.Organize();
            SerieCleaner cleaner = new SerieCleaner(configuration);
            cleaner.RemoveNfoFiles();
            cleaner.CleanSrrFiles();
            cleaner.RemoveSampleFiles();
            cleaner.CleanEmptyDirectories();
         }
         else
         {
            Console.WriteLine("Cannot read the configuration file.");
         }
      }
   }
}
