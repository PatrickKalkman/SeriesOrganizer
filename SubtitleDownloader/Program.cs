using System.Collections.Generic;
using System.IO;
using Chalk.SerieOrganizer;
using Chalk.SubtitlesManagement;

namespace Chalk.SubtitleDownload
{
   class Program
   {
      static void Main(string[] args)
      {
         DownloadSubtitlesForDirectory(new DirectoryInfo(args[0]));
      }

      private static void DownloadSubtitlesForDirectory(DirectoryInfo directory)
      {
         SerieCollector serieCollector = new SerieCollector(directory.FullName);
         List<Serie> series = serieCollector.Collect();

         SubtitleService subTitleService = SubtitleServiceFactory.CreateSubtitleService();
         SubtitleDownloader subTitleDownloader = new SubtitleDownloader(subTitleService);
         foreach (Serie serie in series)
         {
            string subtitleDirectory = new FileInfo(serie.FullName).DirectoryName;
            subTitleDownloader.DownloadSubtitle(serie.Name, subtitleDirectory, serie.Episode, serie.Season);
         }
      }
   }
}
