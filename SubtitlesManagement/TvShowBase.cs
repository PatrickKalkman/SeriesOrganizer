using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Chalk.SubtitlesManagement
{
   [Serializable()]
   public class TvShowBase
   {
      [XmlElement("showid")]
      public int id;

      [XmlElement("tvdbid")]
      public int tvDbId;

      [XmlElement("showname")]
      public string showName;

      [XmlElement("showlink")]
      public string showLink;

      [XmlElement("firstaired")]
      public string firstAired;

      [XmlElement("lastaired")]
      public string lastAired;

      [XmlElement("nextepisode")]
      public string nextEpisode;

      [XmlElement("seasons")]
      public string season;

      [XmlElement("episodes")]
      public int numberOfEpisodes;

      [XmlElement("showstatus")]
      public string showStatus;

      [XmlElement("network")]
      public string network;

      [XmlElement("airtime")]
      public string airTime;

      [XmlElement("runtime")]
      public int runTime;

      [XmlElement("score")]
      public string score;

      [XmlElement("favorites")]
      public int favorites;

      [XmlElement("has_translators")]
      public bool hasTranslators;

      [XmlElement("summary")]
      public string summary;

      [XmlElement("status")]
      public string status;

      [XmlElement("cached")]
      public bool cached;

      public List<string> Genres { get; set; }

      public bool IsValid { get; set; }
   }
}