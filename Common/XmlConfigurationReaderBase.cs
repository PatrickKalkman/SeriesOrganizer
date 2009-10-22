using System;
using System.IO;
using System.Xml.Serialization;

namespace Chalk.Common
{
   /// <summary>
   /// This class acts as a base class for reading XML configuration files.
   /// </summary>
   /// <typeparam name="TDeserializedObject">The type of object to deserialize.</typeparam>
   public class XmlConfigurationReaderBase<TDeserializedObject> where TDeserializedObject : class
   {
      private readonly string folder;
      private readonly string xmlFileName;

      public XmlConfigurationReaderBase(string controlBoxFolder, string xmlFileName)
         : this(controlBoxFolder, xmlFileName, null, string.Empty)
      {
      }

      public XmlConfigurationReaderBase(string folder, string xmlFileName, Type schemaTypeInAssembly, string embeddedResourceNameSchema)
      {
         this.folder = folder;
         this.xmlFileName = xmlFileName;
      }

      public virtual TDeserializedObject Read()
      {
         var fullPath = Path.Combine(folder, xmlFileName);
         if (File.Exists(fullPath))
         {
            using (var streamReader = new StreamReader(fullPath))
            {
               var xmlSerializer = new XmlSerializer(typeof(TDeserializedObject));
               var deserializedObjectType = (TDeserializedObject)xmlSerializer.Deserialize(streamReader);
               return deserializedObjectType;
            }
         }
         return null;
      }
   }
}