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
