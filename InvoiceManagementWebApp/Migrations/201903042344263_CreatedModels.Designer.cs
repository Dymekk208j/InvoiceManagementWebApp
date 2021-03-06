namespace InvoiceManagementWebApp.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.2.0-61023")]
    public sealed partial class CreatedModels : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(CreatedModels));
        
        string IMigrationMetadata.Id
        {
            get { return "201903042344263_CreatedModels"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}
