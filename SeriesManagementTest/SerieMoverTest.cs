using NUnit.Framework;
using System.IO;

namespace Chalk.SerieOrganizer
{
   [TestFixture]
   public class SerieMoverTest
   {
      private readonly string destinationFolder = Path.Combine(Path.GetTempPath(), "Destination");
      private readonly string sourceFolder = Path.Combine(Path.GetTempPath(), "Source");
      private const string SourceFilename = "Dark.Blue.S01E04.720p.HDTV.X264-DIMENSION.mkv";
      private readonly string sourceFileNameAndPath;

      public SerieMoverTest()
      {
         sourceFileNameAndPath = Path.Combine(sourceFolder, SourceFilename);
      }

      private const string SerieName = "Dark Blue";

      [SetUp]
      public void SetUp()
      {
         Directory.CreateDirectory(destinationFolder);
         Directory.CreateDirectory(sourceFolder);
         File.WriteAllText(sourceFileNameAndPath, string.Empty);
      }

      [TearDown]
      public void TearDown()
      {
         Directory.Delete(destinationFolder, true);
         Directory.Delete(sourceFolder, true);
      }

      [Test]
      public void ShouldSucceedWhenSerieIsMovedToTheCorrectLocation()
      {
         Serie serieToMove = new Serie(sourceFileNameAndPath);
         

         SerieMover seriesMover = new SerieMover(CreateOrganisationConfiguration());
         seriesMover.Move(serieToMove);
         string destinationFilenameAndPath = Path.Combine(Path.Combine(destinationFolder, SerieName), SourceFilename);
         Assert.AreEqual(true, File.Exists(destinationFilenameAndPath));
      }

      private OrganisationConfigurationType CreateOrganisationConfiguration()
      {
         OrganisationConfigurationType configuration = new OrganisationConfigurationType();
         configuration.DestinationDirectory = destinationFolder;
         return configuration;
      }
   }
}