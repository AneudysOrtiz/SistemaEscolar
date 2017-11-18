namespace SistemaEscolar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rols",
                c => new
                    {
                        RolId = c.Int(nullable: false, identity: true),
                        RolName = c.String(),
                        RolCode = c.String(),
                    })
                .PrimaryKey(t => t.RolId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                        LastName = c.String(maxLength: 30),
                        Picture = c.String(),
                        Sexo = c.String(maxLength: 30),
                        Telefono = c.String(maxLength: 30),
                        Direccion = c.String(),
                        RolId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Rols", t => t.RolId, cascadeDelete: true)
                .Index(t => t.RolId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RolId", "dbo.Rols");
            DropIndex("dbo.Users", new[] { "RolId" });
            DropTable("dbo.Users");
            DropTable("dbo.Rols");
        }
    }
}
