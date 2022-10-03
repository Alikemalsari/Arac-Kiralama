namespace AracKiralama.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AracBilgileris", "AracResmi", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AracBilgileris", "AracResmi", c => c.String());
        }
    }
}
