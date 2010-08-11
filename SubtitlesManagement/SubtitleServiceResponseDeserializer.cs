using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Chalk.SubtitlesManagement.Models;

namespace Chalk.SubtitlesManagement
{
   /// <summary>
   /// This class is responsible for deserializing the types from the xml response
   /// from the subtitles service.
   /// </summary>
   internal class SubtitleServiceResponseDeserializer
   {
      internal TvShowBase GetTvShow(string xmlToParse)
      {
         ValidateXmlToParse(xmlToParse);
         return DeserializeType<ISingleTvShowResult>(xmlToParse, typeof(SingleTvShowResult)).TvShow;
      }

      internal virtual List<TvShow> GetTvShows(string xmlToParse)
      {
         ValidateXmlToParse(xmlToParse);
         return DeserializeType<ITvShowResult>(xmlToParse, typeof(FindByNamesResult)).TvShows;
      }

      internal TvShowEpisode GetTvShowEpisode(string xmlToParse)
      {
         ValidateXmlToParse(xmlToParse);
         return DeserializeType<ITvShowEpisode>(xmlToParse, typeof(SingleTvShowEpisodeResult)).Episode;
      }

      internal List<TvShowEpisode> GetTvShowEpisodes(string xmlToParse)
      {
         ValidateXmlToParse(xmlToParse);
         return DeserializeType<ITvEpisodes>(xmlToParse, typeof(TvShowEpisodeResult)).TvEpisodes;
      }

      internal List<TvShowEpisodeSubtitle> GetTvShowEpisodeSubtitles(string xmlToParse)
      {
         ValidateXmlToParse(xmlToParse);
         return DeserializeType<ITvShowEpisodeSubtitlesResult>(xmlToParse, typeof(TvShowEpisodeSubtitleResult)).TvShowEpisodeSubtitles;
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

      private static void ValidateXmlToParse(string xmlToParse)
      {
         if (string.IsNullOrEmpty(xmlToParse))
         {
            throw new ArgumentNullException("xmlToParse", "The given xml cannot be null or empty.");
         }
      }
   }
}