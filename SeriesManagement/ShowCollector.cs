using System.Collections.Generic;
using System.IO;

namespace Chalk.ShowOrganizer
{
   public class ShowCollector
   {
      private readonly string startDirectoryName;

      public ShowCollector(string directoryToCollect)
      {
         startDirectoryName = directoryToCollect;
      }

      public List<Show> Collect()
      {
         DirectoryInfo directoryInfo = new DirectoryInfo(startDirectoryName);
         FileInfo[] files = directoryInfo.GetFiles("*.mkv", SearchOption.AllDirectories);
         return ConvertToShows(files);
      }

      private static List<Show> ConvertToShows(IEnumerable<FileInfo> infos)
      {
         List<Show> Shows = new List<Show>();
         foreach (FileInfo fileInfo in infos)
         {
            Shows.Add(new Show(fileInfo.FullName));
         }
         return Shows;
      }
   }
}