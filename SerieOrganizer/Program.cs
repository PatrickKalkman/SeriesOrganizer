using System;
using Chalk.SubtitlesManagement;
using Chalk.SubtitlesManagement.Models;

namespace Chalk.SerieOrganizer
{
   class Program
   {
      static void Main(string[] args)
      {
         SubtitleService subtitleService = SubtitleServiceFactory.CreateSubtitleService();
         TvShowBase tvShow;
         bool result = subtitleService.TryGetShowById(13673, out tvShow);
         Console.WriteLine("TvShow {0}", tvShow.showName);
         Console.ReadLine();


         OrganisationConfigurationReader reader = new OrganisationConfigurationReader();
         OrganisationConfigurationType configuration = reader.Read();
         if (configuration != null)
         {
            Console.WriteLine("Reading {0}", configuration.DirectoryToOrganize);
            SerieCollector collector = new SerieCollector(configuration);
            SerieMover mover = new SerieMover(configuration);
            SerieOrganizer organizer = new SerieOrganizer(collector, mover);
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
