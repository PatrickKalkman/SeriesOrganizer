using System.Collections.Generic;
using System.IO;

namespace Chalk.SerieOrganizer
{
   internal class SerieCollector
   {
      private readonly string startDirectoryName;

      public SerieCollector(OrganisationConfiguration configuration)
      {
         startDirectoryName = configuration.DirectoryToOrganize;
      }

      public List<Serie> Collect()
      {
         DirectoryInfo directoryInfo = new DirectoryInfo(startDirectoryName);
         FileInfo[] files = directoryInfo.GetFiles("*.*", SearchOption.AllDirectories);
         return ConvertToSeries(files);
      }

      private List<Serie> ConvertToSeries(FileInfo[] infos)
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