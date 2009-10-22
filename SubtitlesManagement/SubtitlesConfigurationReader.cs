using Chalk.Common;

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