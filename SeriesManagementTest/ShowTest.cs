using NUnit.Framework;

namespace Chalk.ShowOrganizer
{
   [TestFixture]
   public class ShowTest
   {
      [Test]
      public void ShouldSucceedWhenCorrectSeasonAndEpisodeAreDetermined1()
      {
         const string FileName = "Dark.Blue.S01E04.720p.HDTV.X264-DIMENSION.mkv";
         Show Show = new Show(FileName);
         Assert.AreEqual(4, Show.Episode);
         Assert.AreEqual(1, Show.Season);
      }

      [Test]
      public void ShouldSucceedWhenCorrectSeasonAndEpisodeAreDetermined2()
      {
         const string FileName = "Warehouse.13.S01E11.720p.HDTV.x264-CTU.mkv";
         Show Show = new Show(FileName);
         Assert.AreEqual(11, Show.Episode);
         Assert.AreEqual(1, Show.Season);
      }

      [Test]
      public void ShouldSucceedWhenShowNameIsDetermined1()
      {
         const string FileName = "Dark.Blue.the.Cool.One.S01E04.720p.HDTV.X264-DIMENSION.mkv";
         Show Show = new Show(FileName);
         Assert.AreEqual("Dark Blue The Cool One", Show.Name);
      }

      [Test]
      public void ShouldSucceedWhenShowNameIsDetermined2()
      {
         const string FileName = "warehouse.13.S01E11.720p.HDTV.x264-CTU.mkv";
         Show Show = new Show(FileName);
         Assert.AreEqual("Warehouse 13", Show.Name);
      }

      [Test]
      public void ShouldSucceedWhenResolution720IsDetermined()
      {
         const string FileName = "Dark.Blue.S01E04.720p.HDTV.X264-DIMENSION.mkv";
         Show Show = new Show(FileName);
         Assert.AreEqual("720p", Show.Resolution);
      }

      [Test]
      public void ShouldSucceedWhenResolution1080IsDetermined()
      {
         const string FileName = "Warehouse.13.S01E11.1080p.HDTV.x264-CTU.mkv";
         Show Show = new Show(FileName);
         Assert.AreEqual("1080p", Show.Resolution);
      }

      [Test]
      public void ShouldSucceedWhenFileNameIsValidShow()
      {
         const string FileName = "Dark.Blue.S01E04.1080P.HDTV.X264-DIMENSION.mkv";
         Show Show = new Show(FileName);
         Assert.AreEqual(true, Show.IsValid);
      }

      [Test]
      public void ShouldParseLimitedSeasonAndEpisode()
      {
         const string FileName = "lie.to.me.218.720p-dimension.mkv";
         Show Show = new Show(FileName);
         Assert.AreEqual(2, Show.Season);
         Assert.AreEqual(18, Show.Episode);
      }

      [Test]
      public void ShouldSucceedWhenFileNameIsNotValidShow()
      {
         const string FileName = "Dark.Blue.mkv";
         Show Show = new Show(FileName);
         Assert.AreEqual(false, Show.IsValid);
      }

      [Test]
      public void ShouldSucceedWhenFileNameIsValidShow2()
      {
         const string FileName = "psych.s04e02.720p.hdtv.x264-ctu.mkv";
         Show Show = new Show(FileName);
         Assert.AreEqual(true, Show.IsValid);
      }

      [Test]
      public void ShouldIgnorePathDuringDetermination()
      {
         const string FileName = @"/folder1/test.d3/\ test\ number one/Dark.Blue.S01E04.720p.HDTV.X264-DIMENSION.mkv";
         Show Show = new Show(FileName);
         Assert.AreEqual("Dark Blue", Show.Name);
      }

      [Test]
      public void ShouldUsePathInformationWhenSeasonAndEpisodeCannotBeDetermined()
      {
         const string FileName = @"/Fringe\ S02E05/fringe.205.dream.logic-sitv.mkv";
         Show Show = new Show(FileName);
         Assert.AreEqual("Fringe", Show.Name);
         Assert.AreEqual(2, Show.Season);
         Assert.AreEqual(5, Show.Episode);
      }
   }
}