using System.Collections.Generic;

namespace Chalk.SubtitlesManagement
{
   public interface ITvShowEpisodeSubtitlesResult
   {
      List<TvShowEpisodeSubtitle> TvShowEpisodeSubtitles { get; }
   }
}