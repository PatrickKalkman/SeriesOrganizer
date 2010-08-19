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

         ITvShows tvShows = repository.DynamicMock<ITvShows>();
         Expect.Call(tvShows.FindShowByName(string.Empty)).Return(ResponseString).IgnoreArguments();

         ServiceChannelFactory serviceChannelFactory = repository.DynamicMock<ServiceChannelFactory>(CreateSubtitlesConfiguration());
         Expect.Call(serviceChannelFactory.CreateChannel()).Return(tvShows);

         ShowService subtitlesService = new ShowService(responseParser, serviceChannelFactory);
         repository.ReplayAll();
         subtitlesService.FindShowsByName("Flash");
         repository.VerifyAll();
      }

      [Test]
      public void ShouldRemoveSrrFiles()
      {
          //ctu-x264-lie.to.me.209.srr
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
