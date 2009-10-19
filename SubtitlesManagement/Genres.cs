using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Chalk.SubtitlesManagement
{
   [DataContract(Name = "genres", Namespace = "")]
   public class Genres : List<Genre>
   {
   }
}