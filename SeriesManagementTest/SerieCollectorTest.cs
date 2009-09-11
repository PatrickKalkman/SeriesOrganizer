using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace Chalk.SerieOrganizer
{
   [TestFixture]
   public class SerieCollectorTest
   {
      private readonly string startDirectoryName = Path.Combine(Path.GetTempPath(), "SeriesOrganizerTest");
      
      private const string SerieFileName1 = "Dark.Blue.S01E04.720p.HDTV.X264-DIMENSION.mkv";
      private const string SerieFileName2 = "Dark.Blue.S01E05.720p.HDTV.X264-DIMENSION.mkv";
      private const string SerieFileName3 = "Dark.Blue.S01E07.720p.HDTV.X264-DIMENSION.mkv";
      private const string SerieFileName4 = "Dark.Blue.S02E01.720p.HDTV.X264-DIMENSION.mkv";
      private const string SerieFileName5 = "Dark.Blue.S02E06.720p.HDTV.X264-DIMENSION.mkv";

      [SetUp]
      public void SetUp()
      {
         //SetUp a test directory with some subdirectories with series.
         DirectoryInfo directory = Directory.CreateDirectory(startDirectoryName);
         DirectoryInfo subDirectory = directory.CreateSubdirectory("Series1");
         DirectoryInfo subSubDirectory = subDirectory.CreateSubdirectory("Series5");
         File.WriteAllText(Path.Combine(directory.FullName, SerieFileName1), string.Empty);
         File.WriteAllText(Path.Combine(directory.FullName, SerieFileName2), string.Empty);
         File.WriteAllText(Path.Combine(subDirectory.FullName, SerieFileName3), string.Empty);
         File.WriteAllText(Path.Combine(subDirectory.FullName, SerieFileName4), string.Empty);
         File.WriteAllText(Path.Combine(subSubDirectory.FullName, SerieFileName5), string.Empty);
      }

      [TearDown]
      public void TearDown()
      {
         Directory.Delete(startDirectoryName, true);         
      }


      [Test]
      public void ShouldSucceedWhenRecursiveSearchIsExecuted()
      {
         SerieCollector seriesCollector = new SerieCollector(CreateOrganisationConfiguration());
         List<Serie> series = seriesCollector.Collect();
         Assert.AreEqual(5, series.Count);
      }

      private OrganisationConfiguration CreateOrganisationConfiguration()
      {
         OrganisationConfiguration configuration = new OrganisationConfiguration();
         configuration.DirectoryToOrganize = startDirectoryName;
         return configuration;
      }

   }
}