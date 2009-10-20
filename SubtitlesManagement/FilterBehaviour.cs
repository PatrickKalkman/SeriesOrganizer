using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Chalk.SubtitlesManagement
{
   public class FilterBehaviour : IEndpointBehavior
   {
      public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
      {
      }

      public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
      {
         var inspector = new FilterMessageInspector();
         clientRuntime.MessageInspectors.Add(inspector);
      }

      public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
      {
         var inspector = new FilterMessageInspector();
         endpointDispatcher.DispatchRuntime.MessageInspectors.Add(inspector);
      }

      public void Validate(ServiceEndpoint endpoint)
      {
      }
   }
}