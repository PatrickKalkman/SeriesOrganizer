using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Chalk.SubtitlesManagement.Models;

namespace Chalk.SubtitlesManagement
{
   /// <summary>
   /// This class is responsible for parsing the response string and creating 
   /// concrete types from the response string.
   /// </summary>
   public class SubtitlesServiceResponseParser
   {
      internal TvShowBase GetTvShow(string xmlToParse)
      {
         ValidateXmlToParse(xmlToParse);
         Type typeToDeserialize = GetTypeToDeserialize(xmlToParse, typeof(SingleTvShowResult), typeof(SingleTvShowResultCached));
         return DeserializeType<ISingleTvShowResult>(xmlToParse, typeToDeserialize).TvShow;
      }

      internal virtual List<TvShow> GetTvShows(string xmlToParse)
      {
         ValidateXmlToParse(xmlToParse);
         Type typeToDeserialize = GetTypeToDeserialize(xmlToParse, typeof(FindByNamesResult), typeof(FindByNamesCachedResult));
         return DeserializeType<ITvShowResult>(xmlToParse, typeToDeserialize).TvShows;
      }

      internal TvShowEpisode GetTvShowEpisode(string xmlToParse)
      {
         ValidateXmlToParse(xmlToParse);
         return DeserializeType<ITvShowEpisode>(xmlToParse, typeof(SingleTvShowEpisodeResult)).Episode;
      }

      internal List<TvShowEpisode> GetTvShowEpisodes(string xmlToParse)
      {
         ValidateXmlToParse(xmlToParse);
         Type typeToDeserialize = GetTypeToDeserialize(xmlToParse, typeof(TvShowEpisodeResult), typeof(TvShowEpisodeResultCached));
         return DeserializeType<ITvEpisodes>(xmlToParse, typeToDeserialize).TvEpisodes;
      }

      internal List<TvShowEpisodeSubtitle> GetTvShowEpisodeSubtitles(string xmlToParse)
      {
         ValidateXmlToParse(xmlToParse);
         Type typeToDeserialize = GetTypeToDeserialize(xmlToParse, typeof(TvShowEpisodeSubtitleResult), typeof(TvShowEpisodeSubtitleResultCached));
         return DeserializeType<ITvShowEpisodeSubtitlesResult>(xmlToParse, typeToDeserialize).TvShowEpisodeSubtitles;
      }

      private static TTypeToReturn DeserializeType<TTypeToReturn>(string xmlToParse, Type typeToDeserialize)
      {
         try
         {
            using (StringReader stringReader = new StringReader(xmlToParse))
            {
               XmlSerializer xs = new XmlSerializer(typeToDeserialize);
               return (TTypeToReturn)xs.Deserialize(stringReader);
            }
         }
         catch (InvalidOperationException error)
         {
            throw new ArgumentException("The given xml is invalid and cannot be parsed.", "xmlToParse", error);
         }
      }

      private static bool IsCachedResult(string xmlToParse)
      {
         int index = xmlToParse.IndexOf("<cached>true</cached>");
         return index != -1 && index != 0;
      }

      private static Type GetTypeToDeserialize(string xmlToParse, Type resultTypeNotCached, Type resultTypeCached)
      {
         return IsCachedResult(xmlToParse) ? resultTypeCached : resultTypeNotCached;
      }

      private static void ValidateXmlToParse(string xmlToParse)
      {
         if (string.IsNullOrEmpty(xmlToParse))
         {
            throw new ArgumentNullException("xmlToParse", "The given xml cannot be null or empty.");
         }
      }
   }
}