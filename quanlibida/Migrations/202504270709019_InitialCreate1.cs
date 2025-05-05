namespace quanlibida.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                {
                    BookingID = c.String(nullable: false, maxLength: 128),
                    MaKH = c.Int(nullable: false),
                    BookingTimeStart = c.DateTime(nullable: false),
                    BookingTimeEnd = c.DateTime(nullable: false),
                    MoneyDV = c.Decimal(nullable: false, precision: 18, scale: 2),
                    TableType = c.String(),
                })
                .PrimaryKey(t => t.BookingID);

            CreateTable(
                "dbo.Customer",
                c => new
                {
                    maKH = c.Int(nullable: false, identity: true),
                    hoTen = c.String(maxLength: 100),
                    soDienThoai = c.String(maxLength: 15),
                    diaChi = c.String(maxLength: 200),
                    tienTichLuy = c.Decimal(nullable: false, precision: 18, scale: 2),
                })
                .PrimaryKey(t => t.maKH);

            CreateTable(
                "dbo.DichVus",
                c => new
                {
                    DichVuId = c.Int(nullable: false, identity: true),
                    TenDV = c.String(),
                    LoaiDV = c.String(),
                    GiaTien = c.Decimal(nullable: false, precision: 18, scale: 2),
                })
                .PrimaryKey(t => t.DichVuId);

            CreateTable(
                "dbo.Revenue",
                c => new
                {
                    RevenueID = c.Int(nullable: false, identity: true),
                    RevenueDate = c.DateTime(nullable: false, storeType: "date"),
                    TableRevenue = c.Decimal(nullable: false, precision: 18, scale: 2),
                    FoodRevenue = c.Decimal(nullable: false, precision: 18, scale: 2),
                    DrinkRevenue = c.Decimal(nullable: false, precision: 18, scale: 2),
                })
                .PrimaryKey(t => t.RevenueID);

        }

        public override void Down()
        {
            DropTable("dbo.Revenue");
            DropTable("dbo.DichVus");
            DropTable("dbo.Customer");
            DropTable("dbo.Bookings");
        }
    }
}
