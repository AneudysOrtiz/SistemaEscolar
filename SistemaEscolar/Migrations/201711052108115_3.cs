namespace SistemaEscolar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "RolId", "dbo.Rols");
            DropIndex("dbo.Users", new[] { "RolId" });
            AddColumn("dbo.Users", "Rol", c => c.String(nullable: false));
            DropColumn("dbo.Users", "RolId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "RolId", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "Rol");
            CreateIndex("dbo.Users", "RolId");
            AddForeignKey("dbo.Users", "RolId", "dbo.Rols", "RolId", cascadeDelete: true);
        }
    }
}
