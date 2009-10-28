using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Chalk.SubtitlesManagement
{
   [Serializable()]
   public class TvShowCached : TvShowBase
   {
      [XmlArray("genres")]
      [XmlArrayItem("result")]
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