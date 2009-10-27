using System;
using System.Xml.Serialization;

namespace Chalk.SubtitlesManagement
{
   [Serializable()]
   public class TvShowEpisodeSubtitle
   {
      [XmlElement("filename")]
      public string fileName;

      [XmlElement("filesize")]
      public int fileSize;

      [XmlElement("uploader")]
      public string uploader;

      [XmlElement("pubdate")]
      public string publicationDate;

      [XmlElement("numreplies")]
      public int numberOfReplies;

      [XmlElement("numdownloads")] 
      public int numberOfDownloads;

      [XmlElement("downloadlink")]
      public string downloadLink;
   }
}
