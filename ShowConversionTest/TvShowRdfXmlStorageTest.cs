using NUnit.Framework;
using Rhino.Mocks;
using ShowConversion;
using ShowOrganizerCacheTest;
using VDS.RDF;

namespace ShowConversionTest
{
   [TestFixture]
   public class TvShowRdfXmlStorageTest
   {
      [Test]
      public void ShouldLoadAndStoreTvShowRdfXml()
      {
         MockRepository repository = new MockRepository();
         TvShowRdfXmlConverter tvShowRdfXmlConverter = repository.StrictMock<TvShowRdfXmlConverter>();
         Expect.Call(tvShowRdfXmlConverter.Convert(null)).Return(ShowConversionTest.ConvertedRDFFromShow).
            IgnoreArguments();

         TripleStore tripleStore = repository.StrictMock<TripleStore>();
         Expect.Call(() => tripleStore.Add(null)).IgnoreArguments();

         repository.ReplayAll();
         ShowStorage showStorage = new ShowStorage(tvShowRdfXmlConverter, tripleStore);
         showStorage.Store(TvShowTestUtilities.CreateNewTvShow());
         repository.VerifyAll();
      }
   }
}
