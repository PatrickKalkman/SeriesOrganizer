namespace Chalk.SubtitlesManagement
{
   internal class SubtitlesConfigurationReader : XmlConfigurationReaderBase<SubtitlesConfigurationType>
   {
      public SubtitlesConfigurationReader()
         : base(".", "SubtitlesConfiguration.xml")
      {
      }
   }
}