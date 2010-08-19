using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace Chalk.ShowOrganizer
{
   [TestFixture]
   public class ShowCollectorTest
   {
      private readonly string startDirectoryName = Path.Combine(Path.GetTempPath(), "ShowsOrganizerTest");
      
      private const string ShowFileName1 = "Dark.Blue.S01E04.720p.HDTV.X264-DIMENSION.mkv";
      private const string ShowFileName2 = "Dark.Blue.S01E05.720p.HDTV.X264-DIMENSION.mkv";
      private const string ShowFileName3 = "Dark.Blue.S01E07.720p.HDTV.X264-DIMENSION.mkv";
      private const string ShowFileName4 = "Dark.Blue.S02E01.720p.HDTV.X264-DIMENSION.mkv";
      private const string ShowFileName5 = "Dark.Blue.S02E06.720p.HDTV.X264-DIMENSION.mkv";

      [SetUp]
      public void SetUp()
      {
         //SetUp a test directory with some subdirectories with Shows.
         DirectoryInfo directory = Directory.CreateDirectory(startDirectoryName);
         DirectoryInfo subDirectory = directory.CreateSubdirectory("Shows1");
         DirectoryInfo subSubDirectory = subDirectory.CreateSubdirectory("Shows5");
         File.WriteAllText(Path.Combine(directory.FullName, ShowFileName1), string.Empty);
         File.WriteAllText(Path.Combine(directory.FullName, ShowFileName2), string.Empty);
         File.WriteAllText(Path.Combine(subDirectory.FullName, ShowFileName3), string.Empty);
         File.WriteAllText(Path.Combine(subDirectory.FullName, ShowFileName4), string.Empty);
         File.WriteAllText(Path.Combine(subSubDirectory.FullName, ShowFileName5), string.Empty);
      }

      [TearDown]
      public void TearDown()
      {
         Directory.Delete(startDirectoryName, true);         
      }

      [Test]
      public void ShouldSucceedWhenRecursiveSearchIsExecuted()
      {
         ShowCollector ShowsCollector = new ShowCollector(CreateOrganisationConfiguration().DirectoryToOrganize);
         List<Show> Shows = ShowsCollector.Collect();
         Assert.AreEqual(5, Shows.Count);
      }

      private OrganisationConfigurationType CreateOrganisationConfiguration()
      {
         OrganisationConfigurationType configuration = new OrganisationConfigurationType();
         configuration.DirectoryToOrganize = startDirectoryName;
         return configuration;
      }

   }
}