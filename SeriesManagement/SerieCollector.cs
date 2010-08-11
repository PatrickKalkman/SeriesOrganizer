using System.Collections.Generic;
using System.IO;

namespace Chalk.SerieOrganizer
{
   public class SerieCollector
   {
      private readonly string startDirectoryName;

      public SerieCollector(string directoryToCollect)
      {
         startDirectoryName = directoryToCollect;
      }

      public List<Serie> Collect()
      {
         DirectoryInfo directoryInfo = new DirectoryInfo(startDirectoryName);
         FileInfo[] files = directoryInfo.GetFiles("*.mkv", SearchOption.AllDirectories);
         return ConvertToSeries(files);
      }

      private static List<Serie> ConvertToSeries(IEnumerable<FileInfo> infos)
      {
         List<Serie> series = new List<Serie>();
         foreach (FileInfo fileInfo in infos)
         {
            series.Add(new Serie(fileInfo.FullName));
         }
         return series;
      }
   }
}