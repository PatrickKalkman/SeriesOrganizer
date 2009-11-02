using System;
using System.Xml.Serialization;

namespace Chalk.SubtitlesManagement.Models
{
   [XmlRoot(ElementName = "bierdopje", Namespace = "")]
   [Serializable()]
   public class SingleTvShowResult : ISingleTvShowResult
   {
      [XmlElement(ElementName = "response")]
      public TvShow tvShow;

      public TvShowBase TvShow
      {
         get { return tvShow; }
      }
   }
}