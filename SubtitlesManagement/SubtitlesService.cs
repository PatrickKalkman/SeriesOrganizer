using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Chalk.SubtitlesManagement
{
   public class SubtitlesService
   {
      private readonly SubtitlesServiceResponseParser parser;

      public SubtitlesService(SubtitlesServiceResponseParser parser)
      {
         this.parser = parser;
      }

      public virtual bool TryGetShowById(int id, out TvShow show)
      {
         IBierdopje bierdopje = CreateBierdopjeChannel();
         var stream = bierdopje.GetShowById(id.ToString());
         XmlSerializer xs = new XmlSerializer(typeof(BierDopje));
         var bierdopjeResult = (BierDopje)xs.Deserialize(stream);
         show = bierdopjeResult.tvShow;
         return show.id != 0;
      }

      public virtual bool TryGetShowByTvDbId(int tvDbId, out TvShow show)
      {
         IBierdopje bierdopje = CreateBierdopjeChannel();
         var stream = bierdopje.GetShowByTvDbId(tvDbId.ToString());
         XmlSerializer xs = new XmlSerializer(typeof(BierDopje));
         var bierdopjeResult = (BierDopje)xs.Deserialize(stream);
         show = bierdopjeResult.tvShow;
         return show.id != 0;
      }


      private static IBierdopje CreateBierdopjeChannel()
      {
         const string Uri = "http://www.bierdopje.com/api/51AFBB7D64B937E1/";
         EndpointAddress address = new EndpointAddress(Uri);
         ServiceEndpoint endPoint = new ServiceEndpoint(ContractDescription.GetContract(typeof(IBierdopje)), new WebHttpBinding(), address);
         endPoint.Behaviors.Add(new WebHttpBehavior());
         ChannelFactory<IBierdopje> factory = new ChannelFactory<IBierdopje>(endPoint);
         return factory.CreateChannel();
      }
   }


}