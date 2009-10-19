using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;

namespace Chalk.SubtitlesManagement
{
   public class SubtitlesService
   {
      private readonly SubtitlesServiceResponseParser parser;

      public SubtitlesService(SubtitlesServiceResponseParser parser)
      {
         this.parser = parser;
      }

      public virtual bool TryGetShowById(int id, out TvShow show)
      {
         string uri = "http://www.bierdopje.com/api/51AFBB7D64B937E1/";
         EndpointAddress address = new EndpointAddress(uri);
         ServiceEndpoint endPoint = new ServiceEndpoint(ContractDescription.GetContract(typeof(IBierdopje)), new WebHttpBinding(),  address);
         ChannelFactory<IBierdopje> factory = new ChannelFactory<IBierdopje>(endPoint);
         IBierdopje bierdopje = factory.CreateChannel();
         show = bierdopje.GetShowById(id);
         return true;
      }
   }
}