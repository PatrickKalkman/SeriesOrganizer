using NUnit.Framework;

namespace Chalk.SerieOrganizer
{
   [TestFixture]
   public class SerieOrganizerTest
   {
      [Test]
      void ShouldSucceedWhen()
      {
         OrganisationConfiguration configuration = new OrganisationConfiguration();
         SerieFactory serieFactory = new SerieFactory();
         SerieMover serieMover = new SerieMover(configuration);
         SerieCollector serieCollector = new SerieCollector(configuration);
         SerieOrganizer organizer = new SerieOrganizer(serieCollector, serieFactory, serieMover);
         organizer.Organize();
      }
   }
}