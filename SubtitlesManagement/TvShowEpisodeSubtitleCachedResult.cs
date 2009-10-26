using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Chalk.SubtitlesManagement
{
   [Serializable()]
   [XmlRoot("bierdopje")]
   public class TvShowEpisodeSubtitleCachedResult : ITvShowEpisodeSubtitlesResult
   {
      [XmlArray("response")]
      [XmlArrayItem("result")]
      public List<TvShowEpisodeSubtitle> tvShowEpisodeSubtitles;

      [XmlIgnore]
      public List<TvShowEpisodeSubtitle> TvShowEpisodeSubtitles
      {
         get { return tvShowEpisodeSubtitles; }
      }
   }
}