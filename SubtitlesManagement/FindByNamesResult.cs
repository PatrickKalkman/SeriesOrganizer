using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Chalk.SubtitlesManagement
{
   [XmlRoot(ElementName = "bierdopje", Namespace = "", IsNullable = false)]
   [Serializable()]
   public class FindByNamesResult
   {
      [XmlElement("response")]
      public Response response;
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