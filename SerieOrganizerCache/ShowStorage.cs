using System;
using Chalk.SubtitlesManagement.Models;
using ShowConversion;
using VDS.RDF;
using VDS.RDF.Parsing;
using VDS.RDF.Query;

namespace ShowOrganizerCacheTest
{
   public class ShowStorage
   {
      private readonly TvShowRdfXmlConverter tvShowRdfXmlConverter;
      private readonly TripleStore tripleStore;

      public ShowStorage(TvShowRdfXmlConverter tvShowRdfXmlConverter, TripleStore tripleStore)
      {
         this.tvShowRdfXmlConverter = tvShowRdfXmlConverter;
         this.tripleStore = tripleStore;
      }

      public virtual bool TryReadShow(string showName, out TvShow show)
      {
         string sparqlQuery = string.Format("PREFIX tv: <http://www.semanticarchitecture.net/tv#> SELECT * WHERE {{?s tv:Name \"{0}\"}}", showName);
         Object results = tripleStore.ExecuteQuery(sparqlQuery);
         if (results is SparqlResultSet)
         {
            
         }
         show = null;
         return true;
      }

      public virtual void Store(TvShow tvShow)
      {
         Graph graph = new Graph();
         StringParser.Parse(graph, tvShowRdfXmlConverter.Convert(tvShow));
         tripleStore.Add(graph);
      }
   }
}