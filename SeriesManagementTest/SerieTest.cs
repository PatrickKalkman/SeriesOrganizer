using NUnit.Framework;

namespace Chalk.SeriesOrganizer
{
   [TestFixture]
   public class SerieTest
   {
      [Test]
      public void ShouldSucceedWhenCorrectSeasonAndEpisodeAreDetermined1()
      {
         const string FileName = "Dark.Blue.S01E04.720p.HDTV.X264-DIMENSION.mkv";
         Serie serie = new Serie(FileName);
         Assert.AreEqual(4, serie.Episode);
         Assert.AreEqual(1, serie.Season);
      }

      [Test]
      public void ShouldSucceedWhenCorrectSeasonAndEpisodeAreDetermined2()
      {
         const string FileName = "Warehouse.13.S01E11.720p.HDTV.x264-CTU.mkv";
         Serie serie = new Serie(FileName);
         Assert.AreEqual(11, serie.Episode);
         Assert.AreEqual(1, serie.Season);
      }

      [Test]
      public void ShouldSucceedWhenSerieNameIsDetermined1()
      {
         const string FileName = "Dark.Blue.the.Cool.One.S01E04.720p.HDTV.X264-DIMENSION.mkv";
         Serie serie = new Serie(FileName);
         Assert.AreEqual("Dark Blue The Cool One", serie.Name);
      }

      [Test]
      public void ShouldSucceedWhenSerieNameIsDetermined2()
      {
         const string FileName = "warehouse.13.S01E11.720p.HDTV.x264-CTU.mkv";
         Serie serie = new Serie(FileName);
         Assert.AreEqual("Warehouse 13", serie.Name);
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
         const string FileName = "Warehouse.13.S01E11.1080p.HDTV.x264-CTU.mkv";
         Serie serie = new Serie(FileName);
         Assert.AreEqual("1080p", serie.Resolution);
      }

      [Test]
      public void ShouldSucceedWhenFileNameIsValidSerie()
      {
         const string FileName = "Dark.Blue.S01E04.1080P.HDTV.X264-DIMENSION.mkv";
         Serie serie = new Serie(FileName);
         Assert.AreEqual(true, serie.IsValid);
      }

      [Test]
      public void ShouldSucceedWhenFileNameIsNotValidSerie()
      {
         const string FileName = "Dark.Blue.mkv";
         Serie serie = new Serie(FileName);
         Assert.AreEqual(false, serie.IsValid);
      }

      [Test]
      public void ShouldIgnorePathDuringDetermination()
      {
         const string FileName = @"/folder1/test.d3/\ test\ number one/Dark.Blue.S01E04.720p.HDTV.X264-DIMENSION.mkv";
         Serie serie = new Serie(FileName);
         Assert.AreEqual("Dark Blue", serie.Name);
      }
   }
}