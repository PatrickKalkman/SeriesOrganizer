using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Chalk.SubtitlesManagement
{
   public class SubtitlesServiceResponseParser
   {
      public List<TvShow> FindShowsByName(string xmlToParse)
      {
         StringReader stringReader = new StringReader(xmlToParse);
         List<TvShow> shows = IsCachedResult(xmlToParse) ? GetShows<FindByNamesCachedResult>(stringReader) : GetShows<FindByNamesResult>(stringReader);
         return shows;
      }

      private static bool IsCachedResult(string xmlToParse)
      {
         int index = xmlToParse.IndexOf("<cached>true</cached>");
         return index != -1 && index != 0;
      }

      private static List<TvShow> GetShows<TSerializer>(TextReader stringReader) where TSerializer : ITvShowResult
      {
         XmlSerializer xs = new XmlSerializer(typeof(TSerializer));
         TSerializer bierdopjeResult = (TSerializer)xs.Deserialize(stringReader);
         return bierdopjeResult.TvShows;
      }

      public TvShowBase GetShow(string xmlToParse)
      {
         if (!string.IsNullOrEmpty(xmlToParse))
         {
            try
            {
               bool isCachedResult = IsCachedResult(xmlToParse);
               Type typeToDeserialize = isCachedResult ? typeof(BierDopjeCached) : typeof(BierDopje);
               StringReader stringReader = new StringReader(xmlToParse);
               XmlSerializer xs = new XmlSerializer(typeToDeserialize);
               var bierdopjeResult = Convert.ChangeType(xs.Deserialize(stringReader), typeToDeserialize);
               if (isCachedResult)
               {
                  TvShowCached tvShowCached = ((BierDopjeCached)bierdopjeResult).tvShow;
                  tvShowCached.Genres.AddRange(tvShowCached.genres);
                  return tvShowCached;
               }
               else
               {
                  TvShow tvShow = ((BierDopje)bierdopjeResult).tvShow;
                  tvShow.Genres.AddRange(tvShow.genres);
                  return tvShow;
               }
            }
            catch (InvalidOperationException error)
            {
               throw new ArgumentException("The given xml is invalid and cannot be parsed.", "xmlToParse", error);
            }
         }
         throw new ArgumentNullException("xmlToParse", "The result parameter cannot be null.");
      }

      public List<TvShowEpisode> GetEpisodes(string xmlToParse)
      {
         if (!string.IsNullOrEmpty(xmlToParse))
         {
            try
            {
               bool isCachedResult = IsCachedResult(xmlToParse);
               Type typeToDeserialize = isCachedResult ? typeof(TvShowEpisodeResultCached) : typeof(TvShowEpisodeResult);
               StringReader stringReader = new StringReader(xmlToParse);
               XmlSerializer xs = new XmlSerializer(typeToDeserialize);
               ITvEpisodes tvShowEpisodeResult = (ITvEpisodes)(xs.Deserialize(stringReader));
               return tvShowEpisodeResult.TvEpisodes;
            }
            catch (InvalidOperationException error)
            {
               throw new ArgumentException("The given xml is invalid and cannot be parsed.", "xmlToParse", error);
            }
         }
         throw new ArgumentNullException("xmlToParse", "The result parameter cannot be null.");
      }
   }
}