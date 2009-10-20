using NUnit.Framework;
using Rhino.Mocks;

namespace Chalk.SubtitlesManagement
{
   [TestFixture]
   public class BierdopjeInterfaceTest
   {
      [Test]
      public void GetShowByIdShouldCallSubtitleServiceAndParseXml()
      {
         MockRepository repository = new MockRepository();
         const int ShowId = 1;
         SubtitlesService subtitlesService = repository.DynamicMock<SubtitlesService>(new object[] { null });
         TvShow tvShow;
         Expect.Call(subtitlesService.TryGetShowById(ShowId, out tvShow)).OutRef(new TvShow()).Return(true);

         repository.ReplayAll();
         SubtitlesStorage storage = new SubtitlesStorage(subtitlesService);
         bool found = storage.TryGetShowById(ShowId, out tvShow);
         Assert.IsTrue(found);
         repository.VerifyAll();
      }
   }
}