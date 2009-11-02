using System;
using System.Xml.Serialization;

namespace Chalk.SubtitlesManagement.Models
{
   [XmlRoot(ElementName = "bierdopje", Namespace = "")]
   [Serializable()]
   public class SingleTvShowResultCached : ISingleTvShowResult 
   {
      [XmlElement(ElementName = "response")]
      public TvShowCached tvShow;

      public TvShowBase TvShow
      {
         get { return tvShow; }
      }
   }
}