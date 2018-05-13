namespace AbstractShopService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BonusFineBlockZakazchiks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BonusFineBlockId = c.Int(nullable: false),
                        ZakazchikId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BonusFineBlocks", t => t.BonusFineBlockId, cascadeDelete: true)
                .ForeignKey("dbo.Zakazchiks", t => t.ZakazchikId, cascadeDelete: true)
                .Index(t => t.BonusFineBlockId)
                .Index(t => t.ZakazchikId);
            
            CreateTable(
                "dbo.BonusFineBlocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BonusFineBlockName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Zakazchiks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ZakazchikFIO = c.String(nullable: false),
                        Mail = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MessageInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MessageId = c.String(),
                        FromMailAddress = c.String(),
                        Subject = c.String(),
                        Body = c.String(),
                        DateDelivery = c.DateTime(nullable: false),
                        ZakazchikId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Zakazchiks", t => t.ZakazchikId)
                .Index(t => t.ZakazchikId);
            
            CreateTable(
                "dbo.Zakazs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ZakazchikId = c.Int(nullable: false),
                        SectionId = c.Int(nullable: false),
                        RabochiId = c.Int(),
                        Count = c.Int(nullable: false),
                        Sum = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Int(nullable: false),
                        DateCreate = c.DateTime(nullable: false),
                        DateImplement = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rabochis", t => t.RabochiId)
                .ForeignKey("dbo.Sections", t => t.SectionId, cascadeDelete: true)
                .ForeignKey("dbo.Zakazchiks", t => t.ZakazchikId, cascadeDelete: true)
                .Index(t => t.ZakazchikId)
                .Index(t => t.SectionId)
                .Index(t => t.RabochiId);
            
            CreateTable(
                "dbo.Rabochis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RabochiFIO = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SectionName = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SectionPayments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SectionId = c.Int(nullable: false),
                        PaymentId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Payments", t => t.PaymentId, cascadeDelete: true)
                .ForeignKey("dbo.Sections", t => t.SectionId, cascadeDelete: true)
                .Index(t => t.SectionId)
                .Index(t => t.PaymentId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PaymentName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Zakazs", "ZakazchikId", "dbo.Zakazchiks");
            DropForeignKey("dbo.Zakazs", "SectionId", "dbo.Sections");
            DropForeignKey("dbo.SectionPayments", "SectionId", "dbo.Sections");
            DropForeignKey("dbo.SectionPayments", "PaymentId", "dbo.Payments");
            DropForeignKey("dbo.Zakazs", "RabochiId", "dbo.Rabochis");
            DropForeignKey("dbo.MessageInfoes", "ZakazchikId", "dbo.Zakazchiks");
            DropForeignKey("dbo.BonusFineBlockZakazchiks", "ZakazchikId", "dbo.Zakazchiks");
            DropForeignKey("dbo.BonusFineBlockZakazchiks", "BonusFineBlockId", "dbo.BonusFineBlocks");
            DropIndex("dbo.SectionPayments", new[] { "PaymentId" });
            DropIndex("dbo.SectionPayments", new[] { "SectionId" });
            DropIndex("dbo.Zakazs", new[] { "RabochiId" });
            DropIndex("dbo.Zakazs", new[] { "SectionId" });
            DropIndex("dbo.Zakazs", new[] { "ZakazchikId" });
            DropIndex("dbo.MessageInfoes", new[] { "ZakazchikId" });
            DropIndex("dbo.BonusFineBlockZakazchiks", new[] { "ZakazchikId" });
            DropIndex("dbo.BonusFineBlockZakazchiks", new[] { "BonusFineBlockId" });
            DropTable("dbo.Payments");
            DropTable("dbo.SectionPayments");
            DropTable("dbo.Sections");
            DropTable("dbo.Rabochis");
            DropTable("dbo.Zakazs");
            DropTable("dbo.MessageInfoes");
            DropTable("dbo.Zakazchiks");
            DropTable("dbo.BonusFineBlocks");
            DropTable("dbo.BonusFineBlockZakazchiks");
        }
    }
}
