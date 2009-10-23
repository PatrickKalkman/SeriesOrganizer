using System.Collections.Generic;
using System.IO;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Text;

namespace Chalk.SubtitlesManagement
{
   public class SubtitlesService
   {
      private readonly SubtitlesServiceResponseParser responseParser;
      private readonly WebChannelFactory<ITvSeries> channelFactory;

      public SubtitlesService(SubtitlesServiceResponseParser responseParser, WebChannelFactory<ITvSeries> channelFactory)
      {
         this.responseParser = responseParser;
         this.channelFactory = channelFactory;
      }

      public virtual List<TvShow> FindShowsByName(string name)
      {
         ITvSeries bierdopje = channelFactory.CreateChannel();
         Stream responseStream = bierdopje.FindShowByName(name);
         string responseString = CreateStringFromStream(responseStream);
         ((IChannel)bierdopje).Close();

         return responseParser.FindShowsByName(responseString);
      }

      public virtual bool TryGetShowById(int id, out TvShowBase tvShow)
      {
         ITvSeries bierdopje = channelFactory.CreateChannel();
         Stream responseStream = bierdopje.GetShowById(id.ToString());
         string responseString = CreateStringFromStream(responseStream);
         ((IChannel)bierdopje).Close();

         tvShow = responseParser.GetShow(responseString);
         return tvShow.id != 0;
      }

      public virtual bool TryGetShowByTvDbId(int tvDbId, out TvShowBase tvShow)
      {
         ITvSeries bierdopje = channelFactory.CreateChannel();
         Stream responseStream = bierdopje.GetShowByTvDbId(tvDbId.ToString());
         string responseString = CreateStringFromStream(responseStream);
         ((IChannel)bierdopje).Close();

         tvShow = responseParser.GetShow(responseString);
         return tvShow.id != 0;
      }

      public virtual TvShow GetEpisodesForSeason(int showId, int season)
      {
         ITvSeries bierdopje = channelFactory.CreateChannel();
         Stream responseStream = bierdopje.GetEpisodesForSeason(showId.ToString(), season.ToString());
         string responseString = CreateStringFromStream(responseStream);
         return null;
      }

      private static string CreateStringFromStream(Stream stream)
      {
         using (StreamReader reader = new StreamReader(stream, Encoding.GetEncoding("ISO-8859-1")))
         {
            return reader.ReadToEnd();
         }
      }
   }
}