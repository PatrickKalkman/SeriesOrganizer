using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Chalk.SubtitlesManagement.Models
{
   [Serializable]
   [XmlRoot("bierdopje")] 
   public class TvShowEpisodeResult : ITvEpisodes
   {
      [XmlElement("response")]
      public EpisodeResponse episodeResponse;

      [XmlIgnore]
      public List<TvShowEpisode> TvEpisodes
      {
         get { return episodeResponse.tvEpisodes; }
      }
   }

   [Serializable]
   public class EpisodeResponse
   {
      [XmlElement("status")]
      public bool status;
      [XmlElement("cached")]
      public bool cached;
      [XmlElement("apiversion")]
      public string version;
      [XmlElement("cachelife")]
      public string cachelife;

      [XmlArray("results")] 
      [XmlArrayItem("result")] 
      public List<TvShowEpisode> tvEpisodes;
   }
}