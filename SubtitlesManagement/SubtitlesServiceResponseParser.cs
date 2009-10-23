using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Chalk.SubtitlesManagement
{
   public class SubtitlesServiceResponseParser
   {
      public List<TvShow> FindShowsByName(string result)
      {
         StringReader stringReader = new StringReader(result);
         List<TvShow> shows = IsCachedResult(result) ? GetShows<FindByNamesCachedResult>(stringReader) : GetShows<FindByNamesResult>(stringReader);
         return shows;    
      }

      private static bool IsCachedResult(string result)
      {
         int index = result.IndexOf("<cached>true</cached>");
         return index != -1 && index != 0;
      }

      private static List<TvShow> GetShows<TSerializer>(TextReader stringReader) where TSerializer : ITvShowResult
      {
         XmlSerializer xs = new XmlSerializer(typeof(TSerializer));
         TSerializer bierdopjeResult = (TSerializer)xs.Deserialize(stringReader);
         return bierdopjeResult.TvShows;
      }

      public TvShowBase GetShow(string result)
      {
         if (!string.IsNullOrEmpty(result))
         {
            try
            {
               bool isCachedResult = IsCachedResult(result);
               Type typeToDeserialize = isCachedResult ? typeof(BierDopjeCached) : typeof(BierDopje);
               StringReader stringReader = new StringReader(result);
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
                  TvShow tvShow = ((BierDopje)bierdopjeResult).tvShow;
                  tvShow.Genres.AddRange(tvShow.genres);
                  return tvShow;
               }
            }
            catch (InvalidOperationException error)
            {
               throw new ArgumentException("The given xml is invalid and cannot be parsed.", "result", error);
            }
         }
         throw new ArgumentNullException("result", "The result parameter cannot be null.");
      }
   }
}