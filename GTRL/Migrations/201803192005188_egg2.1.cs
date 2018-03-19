namespace GTRL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class egg21 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Eggs", "user", c => c.String(nullable: false, maxLength: 255, fixedLength: true, unicode: false, storeType: "char"));
            DropTable("dbo.EggsFound");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EggsFound",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        EggID = c.Int(nullable: false),
                        user = c.String(nullable: false, maxLength: 255, fixedLength: true, unicode: false, storeType: "char"),
                    })
                .PrimaryKey(t => t.id);
            
            DropColumn("dbo.Eggs", "user");
        }
    }
}
