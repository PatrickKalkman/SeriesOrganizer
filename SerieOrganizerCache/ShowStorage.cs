using System;
using Chalk.SubtitlesManagement.Models;
using VDS.RDF;
using VDS.RDF.Query;

namespace ShowOrganizerCacheTest
{
   public class ShowStorage
   {
      private readonly TripleStore tripleStore;

      public ShowStorage(TripleStore tripleStore)
      {
         this.tripleStore = tripleStore;
      }

      public virtual bool TryReadShow(string showName, out TvShow show)
      {
         Object results = tripleStore.ExecuteQuery("SELECT * WHERE {?s ?p ?o}");
         if (results is SparqlResultSet)
         {
            
         }
         show = null;
         return true;
      }

      public virtual void Store(TvShow show)
      {
         Graph graph = new Graph();
         UriNode tvShowNode = graph.CreateUriNode(new Uri("http://tvshow"));
         UriNode tvShowName = graph.CreateUriNode(new Uri("http://example.org/name"));
         LiteralNode flashForwardNode = graph.CreateLiteralNode("FlashForward");
         graph.Assert(new Triple(tvShowNode, tvShowName, flashForwardNode));

         tripleStore.Add(graph);
      }
   }
}