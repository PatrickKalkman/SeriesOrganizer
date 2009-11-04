using System.Collections.Generic;
using System.IO;
using System.ServiceModel.Channels;
using System.Text;
using Chalk.SubtitlesManagement.Models;

namespace Chalk.SubtitlesManagement
{
   public class SubtitleService
   {
      private readonly SubtitleServiceResponseDeserializer responseParser;
      private readonly ServiceChannelFactory serviceChannelFactory;

      internal SubtitleService(SubtitleServiceResponseDeserializer responseParser, ServiceChannelFactory serviceChannelFactory)
      {
         this.responseParser = responseParser;
         this.serviceChannelFactory = serviceChannelFactory;
      }

      public List<TvShow> FindShowsByName(string name)
      {
         ITvSeries bierdopjeService = CreateBierdopjeServiceChannel();
         string responseString;
         using (Stream responseStream = bierdopjeService.FindShowByName(name))
         {
            responseString = ReadEntireStreamAsString(responseStream);
         }
         CloseBierdopjeServiceChannel(bierdopjeService);

         return responseParser.GetTvShows(responseString);
      }

      public virtual bool TryGetShowById(int id, out TvShowBase tvShow)
      {
         ITvSeries bierdopjeService = CreateBierdopjeServiceChannel();
         string responseString;
         using (Stream responseStream = bierdopjeService.GetShowById(id.ToString()))
         {
            responseString = ReadEntireStreamAsString(responseStream);
         }
         CloseBierdopjeServiceChannel(bierdopjeService);

         tvShow = responseParser.GetTvShow(responseString);
         return tvShow.id != 0;
      }

      public virtual bool TryGetShowByTvDbId(int tvDbId, out TvShowBase tvShow)
      {
         ITvSeries bierdopjeService = CreateBierdopjeServiceChannel();
         string responseString;
         using (Stream responseStream = bierdopjeService.GetShowByTvDbId(tvDbId.ToString()))
         {
            responseString = ReadEntireStreamAsString(responseStream);
         }
         CloseBierdopjeServiceChannel(bierdopjeService);

         tvShow = responseParser.GetTvShow(responseString);
         return tvShow.id != 0;
      }

      public virtual List<TvShowEpisode> GetEpisodesForSeason(int showId, int season)
      {
         ITvSeries bierdopjeService = CreateBierdopjeServiceChannel();
         string responseString;
         using (Stream responseStream = bierdopjeService.GetEpisodesForSeason(showId.ToString(), season.ToString()))
         {
            responseString = ReadEntireStreamAsString(responseStream);
         }
         CloseBierdopjeServiceChannel(bierdopjeService);

         return responseParser.GetTvShowEpisodes(responseString);
      }

      public virtual List<TvShowEpisode> GetAllEpisodesForShow(int showId)
      {
         ITvSeries bierdopjeService = CreateBierdopjeServiceChannel();
         string responseString;
         using (Stream responseStream = bierdopjeService.GetAllEpisodesForShow(showId.ToString()))
         {
            responseString = ReadEntireStreamAsString(responseStream);
         }
         CloseBierdopjeServiceChannel(bierdopjeService);

         return responseParser.GetTvShowEpisodes(responseString);
      }

      public TvShowEpisode GetEpisodeById(int episodeId)
      {
         ITvSeries bierdopjeService = CreateBierdopjeServiceChannel();
         string responseString;
         using (Stream responseStream = bierdopjeService.GetEpisodeById(episodeId.ToString()))
         {
            responseString = ReadEntireStreamAsString(responseStream);
         }
         CloseBierdopjeServiceChannel(bierdopjeService);

         return responseParser.GetTvShowEpisode(responseString);
      }

      public List<TvShowEpisodeSubtitle> GetAllSubsForEpisode(int episodeId, string language)
      {
         ITvSeries bierdopjeService = CreateBierdopjeServiceChannel();
         string responseString;
         using (Stream responseStream = bierdopjeService.GetAllSubsForEpisode(episodeId.ToString(), language))
         {
            responseString = ReadEntireStreamAsString(responseStream);
         }
         CloseBierdopjeServiceChannel(bierdopjeService);
         return responseParser.GetTvShowEpisodeSubtitles(responseString);
      }

      public List<TvShowEpisodeSubtitle> GetAllSubsFor(int showId, int season, int episodeId, string language, bool isTvBdId)
      {
         ITvSeries bierdopjeService = CreateBierdopjeServiceChannel();
         string responseString;
         using (Stream responseStream = bierdopjeService.GetAllSubsFor(showId.ToString(), season.ToString(), episodeId.ToString(), language, isTvBdId.ToString()))
         {
            responseString = ReadEntireStreamAsString(responseStream);
         }
         CloseBierdopjeServiceChannel(bierdopjeService);
         return responseParser.GetTvShowEpisodeSubtitles(responseString);
      }

      private static string ReadEntireStreamAsString(Stream stream)
      {
         using (StreamReader reader = new StreamReader(stream, Encoding.GetEncoding("ISO-8859-1")))
         {
            return reader.ReadToEnd();
         }
      }

      private ITvSeries CreateBierdopjeServiceChannel()
      {
         return serviceChannelFactory.CreateChannel();
      }

      private static void CloseBierdopjeServiceChannel(ITvSeries bierdopjeService)
      {
         IChannel bierdopjeServiceChannel = bierdopjeService as IChannel;
         if (bierdopjeServiceChannel != null)
            bierdopjeServiceChannel.Close();
      }
   }
}