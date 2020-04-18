namespace JobOffer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _202003191621401_addRole : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.RoleViewModels");
        }
        
        public override void Down()
        {
        }
    }
}
