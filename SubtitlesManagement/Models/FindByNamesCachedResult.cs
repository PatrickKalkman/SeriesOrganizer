using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Chalk.SubtitlesManagement.Models
{
   [XmlRoot(ElementName = "bierdopje", Namespace = "", IsNullable = false)]
   [Serializable()]
   public class FindByNamesCachedResult : ITvShowResult 
   {
      [XmlArray("response")]
      [XmlArrayItem("result", typeof(TvShow))]
      public List<TvShow> tvShows;

      public List<TvShow> TvShows
      {
         get { return tvShows; }
      }
   }
}