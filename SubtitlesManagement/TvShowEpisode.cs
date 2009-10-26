using System;
using System.Xml.Serialization;

namespace Chalk.SubtitlesManagement
{
   [Serializable]
   public class TvShowEpisode
   {
      [XmlElement("episodeid")]
      public int episodeId;

      [XmlElement("tvdbid")]
      public int tvDbId;

      [XmlElement("title")]
      public string title;

      [XmlElement("episodelink")]
      public string episodeLink;

      [XmlElement("season")]
      public string season;

      [XmlElement("episode")] 
      public string episode;

      [XmlElement("epnumber")]
      public string epNumber;

      [XmlElement("wip")]
      public bool wip;

      [XmlElement("wippercentage")]
      public double wipPercentage;

      [XmlElement("wipuser")] 
      public string wipUser;

      [XmlElement("score")]
      public string score;

      [XmlElement("votes")]
      public string votes;

      [XmlElement("airdate")]
      public string airDate;

      [XmlElement("formatted")]
      public string formatted;

      [XmlElement("is_special")]
      public string isSpecial;

      [XmlElement("subsnl")]
      public bool subsnl;

      [XmlElement("subsen")]
      public bool subsen;

      [XmlElement("summary")]
      public string summary;
   }
}