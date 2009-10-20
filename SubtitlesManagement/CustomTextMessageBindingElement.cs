using System;
using System.ServiceModel.Channels;

namespace Chalk.SubtitlesManagement
{
   class CustomTextMessageBindingElement : MessageEncodingBindingElement
   {
      public override BindingElement Clone()
      {
         return this;
      }

      public override MessageEncoderFactory CreateMessageEncoderFactory()
      {
         return new CustomTextMessageEncoderFactory("text/xml", "iso-8859-1", this.MessageVersion);
      }

      public override MessageVersion MessageVersion
      {
         get { return MessageVersion.Soap12WSAddressing10; }
         set { throw new NotImplementedException(); }
      }
   }
}
