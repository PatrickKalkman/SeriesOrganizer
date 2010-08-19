using NUnit.Framework;
using System.IO;

namespace Chalk.ShowOrganizer
{
   [TestFixture]
   public class ShowMoverTest
   {
      private readonly string destinationFolder = Path.Combine(Path.GetTempPath(), "Destination");
      private readonly string sourceFolder = Path.Combine(Path.GetTempPath(), "Source");
      private const string SourceFilename = "Dark.Blue.S01E04.720p.HDTV.X264-DIMENSION.mkv";
      private readonly string sourceFileNameAndPath;

      public ShowMoverTest()
      {
         sourceFileNameAndPath = Path.Combine(sourceFolder, SourceFilename);
      }

      private const string ShowName = "Dark Blue";

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
      public void ShouldSucceedWhenShowIsMovedToTheCorrectLocation()
      {
         Show ShowToMove = new Show(sourceFileNameAndPath);
         

         ShowMover ShowsMover = new ShowMover(CreateOrganisationConfiguration());
         ShowsMover.Move(ShowToMove);
         string destinationFilenameAndPath = Path.Combine(Path.Combine(destinationFolder, ShowName), SourceFilename);
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