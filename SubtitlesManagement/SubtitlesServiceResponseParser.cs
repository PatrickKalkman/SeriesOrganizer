using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Chalk.SubtitlesManagement
{
   public class SubtitlesServiceResponseParser
   {
      internal List<TvShow> FindShowsByName(string xmlToParse)
      {
         StringReader stringReader = new StringReader(xmlToParse);
         List<TvShow> shows = IsCachedResult(xmlToParse) ? GetShows<FindByNamesCachedResult>(stringReader) : GetShows<FindByNamesResult>(stringReader);
         return shows;
      }

      internal static bool IsCachedResult(string xmlToParse)
      {
         int index = xmlToParse.IndexOf("<cached>true</cached>");
         return index != -1 && index != 0;
      }

      internal static List<TvShow> GetShows<TSerializer>(TextReader stringReader) where TSerializer : ITvShowResult
      {
         XmlSerializer xs = new XmlSerializer(typeof(TSerializer));
         TSerializer bierdopjeResult = (TSerializer)xs.Deserialize(stringReader);
         return bierdopjeResult.TvShows;
      }

      internal TvShowBase GetShow(string xmlToParse)
      {
         ValidateXmlToParse(xmlToParse);

         try
         {
            bool isCachedResult = IsCachedResult(xmlToParse);
            Type typeToDeserialize = isCachedResult ? typeof(BierDopjeCached) : typeof(BierDopje);
            using (StringReader stringReader = new StringReader(xmlToParse))
            {
               XmlSerializer xs = new XmlSerializer(typeToDeserialize);

               var bierdopjeResult = Convert.ChangeType(xs.Deserialize(stringReader), typeToDeserialize);
               if (isCachedResult)
               {
                  TvShowCached tvShowCached = ((BierDopjeCached) bierdopjeResult).tvShow;
                  tvShowCached.Genres.AddRange(tvShowCached.genres);
                  return tvShowCached;
               }
               else
               {
                  TvShow tvShow = ((BierDopje) bierdopjeResult).tvShow;
                  tvShow.Genres.AddRange(tvShow.genres);
                  return tvShow;
               }
            }
         }
         catch (InvalidOperationException error)
         {
            throw new ArgumentException("The given xml is invalid and cannot be parsed.", "xmlToParse", error);
         }
      }

      internal List<TvShowEpisode> GetEpisodes(string xmlToParse)
      {
         ValidateXmlToParse(xmlToParse);

         try
         {
            bool isCachedResult = IsCachedResult(xmlToParse);
            Type typeToDeserialize = isCachedResult ? typeof(TvShowEpisodeResultCached) : typeof(TvShowEpisodeResult);
            using (StringReader stringReader = new StringReader(xmlToParse))
            {
               XmlSerializer xs = new XmlSerializer(typeToDeserialize);
               ITvEpisodes tvShowEpisodeResult = (ITvEpisodes) (xs.Deserialize(stringReader));
               return tvShowEpisodeResult.TvEpisodes;
            }
         }
         catch (InvalidOperationException error)
         {
            throw new ArgumentException("The given xml is invalid and cannot be parsed.", "xmlToParse", error);
         }
      }

      internal TvShowEpisode GetEpisode(string xmlToParse)
      {
         ValidateXmlToParse(xmlToParse);
         try
         {
            using (StringReader stringReader = new StringReader(xmlToParse))
            {
               XmlSerializer xs = new XmlSerializer(typeof (SingleTvShowEpisodeResult));
               ITvShowEpisode tvShowEpisode = (ITvShowEpisode) (xs.Deserialize(stringReader));
               return tvShowEpisode.Episode;
            }
         }
         catch (InvalidOperationException error)
         {
            throw new ArgumentException("The given xml is invalid and cannot be parsed.", "xmlToParse", error);
         }
      }

      internal List<TvShowEpisodeSubtitle> GetSubtitle(string xmlToParse)
      {
         ValidateXmlToParse(xmlToParse);
         try
         {
            using (StringReader stringReader = new StringReader(xmlToParse))
            {
               bool isCachedResult = IsCachedResult(xmlToParse);
               Type typeToDeserialize = isCachedResult ? typeof (TvShowEpisodeSubtitleCachedResult) : typeof (TvShowEpisodeSubtitleResult);

               XmlSerializer xs = new XmlSerializer(typeToDeserialize);
               ITvShowEpisodeSubtitlesResult tvShowEpisodeSubtitleResponse = (ITvShowEpisodeSubtitlesResult) (xs.Deserialize(stringReader));
               return tvShowEpisodeSubtitleResponse.TvShowEpisodeSubtitles;
            }
         }
         catch (InvalidOperationException error)
         {
            throw new ArgumentException("The given xml is invalid and cannot be parsed.", "xmlToParse", error);
         }
      }

      private static void ValidateXmlToParse(string xmlToParse)
      {
         if (string.IsNullOrEmpty(xmlToParse))
         {
            throw new ArgumentNullException("xmlToParse", "The result parameter cannot be null or empty.");
         }
      }

   }
}