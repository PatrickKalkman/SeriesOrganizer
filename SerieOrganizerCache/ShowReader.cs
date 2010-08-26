using Chalk.SubtitlesManagement;
using Chalk.SubtitlesManagement.Models;
using ShowOrganizerCacheTest;

namespace ShowOrganizerCache
{
   public class ShowReader
   {
      private readonly ShowStorage showStorage;
      private readonly ShowService showService;

      public ShowReader(ShowStorage showStorage, ShowService showService)
      {
         this.showStorage = showStorage;
         this.showService = showService;
         numberOfCacheHits = 0;
      }

      public TvShow ReadByName(string showName)
      {
         TvShow show;
         if (showStorage.TryReadShow(showName, out show))
         {
            numberOfCacheHits++;
            return show;
         }

         show = showService.FindShowByName(showName);
         showStorage.Store(show);
         return show;
      }

      private int numberOfCacheHits;

      public int NumberOfCacheHits
      {
         get { return numberOfCacheHits; }
      }
   }
}