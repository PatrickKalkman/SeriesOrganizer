using System.Runtime.Serialization;

namespace Chalk.SubtitlesManagement
{
   [DataContract(Name = "genre", Namespace = "")]
   public class Genre
   {
      [DataMember(Name = "genre")]
      public string genre;
   }
}