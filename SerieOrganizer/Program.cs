using System;

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
            SerieCollector collector = new SerieCollector(configuration);
            SerieMover mover = new SerieMover(configuration);
            SerieOrganizer organizer = new SerieOrganizer(collector, mover);
            organizer.Organize();
         }
         else
         {
            Console.WriteLine("Cannot read the configuration file.");
         }
      }
   }
}