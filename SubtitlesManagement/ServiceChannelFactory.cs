namespace Chalk.SubtitlesManagement
{
   public class ServiceChannelFactory
   {
      private readonly string uri;

      public ServiceChannelFactory(SubtitlesConfigurationType configuration)
      {
         uri = string.Format("{0}/{1}", configuration.BierdopjeUrl, configuration.BierdopjeApiKey);
      }

      internal virtual ITvSeries CreateChannel()
      {
         return new TvSeriesService(uri);
      }
   }
}