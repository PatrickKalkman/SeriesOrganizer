using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using NUnit.Framework;

namespace Chalk.SubtitlesManagement
{
   [TestFixture]
   public class SubtitleServiceTest
   {
      [Test]
      public void ShouldReturnTvShowWhenRequested()
      {
         const string Uri = "http://www.bierdopje.com/api/51AFBB7D64B937E1/";
         ServiceEndpoint endPoint = new ServiceEndpoint(ContractDescription.GetContract(typeof(ITvSeries)), new WebHttpBinding(), new EndpointAddress(Uri));
         WebChannelFactory<ITvSeries> factory = new WebChannelFactory<ITvSeries>(endPoint);

         SubtitlesService service = new SubtitlesService(new SubtitlesServiceResponseParser(), factory);
         TvShow tvShow;
         bool result = service.TryGetShowById(12934, out tvShow);
      }
   }
}
