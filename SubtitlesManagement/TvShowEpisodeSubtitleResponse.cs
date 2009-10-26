using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Chalk.SubtitlesManagement
{
   [Serializable()]
   public class TvShowEpisodeSubtitleResponse
   {
      [XmlArray("results")]
      [XmlArrayItem("result")]
      public List<TvShowEpisodeSubtitle> tvShowEpisodeSubtitles;
   }
}