using System.IO;
using System.Text;
using System.Xml;
using Chalk.SubtitlesManagement.Models;

namespace ShowConversion
{
   /// <summary>
   /// This class is responsible for converting a TvShow into the proper RDF/XML document.
   /// </summary>
   public class TvShowRdfXmlConverter
   {
      private const string TvShowNameSpace = "http://www.semanticarchitecture.net/tv#";
      private const string W3CRdfNameSpace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#";

      public virtual string Convert(TvShow show)
      {
         StringBuilder rdfString = new StringBuilder();
         using (StringWriter stringWriter = new StringWriter(rdfString))
         {
            using (XmlWriter textWriter = XmlWriter.Create(stringWriter, CreateXmlWriteSettings()))
            {
               textWriter.WriteProcessingInstruction("xml", "version=\"1.0\"");
               textWriter.WriteStartElement("rdf", "RDF", W3CRdfNameSpace);
               textWriter.WriteAttributeString("xmlns", "rdf", null, W3CRdfNameSpace);
               textWriter.WriteAttributeString("xmlns", "tv", null, TvShowNameSpace);
               textWriter.WriteStartElement("tv", "Show", TvShowNameSpace);
               string showUri = string.Format("http://www.semanticarchitecture.net/TvShow.rdf@TvShow{0}", show.id);
               textWriter.WriteAttributeString("rdf", "about", null, showUri);
               
               WriteTvElement(textWriter, "AirTime", show.airTime);
               WriteTvElement(textWriter, "Favorites", show.favorites.ToString());
               WriteTvElement(textWriter, "FirstAired", show.firstAired);

               WriteTvShowGenres(textWriter, show);

               WriteTvElement(textWriter, "HasTranslators", show.hasTranslators.ToString());
               WriteTvElement(textWriter, "Id", show.id.ToString());
               WriteTvElement(textWriter, "IsValid", show.IsValid.ToString());
               WriteTvElement(textWriter, "LastAired", show.lastAired);
               WriteTvElement(textWriter, "Network", show.network);
               WriteTvElement(textWriter, "NextEpisode", show.nextEpisode);
               WriteTvElement(textWriter, "NumberOfEpisodes", show.numberOfEpisodes.ToString());
               WriteTvElement(textWriter, "Runtime", show.runTime.ToString());
               WriteTvElement(textWriter, "Score", show.score);
               WriteTvElement(textWriter, "Season", show.season);
               WriteTvElement(textWriter, "Link", show.showLink);
               WriteTvElement(textWriter, "ShowStatus", show.showStatus);
               WriteTvElement(textWriter, "Status", show.status);
               WriteTvElement(textWriter, "Summary", show.summary);
               WriteTvElement(textWriter, "Name", show.showName);
               WriteTvElement(textWriter, "TvDbId", show.tvDbId.ToString());
               
               textWriter.WriteEndElement();
               
               textWriter.WriteEndElement();
               textWriter.Flush();
               return rdfString.ToString();
            }
         }
      }

      private static void WriteTvShowGenres(XmlWriter textWriter, TvShowBase show)
      {
          if (show.Genres != null)
          {
              foreach (string genre in show.Genres)
              {
                  WriteTvElement(textWriter, "Genre", genre);
              }
          }
      }

      private static XmlWriterSettings CreateXmlWriteSettings()
      {
         XmlWriterSettings writerSettings = new XmlWriterSettings();
         writerSettings.Indent = true;
         writerSettings.IndentChars = "   ";
         writerSettings.NewLineChars = "\r\n";
         return writerSettings;
      }

      private static void WriteTvElement(XmlWriter textWriter, string elementName, string value)
      {
         textWriter.WriteStartElement("tv", elementName, TvShowNameSpace );
         textWriter.WriteString(value);
         textWriter.WriteEndElement();
      }
   }
}
