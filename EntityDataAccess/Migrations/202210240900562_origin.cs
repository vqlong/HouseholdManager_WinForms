namespace EntityDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class origin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 50),
                        DisplayName = c.String(nullable: false, maxLength: 50, defaultValueSql: "N'Cán bộ'"),
                        Password = c.String(nullable: false, defaultValue: "952362351022552001115621782120108109105108121194219194572217814518010341215583925187233"),
                        Type = c.Long(nullable: false, defaultValue: 0),
                        Note = c.String(nullable: false, defaultValueSql: "N'Ghi chú...'"),
                        Setting = c.String(nullable: false, defaultValue: ""),
                    })
                .PrimaryKey(t => t.Username);
            
            CreateTable(
                "dbo.DonateInfoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        HouseholdID = c.Int(nullable: false),
                        DonateID = c.Int(nullable: false),
                        DateContribute = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        Value = c.Double(nullable: false, defaultValue: 1000),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Donates", t => t.DonateID, cascadeDelete: true)
                .ForeignKey("dbo.Households", t => t.HouseholdID, cascadeDelete: true)
                .Index(t => t.HouseholdID)
                .Index(t => t.DonateID);
            
            CreateTable(
                "dbo.Donates",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, defaultValueSql: "N'Đóng góp phong trào abc'"),
                        DateArise = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        MinValue = c.Double(nullable: false, defaultValue: 1000),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Households",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Owner = c.String(nullable: false, maxLength: 50, defaultValueSql: "N'Chủ hộ'"),
                        Address = c.String(nullable: false, maxLength: 50, defaultValueSql: "N'Địa chỉ'"),
                        MemberCount = c.Int(nullable: false, defaultValue: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FeeInfoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        HouseholdID = c.Int(nullable: false),
                        FeeID = c.Int(nullable: false),
                        DatePay = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        Value = c.Double(nullable: false, defaultValue: 1000),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Fees", t => t.FeeID, cascadeDelete: true)
                .ForeignKey("dbo.Households", t => t.HouseholdID, cascadeDelete: true)
                .Index(t => t.HouseholdID)
                .Index(t => t.FeeID);
            
            CreateTable(
                "dbo.Fees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, defaultValueSql: "N'Đóng tiền abc ngày x tháng y năm z'"),
                        DateArise = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        Value = c.Double(nullable: false, defaultValue: 1000),
                        Factor = c.Int(nullable: false, defaultValue: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, defaultValueSql: "N'Họ tên'"),
                        Gender = c.Int(nullable: false, defaultValue: 1),
                        DateOfBirth = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        Cmnd = c.String(nullable: false, maxLength: 12, defaultValue: "123456789"),
                        Address = c.String(nullable: false, maxLength: 50, defaultValueSql: "N'Địa chỉ'"),
                        HouseholdID = c.Int(nullable: false, defaultValue: 1),
                        Relation = c.Int(nullable: false, defaultValue: 12),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Households", t => t.HouseholdID, cascadeDelete: true)
                .Index(t => t.HouseholdID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DonateInfoes", "HouseholdID", "dbo.Households");
            DropForeignKey("dbo.People", "HouseholdID", "dbo.Households");
            DropForeignKey("dbo.FeeInfoes", "HouseholdID", "dbo.Households");
            DropForeignKey("dbo.FeeInfoes", "FeeID", "dbo.Fees");
            DropForeignKey("dbo.DonateInfoes", "DonateID", "dbo.Donates");
            DropIndex("dbo.People", new[] { "HouseholdID" });
            DropIndex("dbo.FeeInfoes", new[] { "FeeID" });
            DropIndex("dbo.FeeInfoes", new[] { "HouseholdID" });
            DropIndex("dbo.DonateInfoes", new[] { "DonateID" });
            DropIndex("dbo.DonateInfoes", new[] { "HouseholdID" });
            DropTable("dbo.People");
            DropTable("dbo.Fees");
            DropTable("dbo.FeeInfoes");
            DropTable("dbo.Households");
            DropTable("dbo.Donates");
            DropTable("dbo.DonateInfoes");
            DropTable("dbo.Accounts");
        }
    }
}
