namespace Chalk.SubtitlesManagement
{
   public class SubtitlesStorage
   {
      private readonly SubtitlesService service;

      public SubtitlesStorage(SubtitlesService service)
      {
         this.service = service;
      }

      public bool TryGetShowById(int showId, out TvShowBase show)
      {
         return service.TryGetShowById(showId, out show);
      }
   }
}