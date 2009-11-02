using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Chalk.SubtitlesManagement.Models
{
   [Serializable]
   [XmlRoot("bierdopje")]
   public class TvShowEpisodeResultCached : ITvEpisodes
   {
      [XmlArray("response")]
      [XmlArrayItem("result")]
      public List<TvShowEpisode> tvEpisodes;

      [XmlIgnore]
      public List<TvShowEpisode> TvEpisodes
      {
         get { return tvEpisodes; }
      }
   }
}