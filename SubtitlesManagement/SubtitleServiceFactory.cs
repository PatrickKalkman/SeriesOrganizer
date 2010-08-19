namespace Chalk.SubtitlesManagement
{
   public static class SubtitleServiceFactory
   {
      public static ShowService CreateSubtitleService()
      {
         SubtitlesConfigurationType configuration = new SubtitlesConfigurationType();
         configuration.BierdopjeUrl = "http://api.bierdopje.com";
         configuration.BierdopjeApiKey = "51AFBB7D64B937E1";
         ServiceChannelFactory serviceChannelFactory = new ServiceChannelFactory(configuration);
         return new ShowService(new SubtitleServiceResponseDeserializer(), serviceChannelFactory);
      }
   }
}