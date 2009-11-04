using System.Collections.Generic;
using System.IO;
using System.Text;
using Chalk.SubtitlesManagement.Models;
using NUnit.Framework;
using Rhino.Mocks;

namespace Chalk.SubtitlesManagement
{
   [TestFixture]
   public class SubtitlesServiceTest
   {
      private readonly MockRepository repository = new MockRepository();

      [Test]
      public void ShouldSendResponseStringToFindShowByNameInResponseParser()
      {
         const string ResponseString = "Dummy Response String";

         SubtitleServiceResponseDeserializer responseParser = repository.DynamicMock<SubtitleServiceResponseDeserializer>();
         Expect.Call(responseParser.GetTvShows(ResponseString)).Return(new List<TvShow>());

         ITvSeries tvSeries = repository.DynamicMock<ITvSeries>();
         Expect.Call(tvSeries.FindShowByName(string.Empty)).Return(CreateDummyStream(ResponseString)).IgnoreArguments();

         ServiceChannelFactory serviceChannelFactory = repository.DynamicMock<ServiceChannelFactory>(CreateSubtitlesConfiguration());
         Expect.Call(serviceChannelFactory.CreateChannel()).Return(tvSeries);

         SubtitleService subtitlesService = new SubtitleService(responseParser, serviceChannelFactory);
         repository.ReplayAll();
         subtitlesService.FindShowsByName("Flash");
         repository.VerifyAll();
      }


      private static Stream CreateDummyStream(string responseString)
      {
         return new MemoryStream(Encoding.Default.GetBytes(responseString));
      }

      private static SubtitlesConfigurationType CreateSubtitlesConfiguration()
      {
         SubtitlesConfigurationType configuration = new SubtitlesConfigurationType();
         configuration.BierdopjeUrl = "http://www.bierdopje.com";
         configuration.BierdopjeApiKey = "12121212";
         return configuration;
      }
   }
}
