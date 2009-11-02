using System.Collections.Generic;

namespace Chalk.SubtitlesManagement.Models
{
   public interface ITvShowEpisodeSubtitlesResult
   {
      List<TvShowEpisodeSubtitle> TvShowEpisodeSubtitles { get; }
   }
}