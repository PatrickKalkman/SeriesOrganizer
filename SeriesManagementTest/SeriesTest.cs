using NUnit.Framework;

namespace Chalk.SeriesOrganizer
{
   [TestFixture]
   public class SeriesTest
   {
      [Test]
      public void ShouldSucceedWhenCorrectSeasonAndEpisodeAreDetermined()
      {
         const string FileName = "Dark.Blue.S01E04.720p.HDTV.X264-DIMENSION.mkv";
         Serie serie = new Serie(FileName);
         Assert.AreEqual(4, serie.Episode);
         Assert.AreEqual(1, serie.Season);
      }

      [Test]
      public void ShouldSucceedWhenSerieNameIsDetermined()
      {
         const string FileName = "Dark.Blue.the.Cool.One.S01E04.720p.HDTV.X264-DIMENSION.mkv";
         Serie serie = new Serie(FileName);
         Assert.AreEqual("Dark Blue The Cool One", serie.Name);
      }

      [Test]
      public void ShouldSucceedWhenResolution720IsDetermined()
      {
         const string FileName = "Dark.Blue.S01E04.720p.HDTV.X264-DIMENSION.mkv";
         Serie serie = new Serie(FileName);
         Assert.AreEqual("720p", serie.Resolution);
      }

      [Test]
      public void ShouldSucceedWhenResolution1080IsDetermined()
      {
         const string FileName = "Dark.Blue.S01E04.1080P.HDTV.X264-DIMENSION.mkv";
         Serie serie = new Serie(FileName);
         Assert.AreEqual("1080p", serie.Resolution);
      }


   }
}