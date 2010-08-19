namespace Chalk.ShowOrganizer
{
   public class OrganisationConfigurationReader : XmlConfigurationReaderBase<OrganisationConfigurationType>
   {
      public OrganisationConfigurationReader()
         : base("/etc/", "OrganisationConfiguration.xml")
      {
      }
   }
}
