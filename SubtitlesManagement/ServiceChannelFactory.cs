using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;

namespace Chalk.SubtitlesManagement
{
   public class ServiceChannelFactory
   {
      private readonly WebChannelFactory<ITvSeries> channelFactory;

      public ServiceChannelFactory(SubtitlesConfigurationType configuration)
      {
         string uri = string.Format("{0}/api/{1}", configuration.BierdopjeUrl, configuration.BierdopjeApiKey);
         ServiceEndpoint endPoint = new ServiceEndpoint(ContractDescription.GetContract(typeof(ITvSeries)), new WebHttpBinding(), new EndpointAddress(uri));
         channelFactory = new WebChannelFactory<ITvSeries>(endPoint);
      }

      internal virtual ITvSeries CreateChannel()
      {
         return channelFactory.CreateChannel();
      }
   }
}
