namespace SistemaEscolar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class other : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inscriptions",
                c => new
                    {
                        InscriptionId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.InscriptionId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TeacherId = c.Int(nullable: false),
                        Description = c.String(),
                        Schedule = c.String(),
                        Stock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubjectId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Subjects");
            DropTable("dbo.Inscriptions");
        }
    }
}
