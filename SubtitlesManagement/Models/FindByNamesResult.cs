using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Chalk.SubtitlesManagement.Models
{
   [XmlRoot(ElementName = "bierdopje", Namespace = "", IsNullable = false)]
   [Serializable()]
   public class FindByNamesResult : ITvShowResult
   {
      [XmlElement("response")]
      public Response response;

      public List<TvShow> TvShows
      {
         get { return response.tvShows; }
      }
   }

   [Serializable()]
   public class Response
   {
      [XmlElement("status")]
      public bool status;

      [XmlArray("results")]
      [XmlArrayItem("genre", typeof(TvShow))]
      public List<TvShow> tvShows;
   }
}