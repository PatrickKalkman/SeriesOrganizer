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

      public TvShow GetShowByTvDbId(string result)
      {
         StringReader stringReader = new StringReader(result);
         return GetShow(stringReader);
      }

      private static TvShow GetShow(TextReader stringReader)
      {
         XmlSerializer xs = new XmlSerializer(typeof(BierDopje));
         var bierdopjeResult = (BierDopje)xs.Deserialize(stringReader);
         return bierdopjeResult.tvShow;
      }

      public TvShow GetShowById(string result)
      {
         if (!string.IsNullOrEmpty(result))
         {
            StringReader stringReader = new StringReader(result);
            return GetShow(stringReader);
         }
         throw new ArgumentNullException("result", "The result parameter cannot be null.");
      }
   }
}