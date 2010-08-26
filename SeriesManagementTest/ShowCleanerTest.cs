using System.IO;
using NUnit.Framework;

namespace Chalk.ShowOrganizer
{
   [TestFixture]
   public class ShowCleanerTest
   {
      private DirectoryInfo directoryBase;
      private DirectoryInfo directoryToRemove;

      [SetUp]
      public void SetUp()
      {
         directoryBase = new DirectoryInfo(Path.Combine(Path.GetTempPath(), "Shows"));
         directoryBase.Create();

         directoryToRemove = new DirectoryInfo(Path.Combine(directoryBase.FullName, "WhareHouse13"));
         directoryToRemove.Create();

      }

      [TearDown]
      public void TearDown()
      {
         if (directoryBase.Exists)
            directoryBase.Delete(true);
      }


      [Test]
      public void ShouldSucceedWhenEmptyDirectoriesAreDeleted()
      {
         ShowCleaner cleaner = new ShowCleaner(CreateOrganisationConfiguration());
         cleaner.CleanEmptyDirectories();
         Assert.AreEqual(false, directoryToRemove.Exists);
      }

      [Test]
      public void ShouldSucceedWhenAllNfoFilesAreDeleted()
      {
         File.WriteAllText(Path.Combine(directoryToRemove.FullName, "myTestFile.nfo"), "nfo");
         ShowCleaner cleaner = new ShowCleaner(CreateOrganisationConfiguration());
         cleaner.RemoveNfoFiles();
         Assert.AreEqual(0, directoryToRemove.GetFiles("*.nfo", SearchOption.AllDirectories).Length);
      }

      [Test]
      public void ShouldSucceedWhenSampleFilesAreDeleted()
      {
         File.WriteAllText(Path.Combine(directoryToRemove.FullName, "myTest.Sample.File.mkv"), "nfo");
         ShowCleaner cleaner = new ShowCleaner(CreateOrganisationConfiguration());
         cleaner.RemoveSampleFiles();
         Assert.AreEqual(0, directoryToRemove.GetFiles("*Sample*.mkv", SearchOption.AllDirectories).Length);
      }

      private OrganisationConfigurationType CreateOrganisationConfiguration()
      {
         OrganisationConfigurationType configuration = new OrganisationConfigurationType();
         configuration.DirectoryToOrganize = directoryBase.FullName;
         return configuration;
      }
   }
}