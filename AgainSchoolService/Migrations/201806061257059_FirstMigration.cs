namespace IvanAgencyService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdminFIO = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        EntryId = c.Int(nullable: false),
                        AdminId = c.Int(),
                        Hour = c.Int(nullable: false),
                        Summa = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Oplata = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BonusFine = c.Int(nullable: false),
                        Status = c.String(),
                        DateOfCreate = c.DateTime(nullable: false),
                        DateOfImplement = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Admins", t => t.AdminId)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Entries", t => t.EntryId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.EntryId)
                .Index(t => t.AdminId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientFIO = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Mail = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Entries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntryName = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EntrySections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntryId = c.Int(nullable: false),
                        SectionId = c.Int(nullable: false),
                        SectionPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entries", t => t.EntryId, cascadeDelete: true)
                .ForeignKey("dbo.Sections", t => t.SectionId, cascadeDelete: true)
                .Index(t => t.EntryId)
                .Index(t => t.SectionId);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SectionName = c.String(nullable: false),
                        PriceSection = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "EntryId", "dbo.Entries");
            DropForeignKey("dbo.EntrySections", "SectionId", "dbo.Sections");
            DropForeignKey("dbo.EntrySections", "EntryId", "dbo.Entries");
            DropForeignKey("dbo.Orders", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Orders", "AdminId", "dbo.Admins");
            DropIndex("dbo.EntrySections", new[] { "SectionId" });
            DropIndex("dbo.EntrySections", new[] { "EntryId" });
            DropIndex("dbo.Orders", new[] { "AdminId" });
            DropIndex("dbo.Orders", new[] { "EntryId" });
            DropIndex("dbo.Orders", new[] { "ClientId" });
            DropTable("dbo.Sections");
            DropTable("dbo.EntrySections");
            DropTable("dbo.Entries");
            DropTable("dbo.Clients");
            DropTable("dbo.Orders");
            DropTable("dbo.Admins");
        }
    }
}
