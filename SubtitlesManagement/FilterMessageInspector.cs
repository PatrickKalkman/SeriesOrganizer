using System;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Xml;

namespace Chalk.SubtitlesManagement
{
   public class FilterMessageInspector : IClientMessageInspector, IDispatchMessageInspector
   {
      private const string CultureHeaderKey = "culture";

      #region IDispatchMessageInspector Members

      public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
      {
         int headerIndex = request.Headers.FindHeader(CultureHeaderKey, string.Empty);
         if (headerIndex != -1)
         {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(request.Headers.GetHeader<string>(headerIndex));
         }

         return null;
      }

      public void BeforeSendReply(ref Message reply, object correlationState)
      {

      }

      #endregion

      #region IClientMessageInspector Members

      public void AfterReceiveReply(ref Message reply, object correlationState)
      {
         MessageBuffer buffer = reply.CreateBufferedCopy(int.MaxValue);
         
         MemoryStream stream = new MemoryStream();
         buffer.WriteMessage(stream);
         string payLoad = GetStringFromMemoryStream(stream);

         int i = 10;
      }

      public static string GetStringFromMemoryStream(MemoryStream m)
      {
         if (m == null || m.Length == 0)
            return null;

         m.Flush();
         m.Position = 0;
         StreamReader sr = new StreamReader(m);
         string s = sr.ReadToEnd();

         return s;
      }


      public object BeforeSendRequest(ref Message request, IClientChannel channel)
      {
         return null;
      }

      #endregion
   }
}