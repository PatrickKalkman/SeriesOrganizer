using System;
using System.Collections.Generic;
using System.IO;

namespace Chalk.SeriesOrganizer
{
   internal class SeriesCollector
   {
      private readonly string startDirectoryName;

      public SeriesCollector(string startDirectoryName)
      {
         this.startDirectoryName = startDirectoryName;
      }

      public List<Serie> Collect()
      {
         DirectoryInfo directoryInfo = new DirectoryInfo(startDirectoryName);
         FileInfo[] files = directoryInfo.GetFiles("*.*", SearchOption.AllDirectories);
         return ConvertToSerieTemplates(files);
      }

      private List<Serie> ConvertToSerieTemplates(FileInfo[] infos)
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