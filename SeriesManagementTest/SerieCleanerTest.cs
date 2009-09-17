using System.IO;
using NUnit.Framework;

namespace Chalk.SerieOrganizer
{
   [TestFixture]
   public class SerieCleanerTest
   {
      private DirectoryInfo directoryBase;
      private DirectoryInfo directoryToRemove;

      [SetUp]
      public void SetUp()
      {
         directoryBase = new DirectoryInfo(Path.Combine(Path.GetTempPath(), "Series"));
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
         SerieCleaner cleaner = new SerieCleaner(CreateOrganisationConfiguration());
         cleaner.CleanEmptyDirectories();
         Assert.AreEqual(false, directoryToRemove.Exists);
      }

      [Test]
      public void ShouldSucceedWhenAllNfoFilesAreDeleted()
      {
         File.WriteAllText(Path.Combine(directoryToRemove.FullName, "myTestFile.nfo"), "nfo");
         SerieCleaner cleaner = new SerieCleaner(CreateOrganisationConfiguration());
         cleaner.RemoveNfoFiles();
         Assert.AreEqual(0, directoryToRemove.GetFiles("*.nfo", SearchOption.AllDirectories).Length);
      }

      [Test]
      public void ShouldSucceedWhenSampleFilesAreDeleted()
      {
         File.WriteAllText(Path.Combine(directoryToRemove.FullName, "myTest.Sample.File.mkv"), "nfo");
         SerieCleaner cleaner = new SerieCleaner(CreateOrganisationConfiguration());
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
