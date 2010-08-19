using System.Collections.Generic;
using System.IO;
using Chalk.ShowOrganizer;
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
         ShowCollector ShowCollector = new ShowCollector(directory.FullName);
         List<Show> Shows = ShowCollector.Collect();

         ShowService subTitleService = SubtitleServiceFactory.CreateSubtitleService();
         SubtitleDownloader subTitleDownloader = new SubtitleDownloader(subTitleService);
         foreach (Show Show in Shows)
         {
            string subtitleDirectory = new FileInfo(Show.FullName).DirectoryName;
            subTitleDownloader.DownloadSubtitle(Show.Name, subtitleDirectory, Show.Episode, Show.Season);
         }
      }
   }
}
