using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using Chalk.SubtitlesManagement;

namespace ConsoleApplication1
{
   class Program
   {
      static void Main(string[] args)
      {
         const string Uri = "http://www.bierdopje.com/api/51AFBB7D64B937E1/";
         ServiceEndpoint endPoint = new ServiceEndpoint(ContractDescription.GetContract(typeof(ITvSeries)), new WebHttpBinding(), new EndpointAddress(Uri));
         WebChannelFactory<ITvSeries> channelFactory = new WebChannelFactory<ITvSeries>(endPoint);

         SubtitlesService service = new SubtitlesService(new SubtitlesServiceResponseParser(), channelFactory);
         List<TvShowEpisodeSubtitle> episodes = service.GetAllSubsFor(1062201, 1, 443185, "en", true);

         Console.ReadLine();
      }
   }
}
