namespace GTRL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
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
            
            CreateTable(
                "dbo.Eggs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        posx = c.Single(nullable: false),
                        posy = c.Single(nullable: false),
                        posz = c.Single(nullable: false),
                        rotx = c.Single(nullable: false),
                        roty = c.Single(nullable: false),
                        rotz = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Eggs");
            DropTable("dbo.EggsFound");
        }
    }
}
