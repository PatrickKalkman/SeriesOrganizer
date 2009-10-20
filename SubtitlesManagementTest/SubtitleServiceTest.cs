using NUnit.Framework;

namespace Chalk.SubtitlesManagement
{
   [TestFixture]
   public class SubtitleServiceTest
   {
      [Test]
      public void ShouldReturnTvShowWhenRequested()
      {
         SubtitlesService service = new SubtitlesService(new SubtitlesServiceResponseParser());
         TvShow tvShow;
         bool result = service.TryGetShowById(12934, out tvShow);
      }
   }
}
