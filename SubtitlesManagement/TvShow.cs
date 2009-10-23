using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Chalk.SubtitlesManagement
{
   [XmlRoot(ElementName = "bierdopje", Namespace = "")]
   [Serializable()]
   public class BierDopje
   {
      [XmlElement(ElementName = "response")]
      public TvShow tvShow;
   }

   [XmlRoot(ElementName = "bierdopje", Namespace = "")]
   [Serializable()]
   public class BierDopjeCached
   {
      [XmlElement(ElementName = "response")]
      public TvShowCached tvShow;
   }

   [Serializable()]
   public class TvShow : TvShowBase
   {
      [XmlArray("genres")]
      [XmlArrayItem("genre")]
      public List<string> genres;
   }
}