using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Chalk.SubtitlesManagement
{
   [Serializable()]
   public class TvShow : TvShowBase
   {
      [XmlArray("genres")]
      [XmlArrayItem("genre")]
      public List<string> genres;

      public override List<string> Genres
      {
         get
         {
            return genres;
         }
      }
   }
}