using Chalk.SerieOrganizer;

namespace Chalk.SubtitlesManagement
{
   public class SubtitlesConfigurationReader : XmlConfigurationReaderBase<SubtitlesConfigurationType>
   {
      public SubtitlesConfigurationReader()
         : base(".", "SubtitlesConfiguration.xml")
      {
      }
   }
}