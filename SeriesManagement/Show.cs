using System;
using System.Text.RegularExpressions;
using System.Text;
using System.IO;

namespace Chalk.ShowOrganizer
{
   public class Show
   {
      private readonly string fileName;
      private readonly string fullName;

      public static Regex fileNameRegularExpression = new Regex("[a-zA-Z0-9]*.|[a-zA-Z0-9]*-", RegexOptions.CultureInvariant | RegexOptions.Compiled);
      public static Regex seasonRegularExpression = new Regex("[sS]\\d+[eE]+\\d+", RegexOptions.CultureInvariant | RegexOptions.Compiled);
      public static Regex minimalSeasonRegularExpression = new Regex("[.]\\d+[.]", RegexOptions.CultureInvariant | RegexOptions.Compiled);
      public static Regex resolutionRegularExpression = new Regex("1080[PpiI]{0,1}|720[Pp]{0,1}", RegexOptions.CultureInvariant | RegexOptions.Compiled);

      private string seasonAndEpisode;

      public Show(string fileName)
      {
         this.fullName = fileName;
         this.fileName = Path.GetFileName(fileName);
         Parse();
      }

      public virtual string FullName
      {
         get { return fullName; }
      }

      public virtual string FileName
      {
         get { return fileName; }  
      }

      public int Episode { get; set; }

      public int Season { get; set; }

      public virtual string Name { get; set; }

      public string Resolution { get; set; }

      public virtual bool IsValid
      {
         get 
         {
            return !string.IsNullOrEmpty(Name) && Episode != 0;
         }
      }

      private void Parse()
      {
         ExtractSeasonAndEpisode();
         ParseShowName();
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

      private void ParseShowName()
      {
         MatchCollection ShowPropertiesCollection = fileNameRegularExpression.Matches(fileName);
         if (ShowPropertiesCollection.Count > 0)
         {
            StringBuilder ShowName = new StringBuilder();
            foreach (Match match in ShowPropertiesCollection)
            {
               string token = match.Value.Replace(".", string.Empty);
               if (!IsSeasonAndEpisode(token) && !string.IsNullOrEmpty(token)) 
               {
                  ShowName.AppendFormat(" {0}", token.Substring(0, 1).ToUpper() + token.Substring(1).ToLower());
               }
               else
               {
                  break;
               }
            }
            Name = ShowName.ToString().Trim();
         }
      }

      private bool IsSeasonAndEpisode(string token)
      {
         if (!string.IsNullOrEmpty(seasonAndEpisode))
         {
            if (token == seasonAndEpisode || seasonAndEpisode.Contains(token))
               return true;

            int smallSeasonAndEpisode;
            if (Int32.TryParse(seasonAndEpisode.Replace("S", string.Empty).Replace("E", string.Empty),
                               out smallSeasonAndEpisode))
            {
               int smallSeasonAndEpisodeFromToken;
               if (Int32.TryParse(token, out smallSeasonAndEpisodeFromToken))
               {
                  return smallSeasonAndEpisode == smallSeasonAndEpisodeFromToken;
               }
            }
         }
         return false;
      }

      private void ParseSeasonAndEpisode()
      {
         if (!String.IsNullOrEmpty(seasonAndEpisode))
         {
            string[] numbers = seasonAndEpisode.ToUpper().Split(new char[] { 'S', 'E' }, StringSplitOptions.RemoveEmptyEntries);
            if (numbers.Length > 1)
            {
               Episode = Int32.Parse(numbers[1]);
               Season = Int32.Parse(numbers[0]);
            }
            if (numbers.Length == 1)
            {
               string seasonAndEpisodeString = numbers[0].Replace(".", string.Empty);
               Season = Int32.Parse(seasonAndEpisodeString.Substring(0, 1));
               Episode = Int32.Parse(seasonAndEpisodeString.Substring(1));
            }
         }
      }

      private void ExtractSeasonAndEpisode()
      {
         Match match = seasonRegularExpression.Match(fileName);
         if (match.Success)
         {
            seasonAndEpisode = match.Value;
         }
         else
         {
            match = seasonRegularExpression.Match(fullName);
            if (match.Success)
            {
               seasonAndEpisode = match.Value;
            }
            else
            {
               match = minimalSeasonRegularExpression.Match(fileName);
               if (match.Success)
               {
                  seasonAndEpisode = match.Value;
               }
            }
         }
      }
   }
}