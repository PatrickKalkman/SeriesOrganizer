using System;
using System.Collections.Generic;
using Chalk.SubtitlesManagement;
using Chalk.SubtitlesManagement.Models;

namespace ConsoleApplication1
{
   class Program
   {
      static void Main(string[] args)
      {
         SubtitlesConfigurationType configuration = new SubtitlesConfigurationType();
         configuration.BierdopjeUrl = "http://www.bierdopje.com";
         configuration.BierdopjeApiKey = "51AFBB7D64B937E1";
         ServiceChannelFactory serviceChannelFactory = new ServiceChannelFactory(configuration);
         SubtitlesService service = new SubtitlesService(new SubtitlesServiceResponseParser(), serviceChannelFactory);
         List<TvShow> shows = service.FindShowsByName("Flash");

         Console.ReadLine();
      }
   }
}
