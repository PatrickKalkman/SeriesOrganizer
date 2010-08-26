using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chalk.SubtitlesManagement.Models;

namespace ShowConversionTest
{
   internal class TvShowTestUtilities
   {
      internal static TvShow CreateNewTvShow()
      {
         TvShow tvShow = new TvShow();
         tvShow.airTime = "12";
         tvShow.favorites = 1;
         tvShow.firstAired = new DateTime(2010, 12, 1, 10, 10, 10).ToString("u");
         tvShow.genres = new List<string>();
         tvShow.genres.Add("Thriller");
         tvShow.genres.Add("Comedy");
         tvShow.hasTranslators = true;
         tvShow.id = 1;
         tvShow.IsValid = true;
         tvShow.lastAired = new DateTime(2010, 12, 1, 10, 10, 10).ToString("u");
         tvShow.network = "CBS";
         tvShow.nextEpisode = new DateTime(2010, 12, 1, 10, 10, 10).ToString("u");
         tvShow.numberOfEpisodes = 10;
         tvShow.runTime = 45;
         tvShow.score = "5.5";
         tvShow.season = "1";
         tvShow.showLink = "http://myshow";
         tvShow.showStatus = "Running";
         tvShow.status = "Running";
         tvShow.summary = "The brown fox jumps over the lazy dog";
         tvShow.showName = "My Show";
         tvShow.tvDbId = 12;
         return tvShow;
      }
   }
}
