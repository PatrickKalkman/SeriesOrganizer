using System;
using System.Text.RegularExpressions;
using System.Text;

namespace Chalk.SeriesOrganizer
{
   public class Serie
   {
      private readonly string fileName;

      public static Regex fileNameRegularExpression = new Regex("[a-zA-Z0-9]*.",RegexOptions.CultureInvariant| RegexOptions.Compiled);
      public static Regex seasonRegularExpression = new Regex("[sS]\\d+[eE]+\\d+", RegexOptions.CultureInvariant | RegexOptions.Compiled);
      public static Regex resolutionRegularExpression = new Regex("1080[PpiI]{0,1}|720[Pp]{0,1}", RegexOptions.CultureInvariant| RegexOptions.Compiled);

      private string seasonAndEpisode;

      public Serie(string fileName)
      {
         this.fileName = fileName;
         Parse();
      }

      public int Episode { get; set; }

      public int Season { get; set; }

      public string Name { get; set; }

      public string Resolution { get; set; }

      private void Parse()
      {
         ExtractSeasonAndEpisode();
         ParseSerieName();
         ParseSeasonAndEpisode();
         ExtractResolution();
      }

      private void ExtractResolution()
      {
         Match resolutionMatch = resolutionRegularExpression.Match(fileName);
         if (resolutionMatch.Success)
         {
            Resolution = resolutionMatch.Value.ToLower();
         }
      }

      private void ParseSerieName()
      {
         MatchCollection seriePropertiesCollection = fileNameRegularExpression.Matches(fileName);
         if (seriePropertiesCollection.Count > 0)
         {
            StringBuilder serieName = new StringBuilder();
            foreach (Match match in seriePropertiesCollection)
            {
               string token = match.Value.Replace(".", string.Empty);
               if (token != seasonAndEpisode)
               {
                  serieName.AppendFormat(" {0}", token.Substring(0,1).ToUpper() + token.Substring(1).ToLower());
               }
               else
               {
                  break;
               }
            }
            Name = serieName.ToString().Trim();
         }
      }

      private void ParseSeasonAndEpisode()
      {
         if (!String.IsNullOrEmpty(seasonAndEpisode))
         {
            string[] numbers = seasonAndEpisode.Split(new char[] {'S', 'E'}, StringSplitOptions.RemoveEmptyEntries);
            Episode = Int32.Parse(numbers[1]);
            Season = Int32.Parse(numbers[0]);
         }
      }

      private void ExtractSeasonAndEpisode()
      {
         Match match = seasonRegularExpression.Match(fileName);
         if (match.Success)
         {
            seasonAndEpisode = match.Value;
         }
      }

   }
}