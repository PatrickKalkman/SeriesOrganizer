using Chalk.SubtitlesManagement;
using Chalk.SubtitlesManagement.Models;
using NUnit.Framework;
using Rhino.Mocks;
using ShowOrganizerCache;

namespace ShowOrganizerCacheTest
{
   [TestFixture]
   public class ShowReaderTest
   {
      [Test]
      public void ShowShouldReturnFromCacheWhenAskedForSecondTime()
      {
         const string ShowToFind = "FlashForward";
         MockRepository mockRepository = new MockRepository();

         TvShow theShow;
         ShowStorage showStorage = mockRepository.StrictMock<ShowStorage>(new object[] { null, null } );
         ShowService showService = mockRepository.StrictMock<ShowService>(null, null);

         Expect.Call(showStorage.TryReadShow(ShowToFind, out theShow)).Return(false).OutRef(theShow);
         Expect.Call(showService.FindShowByName(ShowToFind)).Return(theShow);
         Expect.Call(showStorage.TryReadShow(ShowToFind, out theShow)).Return(true).OutRef(theShow);
         Expect.Call(() => showStorage.Store(null)).IgnoreArguments();

         mockRepository.ReplayAll();
         ShowReader showReader = new ShowReader(showStorage, showService);
         TvShow show = showReader.ReadByName(ShowToFind);
         show = showReader.ReadByName(ShowToFind);
         Assert.AreEqual(1, showReader.NumberOfCacheHits);
         mockRepository.VerifyAll();
      }


   }
}