using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chalk.SerieOrganizer
{
   public class OrganisationConfigurationReader : XmlConfigurationReaderBase<OrganisationConfigurationType>
   {
      public OrganisationConfigurationReader()
         : base("/etc/", "OrganisationConfiguration.xml")
      {
      }
   }
}
