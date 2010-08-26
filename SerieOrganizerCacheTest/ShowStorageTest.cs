using System;
using Chalk.SubtitlesManagement.Models;
using NUnit.Framework;
using Rhino.Mocks;
using ShowConversion;
using VDS.RDF;

namespace ShowOrganizerCacheTest
{
   [TestFixture]
   public class ShowStorageTest
   {
      const string ShowName = "FlashForward";

      [Test]
      public void ShouldStoreShowWhenShowDoesNotExists()
      {
         MockRepository repository = new MockRepository();
         TripleStore tripleStore = repository.StrictMock<TripleStore>();
         Expect.Call(() => tripleStore.Add(null)).IgnoreArguments();
         Expect.Call(() => tripleStore.ExecuteQuery("")).IgnoreArguments().Return(null);
         repository.ReplayAll();

         ShowStorage showStorage = new ShowStorage(new TvShowRdfXmlConverter(), tripleStore);
         showStorage.Store(CreateTvShowToStore());

         TvShow tvShow;
         bool showIsFound = showStorage.TryReadShow(ShowName, out tvShow);
         Assert.IsTrue(showIsFound);
         repository.VerifyAll();
      }

      private static TvShow CreateTvShowToStore()
      {
         TvShow tvShow = new TvShow();
         tvShow.showName = ShowName;
         return tvShow;
      }
   }
}
