namespace SistemaEscolar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adsfjjadf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admissions", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admissions", "Status");
        }
    }
}
