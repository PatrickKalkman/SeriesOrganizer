using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Chalk.SubtitlesManagement
{
   [Serializable()]
   [XmlRoot("genres")]
   public class Genres : List<Genre>
   {
   }
}