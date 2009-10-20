using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Chalk.SubtitlesManagement
{
   [Serializable]
   public class Genre
   {
      [XmlElement("result")]
      public string genre;
   }
}