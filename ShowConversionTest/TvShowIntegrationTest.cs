using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chalk.SubtitlesManagement.Models;
using NUnit.Framework;
using ShowConversion;
using ShowOrganizerCacheTest;
using VDS.RDF;

namespace ShowConversionTest
{
   [TestFixture]
   public class TvShowIntegrationTest
   {
      [Test]
      public void LoadTvShowInStorageTest()
      {
         ShowStorage showStorage = new ShowStorage(new TvShowRdfXmlConverter(), new TripleStore());
         showStorage.Store(TvShowTestUtilities.CreateNewTvShow());
         TvShow tvShow;
         bool result = showStorage.TryReadShow("My Show", out tvShow);
      }
   }
}
