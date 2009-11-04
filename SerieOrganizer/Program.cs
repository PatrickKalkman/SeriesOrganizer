using System;
using System.Collections.Generic;
using Chalk.SubtitlesManagement;
using Chalk.SubtitlesManagement.Models;

namespace Chalk.SerieOrganizer
{
   class Program
   {
      static void Main(string[] args)
      {
         SubtitleService service = SubtitleServiceFactory.CreateSubtitleService();
         List<TvShow> shows = service.FindShowsByName("Flash");
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