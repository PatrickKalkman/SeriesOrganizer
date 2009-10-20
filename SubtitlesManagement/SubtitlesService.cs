using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;

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
         try
         {
            ICollection<BindingElement> bindingElements = new List<BindingElement>();
            HttpTransportBindingElement httpBindingElement = new HttpTransportBindingElement();
            CustomTextMessageBindingElement textBindingElement = new CustomTextMessageBindingElement();
            bindingElements.Add(textBindingElement);
            bindingElements.Add(httpBindingElement);
            CustomBinding binding = new CustomBinding(bindingElements);

            const string Uri = "http://www.bierdopje.com/api/51AFBB7D64B937E1";
            EndpointAddress address = new EndpointAddress(Uri);
            ServiceEndpoint endPoint = new ServiceEndpoint(ContractDescription.GetContract(typeof(IBierdopje)), binding, address);
            //endPoint.Behaviors.Add(new WebHttpBehavior());
            endPoint.Behaviors.Add(new FilterBehaviour());


            ChannelFactory<IBierdopje> factory = new ChannelFactory<IBierdopje>(endPoint);
            IBierdopje bierdopje = factory.CreateChannel();
            var doc = bierdopje.GetShowById(id.ToString());
           
            show = null;
            return true;
         }
         catch (Exception error)
         {
            Console.WriteLine(error);
         }
         show = null;
         return false;
      }


   }

}