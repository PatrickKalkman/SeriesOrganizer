using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Chalk.SerieOrganizer;
using Chalk.SubtitlesManagement;

namespace SubtitleDownloaderApplication
{
   class Program
   {
      static void Main(string[] args)
      {
         SerieCollector serieCollector = new SerieCollector(args[0]);
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
