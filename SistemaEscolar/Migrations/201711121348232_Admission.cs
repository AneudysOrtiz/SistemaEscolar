namespace SistemaEscolar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Admission : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admissions",
                c => new
                    {
                        AdmissionId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        ActaNacimiento = c.String(),
                        RecordNotas = c.String(),
                        Foto = c.String(),
                        BuenaConducta = c.String(),
                        CartaSaldo = c.String(),
                    })
                .PrimaryKey(t => t.AdmissionId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Admissions");
        }
    }
}
