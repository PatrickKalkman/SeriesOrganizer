namespace Chalk.SubtitlesManagement
{
   public static class SubtitleServiceFactory
   {
      public static SubtitleService CreateSubtitleService()
      {
         SubtitlesConfigurationType configuration = new SubtitlesConfigurationType();
         configuration.BierdopjeUrl = "http://api.bierdopje.com";
         configuration.BierdopjeApiKey = "51AFBB7D64B937E1";
         ServiceChannelFactory serviceChannelFactory = new ServiceChannelFactory(configuration);
         return new SubtitleService(new SubtitleServiceResponseDeserializer(), serviceChannelFactory);
      }
   }
}