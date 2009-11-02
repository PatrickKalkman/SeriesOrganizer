using System.Collections.Generic;

namespace Chalk.SubtitlesManagement.Models
{
   public interface ITvEpisodes
   {
      List<TvShowEpisode> TvEpisodes { get; }
   }
}