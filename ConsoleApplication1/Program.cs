using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chalk.SubtitlesManagement;

namespace ConsoleApplication1
{
   class Program
   {
      static void Main(string[] args)
      {
         SubtitlesService service = new SubtitlesService(new SubtitlesServiceResponseParser());
         TvShow tvShow;
         bool result = service.TryGetShowById(12934, out tvShow);
      }
   }
}
