using System;
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

      public virtual List<TvShowEpisode> GetEpisodesForSeason(int showId, int season)
      {
         ITvSeries bierdopje = channelFactory.CreateChannel();
         Stream responseStream = bierdopje.GetEpisodesForSeason(showId.ToString(), season.ToString());
         string responseString = CreateStringFromStream(responseStream);
         ((IChannel)bierdopje).Close();

         return responseParser.GetEpisodes(responseString);
      }

      public virtual List<TvShowEpisode> GetAllEpisodesForShow(int showId)
      {
         ITvSeries bierdopje = channelFactory.CreateChannel();
         Stream responseStream = bierdopje.GetAllEpisodesForShow(showId.ToString());
         string responseString = CreateStringFromStream(responseStream);
         ((IChannel)bierdopje).Close();

         return responseParser.GetEpisodes(responseString);
      }

      private static string CreateStringFromStream(Stream stream)
      {
         using (StreamReader reader = new StreamReader(stream, Encoding.GetEncoding("ISO-8859-1")))
         {
            return reader.ReadToEnd();
         }
      }

      public TvShowEpisode GetEpisodeById(int episodeId)
      {
         ITvSeries bierdopje = channelFactory.CreateChannel();
         Stream responseStream = bierdopje.GetEpisodeById(episodeId.ToString());
         string responseString = CreateStringFromStream(responseStream);
         ((IChannel) bierdopje).Close();

         return responseParser.GetEpisode(responseString);
      }

      public List<TvShowEpisodeSubtitle> GetAllSubsForEpisode(int episodeId, string language)
      {
         ITvSeries bierdopje = channelFactory.CreateChannel();
         Stream responseStream = bierdopje.GetAllSubsForEpisode(episodeId.ToString(), language);
         string responseString = CreateStringFromStream(responseStream);
         ((IChannel)bierdopje).Close();
         return responseParser.GetSubtitle(responseString);
      }

      public List<TvShowEpisodeSubtitle> GetAllSubsFor(int showId, int season, int episodeId, string language, bool isTvBdId)
      {
         ITvSeries bierdopje = channelFactory.CreateChannel();
         Stream responseStream = bierdopje.GetAllSubsFor(showId.ToString(), season.ToString(), episodeId.ToString(), language, isTvBdId.ToString());
         string responseString = CreateStringFromStream(responseStream);
         ((IChannel)bierdopje).Close();
         return responseParser.GetSubtitle(responseString);
      }
   }
}