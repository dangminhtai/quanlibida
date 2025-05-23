
USE [QUANLYBIDA]

GO
/****** Object:  Table [dbo].[Booking]    Script Date: 3/17/2025 1:09:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[BookingID] [varchar](50) NOT NULL,
	[maKH] [int] NOT NULL,
	[BookingTimeStart] [datetime] NOT NULL,
	[BookingTimeEnd] [datetime] NULL,
	[MoneyDV] [decimal](18, 2) NULL,
	[TableType] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[BookingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[customer]    Script Date: 3/17/2025 1:09:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customer](
	[maKH] [int] NOT NULL,
	[hoTen] [nvarchar](100) NOT NULL,
	[soDienThoai] [varchar](15) NOT NULL,
	[diaChi] [nvarchar](255) NULL,
	[tienTichLuy] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[maKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DichVu]    Script Date: 3/17/2025 1:09:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DichVu](
	[TenDV] [nvarchar](100) NOT NULL,
	[LoaiDV] [nvarchar](50) NOT NULL,
	[GiaTien] [decimal](10, 2) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Revenue]    Script Date: 3/17/2025 1:09:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Revenue](
	[RevenueID] [int] NOT NULL,
	[RevenueDate] [date] NOT NULL,
	[TableRevenue] [decimal](10, 2) NOT NULL,
	[FoodRevenue] [decimal](10, 2) NOT NULL,
	[DrinkRevenue] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RevenueID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 3/17/2025 1:09:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[MaNV] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Salary] [decimal](18, 2) NOT NULL,
	[Enter] [date] NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Booking] ([BookingID], [maKH], [BookingTimeStart], [BookingTimeEnd], [MoneyDV], [TableType]) VALUES (N'B001', 1, CAST(N'2024-03-15T18:00:00.000' AS DateTime), CAST(N'2024-03-15T20:00:00.000' AS DateTime), CAST(51000.00 AS Decimal(18, 2)), N'Dragon')
INSERT [dbo].[Booking] ([BookingID], [maKH], [BookingTimeStart], [BookingTimeEnd], [MoneyDV], [TableType]) VALUES (N'B002', 2, CAST(N'2024-03-16T19:30:00.000' AS DateTime), CAST(N'2024-03-16T21:00:00.000' AS DateTime), CAST(75000.00 AS Decimal(18, 2)), N'MrSung')
INSERT [dbo].[Booking] ([BookingID], [maKH], [BookingTimeStart], [BookingTimeEnd], [MoneyDV], [TableType]) VALUES (N'B003', 3, CAST(N'2024-03-17T17:45:00.000' AS DateTime), CAST(N'2024-03-17T19:30:00.000' AS DateTime), CAST(60000.00 AS Decimal(18, 2)), N'KKKing')
INSERT [dbo].[Booking] ([BookingID], [maKH], [BookingTimeStart], [BookingTimeEnd], [MoneyDV], [TableType]) VALUES (N'B004', 4, CAST(N'2024-03-18T20:15:00.000' AS DateTime), CAST(N'2024-03-18T21:15:00.000' AS DateTime), CAST(100000.00 AS Decimal(18, 2)), N'Dragon')
INSERT [dbo].[Booking] ([BookingID], [maKH], [BookingTimeStart], [BookingTimeEnd], [MoneyDV], [TableType]) VALUES (N'B005', 5, CAST(N'2024-03-19T12:30:00.000' AS DateTime), CAST(N'2024-03-19T14:00:00.000' AS DateTime), CAST(20000.00 AS Decimal(18, 2)), N'MrSung')
INSERT [dbo].[Booking] ([BookingID], [maKH], [BookingTimeStart], [BookingTimeEnd], [MoneyDV], [TableType]) VALUES (N'B006', 6, CAST(N'2024-03-20T18:45:00.000' AS DateTime), CAST(N'2024-03-20T21:15:00.000' AS DateTime), CAST(90000.00 AS Decimal(18, 2)), N'KKKing')
INSERT [dbo].[Booking] ([BookingID], [maKH], [BookingTimeStart], [BookingTimeEnd], [MoneyDV], [TableType]) VALUES (N'B007', 7, CAST(N'2024-03-21T16:00:00.000' AS DateTime), CAST(N'2024-03-21T18:00:00.000' AS DateTime), CAST(45000.00 AS Decimal(18, 2)), N'Dragon')
INSERT [dbo].[Booking] ([BookingID], [maKH], [BookingTimeStart], [BookingTimeEnd], [MoneyDV], [TableType]) VALUES (N'B008', 8, CAST(N'2024-03-22T19:00:00.000' AS DateTime), CAST(N'2024-03-22T22:00:00.000' AS DateTime), CAST(120000.00 AS Decimal(18, 2)), N'MrSung')
INSERT [dbo].[Booking] ([BookingID], [maKH], [BookingTimeStart], [BookingTimeEnd], [MoneyDV], [TableType]) VALUES (N'B009', 9, CAST(N'2024-03-23T13:15:00.000' AS DateTime), CAST(N'2024-03-23T15:00:00.000' AS DateTime), CAST(30000.00 AS Decimal(18, 2)), N'KKKing')
INSERT [dbo].[Booking] ([BookingID], [maKH], [BookingTimeStart], [BookingTimeEnd], [MoneyDV], [TableType]) VALUES (N'B010', 10, CAST(N'2024-03-24T21:15:00.000' AS DateTime), CAST(N'2024-03-24T22:15:00.000' AS DateTime), CAST(50000.00 AS Decimal(18, 2)), N'KKKing')
GO
INSERT [dbo].[customer] ([maKH], [hoTen], [soDienThoai], [diaChi], [tienTichLuy]) VALUES (1, N'Nguyễn Văn Anh', N'0987654321', N'123 Lê Lợi, TP HCM', CAST(500000.00 AS Decimal(10, 2)))
INSERT [dbo].[customer] ([maKH], [hoTen], [soDienThoai], [diaChi], [tienTichLuy]) VALUES (2, N'Trần Thị Bích', N'0912345678', N'45 Nguyễn Trãi, Hà Nội', CAST(250000.00 AS Decimal(10, 2)))
INSERT [dbo].[customer] ([maKH], [hoTen], [soDienThoai], [diaChi], [tienTichLuy]) VALUES (3, N'Lê Hoàng Cường', N'0909123456', N'78 Hai Bà Trưng, Đà Nẵng', CAST(380000.00 AS Decimal(10, 2)))
INSERT [dbo].[customer] ([maKH], [hoTen], [soDienThoai], [diaChi], [tienTichLuy]) VALUES (4, N'Phạm Văn Dũng', N'0968989898', N'56 Trần Hưng Đạo, Cần Thơ', CAST(750000.00 AS Decimal(10, 2)))
INSERT [dbo].[customer] ([maKH], [hoTen], [soDienThoai], [diaChi], [tienTichLuy]) VALUES (5, N'Đoàn Thị Em', N'0977777777', N'32 Cách Mạng Tháng 8, Huế', CAST(120000.00 AS Decimal(10, 2)))
INSERT [dbo].[customer] ([maKH], [hoTen], [soDienThoai], [diaChi], [tienTichLuy]) VALUES (6, N'Võ Minh Phát', N'0933333333', N'90 Phan Chu Trinh, Bình Dương', CAST(680000.00 AS Decimal(10, 2)))
INSERT [dbo].[customer] ([maKH], [hoTen], [soDienThoai], [diaChi], [tienTichLuy]) VALUES (7, N'Bùi Hồng Quân', N'0955555555', N'11 Lý Thường Kiệt, Hải Phòng', CAST(300000.00 AS Decimal(10, 2)))
INSERT [dbo].[customer] ([maKH], [hoTen], [soDienThoai], [diaChi], [tienTichLuy]) VALUES (8, N'Hoàng Nam Khánh', N'0944444444', N'77 Võ Văn Kiệt, Đà Lạt', CAST(450000.00 AS Decimal(10, 2)))
INSERT [dbo].[customer] ([maKH], [hoTen], [soDienThoai], [diaChi], [tienTichLuy]) VALUES (9, N'Nguyễn Tuấn Kiệt', N'0922222222', N'22 Lê Hồng Phong, Quảng Ngãi', CAST(275000.00 AS Decimal(10, 2)))
INSERT [dbo].[customer] ([maKH], [hoTen], [soDienThoai], [diaChi], [tienTichLuy]) VALUES (10, N'Phạm Gia Huy', N'0911111111', N'88 Trường Chinh, Vũng Tàu', CAST(180000.00 AS Decimal(10, 2)))
INSERT [dbo].[customer] ([maKH], [hoTen], [soDienThoai], [diaChi], [tienTichLuy]) VALUES (11, N'Đặng Minh Tài', N'0333078554', N'số 1, Võ Văn Ngân', CAST(323456.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[DichVu] ([TenDV], [LoaiDV], [GiaTien]) VALUES (N'Khoai tây chiên', N'Thức Ăn', CAST(15000.00 AS Decimal(10, 2)))
INSERT [dbo].[DichVu] ([TenDV], [LoaiDV], [GiaTien]) VALUES (N'Xúc xích Đức', N'Thức Ăn', CAST(30000.00 AS Decimal(10, 2)))
INSERT [dbo].[DichVu] ([TenDV], [LoaiDV], [GiaTien]) VALUES (N'Cá viên chiên', N'Thức Ăn', CAST(20000.00 AS Decimal(10, 2)))
INSERT [dbo].[DichVu] ([TenDV], [LoaiDV], [GiaTien]) VALUES (N'Mì xông khói', N'Thức Ăn', CAST(35000.00 AS Decimal(10, 2)))
INSERT [dbo].[DichVu] ([TenDV], [LoaiDV], [GiaTien]) VALUES (N'Nước ngọt Coca', N'Thức Uống', CAST(15000.00 AS Decimal(10, 2)))
INSERT [dbo].[DichVu] ([TenDV], [LoaiDV], [GiaTien]) VALUES (N'Nước ngọt Pepsi', N'Thức Uống', CAST(25000.00 AS Decimal(10, 2)))
INSERT [dbo].[DichVu] ([TenDV], [LoaiDV], [GiaTien]) VALUES (N'Cà phê đen', N'Thức Uống', CAST(20000.00 AS Decimal(10, 2)))
INSERT [dbo].[DichVu] ([TenDV], [LoaiDV], [GiaTien]) VALUES (N'Cà phê sữa', N'Thức Uống', CAST(25000.00 AS Decimal(10, 2)))
INSERT [dbo].[DichVu] ([TenDV], [LoaiDV], [GiaTien]) VALUES (N'Trà chanh', N'Thức Uống', CAST(18000.00 AS Decimal(10, 2)))
INSERT [dbo].[DichVu] ([TenDV], [LoaiDV], [GiaTien]) VALUES (N'Bia Heineken', N'Thức Uống', CAST(35000.00 AS Decimal(10, 2)))
INSERT [dbo].[DichVu] ([TenDV], [LoaiDV], [GiaTien]) VALUES (N'Bia Tiger', N'Thức Uống', CAST(30000.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[Revenue] ([RevenueID], [RevenueDate], [TableRevenue], [FoodRevenue], [DrinkRevenue]) VALUES (1, CAST(N'2024-03-10' AS Date), CAST(5000000.00 AS Decimal(10, 2)), CAST(1500000.00 AS Decimal(10, 2)), CAST(1000000.00 AS Decimal(10, 2)))
INSERT [dbo].[Revenue] ([RevenueID], [RevenueDate], [TableRevenue], [FoodRevenue], [DrinkRevenue]) VALUES (2, CAST(N'2025-03-11' AS Date), CAST(7500000.00 AS Decimal(10, 2)), CAST(2500000.00 AS Decimal(10, 2)), CAST(1500000.00 AS Decimal(10, 2)))
INSERT [dbo].[Revenue] ([RevenueID], [RevenueDate], [TableRevenue], [FoodRevenue], [DrinkRevenue]) VALUES (3, CAST(N'2025-03-12' AS Date), CAST(9000000.00 AS Decimal(10, 2)), CAST(3500000.00 AS Decimal(10, 2)), CAST(1000000.00 AS Decimal(10, 2)))
INSERT [dbo].[Revenue] ([RevenueID], [RevenueDate], [TableRevenue], [FoodRevenue], [DrinkRevenue]) VALUES (4, CAST(N'2025-03-13' AS Date), CAST(7800000.00 AS Decimal(10, 2)), CAST(2800000.00 AS Decimal(10, 2)), CAST(1900000.00 AS Decimal(10, 2)))
INSERT [dbo].[Revenue] ([RevenueID], [RevenueDate], [TableRevenue], [FoodRevenue], [DrinkRevenue]) VALUES (5, CAST(N'2025-03-14' AS Date), CAST(6700000.00 AS Decimal(10, 2)), CAST(1850000.00 AS Decimal(10, 2)), CAST(1700000.00 AS Decimal(10, 2)))
INSERT [dbo].[Revenue] ([RevenueID], [RevenueDate], [TableRevenue], [FoodRevenue], [DrinkRevenue]) VALUES (6, CAST(N'2025-03-15' AS Date), CAST(7500000.00 AS Decimal(10, 2)), CAST(2500000.00 AS Decimal(10, 2)), CAST(1500000.00 AS Decimal(10, 2)))
INSERT [dbo].[Revenue] ([RevenueID], [RevenueDate], [TableRevenue], [FoodRevenue], [DrinkRevenue]) VALUES (7, CAST(N'2025-03-16' AS Date), CAST(6450000.00 AS Decimal(10, 2)), CAST(2400000.00 AS Decimal(10, 2)), CAST(2000000.00 AS Decimal(10, 2)))
INSERT [dbo].[Revenue] ([RevenueID], [RevenueDate], [TableRevenue], [FoodRevenue], [DrinkRevenue]) VALUES (8, CAST(N'2025-03-17' AS Date), CAST(8900000.00 AS Decimal(10, 2)), CAST(3000000.00 AS Decimal(10, 2)), CAST(2700000.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[Staff] ([MaNV], [Name], [Salary], [Enter], [Email]) VALUES (1, N'Nguyễn Hoàng An', CAST(1500000.00 AS Decimal(18, 2)), CAST(N'2024-01-01' AS Date), N'anngh@example.com')
INSERT [dbo].[Staff] ([MaNV], [Name], [Salary], [Enter], [Email]) VALUES (2, N'Trần Thị Bích', CAST(1800000.00 AS Decimal(18, 2)), CAST(N'2024-06-01' AS Date), N'bichtrh@example.com')
INSERT [dbo].[Staff] ([MaNV], [Name], [Salary], [Enter], [Email]) VALUES (3, N'Lê Chí Chương', CAST(2000000.00 AS Decimal(18, 2)), CAST(N'2023-04-10' AS Date), N'chuongle@example.com')
INSERT [dbo].[Staff] ([MaNV], [Name], [Salary], [Enter], [Email]) VALUES (4, N'Phạm Diệu Linh', CAST(2000000.00 AS Decimal(18, 2)), CAST(N'2024-02-15' AS Date), N'linhdph@example.com')
INSERT [dbo].[Staff] ([MaNV], [Name], [Salary], [Enter], [Email]) VALUES (5, N'Hoàng Thế Minh', CAST(1900000.00 AS Decimal(18, 2)), CAST(N'2023-10-10' AS Date), N'kimthoth@example.com')
INSERT [dbo].[Staff] ([MaNV], [Name], [Salary], [Enter], [Email]) VALUES (6, N'Vũ Như Quỳnh', CAST(1700000.00 AS Decimal(18, 2)), CAST(N'2024-05-01' AS Date), N'quynhvu@example.com')
INSERT [dbo].[Staff] ([MaNV], [Name], [Salary], [Enter], [Email]) VALUES (7, N'Lê Vũ Gia Huy', CAST(1200000.00 AS Decimal(18, 2)), CAST(N'2023-11-05' AS Date), N'huylevu@example.com')
INSERT [dbo].[Staff] ([MaNV], [Name], [Salary], [Enter], [Email]) VALUES (8, N'Nguyễn Quốc Dũn', CAST(1900000.00 AS Decimal(18, 2)), CAST(N'2023-07-01' AS Date), N'dungngq@example.com')
INSERT [dbo].[Staff] ([MaNV], [Name], [Salary], [Enter], [Email]) VALUES (9, N'Nguyễn Quốc Dũng', CAST(1900000.00 AS Decimal(18, 2)), CAST(N'2023-07-01' AS Date), N'dungngq@example.com')
INSERT [dbo].[Staff] ([MaNV], [Name], [Salary], [Enter], [Email]) VALUES (10, N'Lê Hà Chi', CAST(2000000.00 AS Decimal(18, 2)), CAST(N'2023-05-11' AS Date), N'chileha@example.com')
INSERT [dbo].[Staff] ([MaNV], [Name], [Salary], [Enter], [Email]) VALUES (12, N'Nguyễn Ngọc Tố Như', CAST(1400000.00 AS Decimal(18, 2)), CAST(N'2023-11-01' AS Date), N'nhutongngoc@example.com')
INSERT [dbo].[Staff] ([MaNV], [Name], [Salary], [Enter], [Email]) VALUES (13, N'Đặng Minh Tài', CAST(1920000.00 AS Decimal(18, 2)), CAST(N'2022-07-01' AS Date), N'Dmt826321@gmail.com')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__customer__06ACB9A2518B5798]    Script Date: 3/17/2025 1:09:19 AM ******/
ALTER TABLE [dbo].[customer] ADD UNIQUE NONCLUSTERED 
(
	[soDienThoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Booking] ADD  DEFAULT ((0)) FOR [MoneyDV]
GO
ALTER TABLE [dbo].[customer] ADD  DEFAULT ((0.00)) FOR [tienTichLuy]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD FOREIGN KEY([maKH])
REFERENCES [dbo].[customer] ([maKH])
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD CHECK  (([TableType]='KKKing' OR [TableType]='MrSung' OR [TableType]='Dragon'))
GO
/****** Object:  StoredProcedure [dbo].[sp_DoanhThuTrongNgay]    Script Date: 3/17/2025 1:09:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DoanhThuTrongNgay]
    @Ngay DATE
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        SUM(TableRevenue) AS DoanhThuThueBan,
        SUM(FoodRevenue) AS DoanhThuDoAn,
        SUM(DrinkRevenue) AS DoanhThuThucUong,
        SUM(TableRevenue + FoodRevenue + DrinkRevenue) AS DoanhThuNgay
    FROM Revenue
    WHERE RevenueDate = @Ngay;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_HoaDonCoTienLonNhat]    Script Date: 3/17/2025 1:09:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_HoaDonCoTienLonNhat]
AS
BEGIN
    SET NOCOUNT ON;

    -- Tìm khách hàng có hóa đơn cao nhất
    SELECT TOP 1
        c.maKH,
        c.hoTen,
        c.diaChi,
        SUM(DATEDIFF(MINUTE, b.BookingTimeStart, b.BookingTimeEnd)) AS TongPhutChoi,
        CAST(
            SUM(
                (DATEDIFF(MINUTE, b.BookingTimeStart, b.BookingTimeEnd) / 60.0) * 
                CASE 
                    WHEN b.TableType = 'KKKing' THEN 35000
                    WHEN b.TableType = 'Dragon' THEN 30000
                    WHEN b.TableType = 'MrSung' THEN 45000
                    ELSE 0
                END
            ) AS DECIMAL(18,2)
        ) AS TienBan,
        CAST(SUM(b.MoneyDV) AS DECIMAL(18,2)) AS TongTienDV,
        CAST(
            SUM(
                (DATEDIFF(MINUTE, b.BookingTimeStart, b.BookingTimeEnd) / 60.0) * 
                CASE 
                    WHEN b.TableType = 'KKKing' THEN 35000
                    WHEN b.TableType = 'Dragon' THEN 30000
                    WHEN b.TableType = 'MrSung' THEN 45000
                    ELSE 0
                END
            ) + SUM(b.MoneyDV) AS DECIMAL(18,2)
        ) AS TongTienPhaiTra
    FROM customer c
    INNER JOIN Booking b ON c.maKH = b.maKH
    GROUP BY c.maKH, c.hoTen, c.diaChi
    ORDER BY TongTienPhaiTra DESC;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_HoaDonCoTienNhoNhat]    Script Date: 3/17/2025 1:09:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_HoaDonCoTienNhoNhat]
AS
BEGIN
    SET NOCOUNT ON;

    -- Tìm khách hàng có hóa đơn thấp nhất
    SELECT TOP 1
        c.maKH,
        c.hoTen,
        c.diaChi,
        SUM(DATEDIFF(MINUTE, b.BookingTimeStart, b.BookingTimeEnd)) AS TongPhutChoi,
        CAST(
            SUM(
                (DATEDIFF(MINUTE, b.BookingTimeStart, b.BookingTimeEnd) / 60.0) * 
                CASE 
                    WHEN b.TableType = 'KKKing' THEN 35000
                    WHEN b.TableType = 'Dragon' THEN 30000
                    WHEN b.TableType = 'MrSung' THEN 45000
                    ELSE 0
                END
            ) AS DECIMAL(18,2)
        ) AS TienBan,
        CAST(SUM(b.MoneyDV) AS DECIMAL(18,2)) AS TongTienDV,
        CAST(
            SUM(
                (DATEDIFF(MINUTE, b.BookingTimeStart, b.BookingTimeEnd) / 60.0) * 
                CASE 
                    WHEN b.TableType = 'KKKing' THEN 35000
                    WHEN b.TableType = 'Dragon' THEN 30000
                    WHEN b.TableType = 'MrSung' THEN 45000
                    ELSE 0
                END
            ) + SUM(b.MoneyDV) AS DECIMAL(18,2)
        ) AS TongTienPhaiTra
    FROM customer c
    INNER JOIN Booking b ON c.maKH = b.maKH
    GROUP BY c.maKH, c.hoTen, c.diaChi
    ORDER BY TongTienPhaiTra ASC;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_InTatCaHoaDon]    Script Date: 3/17/2025 1:09:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InTatCaHoaDon]
AS
BEGIN
    SET NOCOUNT ON;

    -- Lấy danh sách hóa đơn của tất cả khách hàng
    SELECT 
        c.maKH,
        c.hoTen,
        c.diaChi,
        SUM(DATEDIFF(MINUTE, b.BookingTimeStart, b.BookingTimeEnd)) AS TongPhutChoi,
        CAST(
            SUM(
                (DATEDIFF(MINUTE, b.BookingTimeStart, b.BookingTimeEnd) / 60.0) * 
                CASE 
                    WHEN b.TableType = 'KKKing' THEN 35000
                    WHEN b.TableType = 'Dragon' THEN 30000
                    WHEN b.TableType = 'MrSung' THEN 45000
                    ELSE 0
                END
            ) AS DECIMAL(18,2)
        ) AS TienBan,
        CAST(SUM(b.MoneyDV) AS DECIMAL(18,2)) AS TongTienDV,
        CAST(
            SUM(
                (DATEDIFF(MINUTE, b.BookingTimeStart, b.BookingTimeEnd) / 60.0) * 
                CASE 
                    WHEN b.TableType = 'KKKing' THEN 35000
                    WHEN b.TableType = 'Dragon' THEN 30000
                    WHEN b.TableType = 'MrSung' THEN 45000
                    ELSE 0
                END
            ) + SUM(b.MoneyDV) AS DECIMAL(18,2)
        ) AS TongTienPhaiTra
    FROM customer c
    INNER JOIN Booking b ON c.maKH = b.maKH
    GROUP BY c.maKH, c.hoTen, c.diaChi
    ORDER BY TongTienPhaiTra DESC; -- Sắp xếp từ hóa đơn cao nhất đến thấp nhất
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_KhachHangTheoDichVuLonHon]    Script Date: 3/17/2025 1:09:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_KhachHangTheoDichVuLonHon]
    @LoaiDichVu DECIMAL(18,2)
AS  
BEGIN  
    SELECT DISTINCT   
        kh.maKH,   
        kh.hoTen,   
        kh.soDienThoai,   
        kh.diaChi,   
        kh.tienTichLuy,  
        b.MoneyDV
    FROM customer kh  
    INNER JOIN Booking b ON kh.maKH = b.maKH  
    WHERE b.MoneyDV > @LoaiDichVu
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_KhachHangTheoDichVuNhoHon]    Script Date: 3/17/2025 1:09:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_KhachHangTheoDichVuNhoHon]
    @LoaiDichVu DECIMAL(18,2)
AS  
BEGIN  
    SELECT DISTINCT   
        kh.maKH,   
        kh.hoTen,   
        kh.soDienThoai,   
        kh.diaChi,   
        kh.tienTichLuy,  
        b.MoneyDV
    FROM customer kh  
    INNER JOIN Booking b ON kh.maKH = b.maKH  
    WHERE b.MoneyDV < @LoaiDichVu
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_LocKhachHangChoiHonKPhut]    Script Date: 3/17/2025 1:09:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_LocKhachHangChoiHonKPhut]  
    @soPhut INT  
AS  
BEGIN  
    SET NOCOUNT ON;  
  
    SELECT   
        c.maKH,  
        c.hoTen,  
        c.diaChi,  
        SUM(DATEDIFF(MINUTE, b.BookingTimeStart, b.BookingTimeEnd)) AS TongThoiGianChoi_Phut  
    FROM customer c  
    INNER JOIN Booking b ON c.maKH = b.maKH  
    GROUP BY c.maKH, c.hoTen, c.diaChi  
    HAVING SUM(DATEDIFF(MINUTE, b.BookingTimeStart, b.BookingTimeEnd)) > @soPhut;  
END;  
GO
/****** Object:  StoredProcedure [dbo].[sp_LocKhachHangChoiNhoHonKPhut]    Script Date: 3/17/2025 1:09:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_LocKhachHangChoiNhoHonKPhut]  
    @soPhut INT  
AS  
BEGIN  
    SET NOCOUNT ON;  
  
    SELECT   
        c.maKH,  
        c.hoTen,  
        c.diaChi,  
        SUM(DATEDIFF(MINUTE, b.BookingTimeStart, b.BookingTimeEnd)) AS TongThoiGianChoi_Phut  
    FROM customer c  
    INNER JOIN Booking b ON c.maKH = b.maKH  
    GROUP BY c.maKH, c.hoTen, c.diaChi  
    HAVING SUM(DATEDIFF(MINUTE, b.BookingTimeStart, b.BookingTimeEnd)) < @soPhut;  
END;  
GO
/****** Object:  StoredProcedure [dbo].[sp_LocKhachHangTheoBan]    Script Date: 3/17/2025 1:09:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_LocKhachHangTheoBan]
    @LoaiBan NVARCHAR(50)
AS
BEGIN
    SELECT DISTINCT 
        kh.maKH, 
        kh.hoTen, 
        kh.soDienThoai, 
        kh.diaChi, 
        kh.tienTichLuy,
		b.TableType
    FROM customer kh
    INNER JOIN Booking b ON kh.maKH = b.maKH
    WHERE b.TableType = @LoaiBan
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_TinhThoiGianChoiKH]    Script Date: 3/17/2025 1:09:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_TinhThoiGianChoiKH]
    @maKH INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        c.maKH,
        c.hoTen,
        c.diaChi,
        SUM(DATEDIFF(MINUTE, b.BookingTimeStart, b.BookingTimeEnd)) AS TongThoiGianChoi_Phut
    FROM customer c
    INNER JOIN Booking b ON c.maKH = b.maKH
    WHERE c.maKH = @maKH
    GROUP BY c.maKH, c.hoTen, c.diaChi;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_TinhTongDoanhThuThueDoAn]    Script Date: 3/17/2025 1:09:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_TinhTongDoanhThuThueDoAn]
    @StartDate DATE,
    @EndDate DATE
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        SUM(FoodRevenue) AS TongDoanhThuThueDoAn
    FROM Revenue
    WHERE RevenueDate BETWEEN @StartDate AND @EndDate;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_TinhTongDoanhThuThueThucUong]    Script Date: 3/17/2025 1:09:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_TinhTongDoanhThuThueThucUong]
    @StartDate DATE,
    @EndDate DATE
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        SUM(DrinkRevenue) AS TongDoanhThuThueThucUong
    FROM Revenue
    WHERE RevenueDate BETWEEN @StartDate AND @EndDate;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_TinhTongTienPhaiTra]    Script Date: 3/17/2025 1:09:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_TinhTongTienPhaiTra]
    @maKH INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Tính tổng tiền phải trả với 2 chữ số thập phân
    SELECT 
        c.maKH,
        c.hoTen,
        c.diaChi,
        SUM(DATEDIFF(MINUTE, b.BookingTimeStart, b.BookingTimeEnd)) AS TongPhutChoi,
        CAST(
            SUM(
                (DATEDIFF(MINUTE, b.BookingTimeStart, b.BookingTimeEnd) / 60.0) * 
                CASE 
                    WHEN b.TableType = 'KKKing' THEN 35000
                    WHEN b.TableType = 'Dragon' THEN 30000
                    WHEN b.TableType = 'MrSung' THEN 45000
                    ELSE 0
                END
            ) AS DECIMAL(18,2)
        ) AS TienBan,
        CAST(SUM(b.MoneyDV) AS DECIMAL(18,2)) AS TongTienDV,
        CAST(
            SUM(
                (DATEDIFF(MINUTE, b.BookingTimeStart, b.BookingTimeEnd) / 60.0) * 
                CASE 
                    WHEN b.TableType = 'KKKing' THEN 35000
                    WHEN b.TableType = 'Dragon' THEN 30000
                    WHEN b.TableType = 'MrSung' THEN 45000
                    ELSE 0
                END
            ) + SUM(b.MoneyDV) AS DECIMAL(18,2)
        ) AS TongTienPhaiTra
    FROM customer c
    INNER JOIN Booking b ON c.maKH = b.maKH
    WHERE c.maKH = @maKH
    GROUP BY c.maKH, c.hoTen, c.diaChi;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_TinhTongTienTatCaDichVu]    Script Date: 3/17/2025 1:09:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_TinhTongTienTatCaDichVu]
    @StartDate DATE,
    @EndDate DATE
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        SUM(TableRevenue + FoodRevenue + DrinkRevenue) AS TongDoanhThu
    FROM Revenue
    WHERE RevenueDate BETWEEN @StartDate AND @EndDate;
END;
GO
/****** Object:  StoredProcedure [dbo].[spCapNhatDichVu]    Script Date: 3/17/2025 1:09:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spCapNhatDichVu]
    @TenDV NVARCHAR(255),
    @LoaiDV NVARCHAR(100),
    @GiaTien DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra dịch vụ có tồn tại không
    IF NOT EXISTS (SELECT 1 FROM DichVu WHERE TenDV = @TenDV AND LoaiDV = @LoaiDV)
    BEGIN
        RAISERROR(N'Dịch vụ không tồn tại!', 16, 1);
        RETURN;
    END

    -- Cập nhật giá tiền
    UPDATE DichVu
    SET GiaTien = @GiaTien
    WHERE TenDV = @TenDV AND LoaiDV = @LoaiDV;
END;
GO
/****** Object:  StoredProcedure [dbo].[spCapNhatDoanhThu]    Script Date: 3/17/2025 1:09:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spCapNhatDoanhThu]
    @RevenueID INT,
    @RevenueDate DATE,
    @TableRevenue DECIMAL(10,2),
    @FoodRevenue DECIMAL(10,2),
    @DrinkRevenue DECIMAL(10,2)
AS
BEGIN
    UPDATE Revenue
    SET RevenueDate = @RevenueDate,
        TableRevenue = @TableRevenue,
        FoodRevenue = @FoodRevenue,
        DrinkRevenue = @DrinkRevenue
    WHERE RevenueID = @RevenueID;
END;
GO
/****** Object:  StoredProcedure [dbo].[spCapNhatKhachHang]    Script Date: 3/17/2025 1:09:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spCapNhatKhachHang]
    @maKH INT,
    @hoTen NVARCHAR(100),
    @soDienThoai VARCHAR(15),
    @diaChi NVARCHAR(255),
    @tienTichLuy DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;
    
    UPDATE customer
    SET 
	hoTen = @hoTen,
        soDienThoai = @soDienThoai,
        diaChi = @diaChi,
        tienTichLuy = @tienTichLuy
    WHERE maKH = @maKH;
END;


GO
/****** Object:  StoredProcedure [dbo].[spCapNhatNhanVien]    Script Date: 3/17/2025 1:09:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spCapNhatNhanVien]
    @MaNV INT,
    @Name NVARCHAR(100),
    @Salary DECIMAL(18,2),
    @Enter DATE,
    @Email NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra nếu nhân viên không tồn tại
    IF NOT EXISTS (SELECT 1 FROM Staff WHERE MaNV = @MaNV)
    BEGIN
        RAISERROR('Nhân viên không tồn tại!', 16, 1);
        RETURN;
    END

    -- Cập nhật thông tin nhân viên
    UPDATE Staff
    SET Name = @Name,
        Salary = @Salary,
        Enter = @Enter,
        Email = @Email
    WHERE MaNV = @MaNV;
END;
GO
/****** Object:  StoredProcedure [dbo].[spKhachHangItTienNhat]    Script Date: 3/17/2025 1:09:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spKhachHangItTienNhat]
AS
BEGIN
    SELECT TOP 1 * 
    FROM customer
    ORDER BY tienTichLuy ASC;
END;
GO
/****** Object:  StoredProcedure [dbo].[spKhachHangNhieuTienNhat]    Script Date: 3/17/2025 1:09:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spKhachHangNhieuTienNhat]
AS
BEGIN
    SELECT TOP 1 * 
    FROM customer
    ORDER BY tienTichLuy DESC;
END;
GO
/****** Object:  StoredProcedure [dbo].[spLayDichVuTheoGia]    Script Date: 3/17/2025 1:09:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spLayDichVuTheoGia]
    @GiaMin DECIMAL(18,2),
    @GiaMax DECIMAL(18,2)
AS
BEGIN
    SELECT * FROM DichVu 
    WHERE GiaTien BETWEEN @GiaMin AND @GiaMax
END
GO
/****** Object:  StoredProcedure [dbo].[spLayDichVuTheoThucAn]    Script Date: 3/17/2025 1:09:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spLayDichVuTheoThucAn]
AS
BEGIN
    SELECT * FROM DichVu WHERE LoaiDV = N'Thức Ăn'
END
GO
/****** Object:  StoredProcedure [dbo].[spLayDichVuTheoThucUong]    Script Date: 3/17/2025 1:09:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spLayDichVuTheoThucUong]
AS
BEGIN
    SELECT * FROM DichVu WHERE LoaiDV = N'Thức Uống'
END
GO
/****** Object:  StoredProcedure [dbo].[spSuaBooking]    Script Date: 3/17/2025 1:09:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spSuaBooking]
    @BookingID NVARCHAR(10),
    @maKH INT,
    @BookingTimeStart DATETIME,
    @BookingTimeEnd DATETIME,
    @MoneyDV DECIMAL(18,2),
    @TableType NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Booking
    SET maKH = @maKH,
        BookingTimeStart = @BookingTimeStart,
        BookingTimeEnd = @BookingTimeEnd,
        MoneyDV = @MoneyDV,
        TableType = @TableType
    WHERE BookingID = @BookingID;
END;
GO
/****** Object:  StoredProcedure [dbo].[spThemBooking]    Script Date: 3/17/2025 1:09:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spThemBooking]
    @BookingID NVARCHAR(10),
    @maKH INT,
    @BookingTimeStart DATETIME,
    @BookingTimeEnd DATETIME,
    @MoneyDV DECIMAL(18,2),
    @TableType NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Booking (BookingID, maKH, BookingTimeStart, BookingTimeEnd, MoneyDV, TableType)
    VALUES (@BookingID, @maKH, @BookingTimeStart, @BookingTimeEnd, @MoneyDV, @TableType);
END;
GO
/****** Object:  StoredProcedure [dbo].[spThemDichVu]    Script Date: 3/17/2025 1:09:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spThemDichVu]
    @TenDV NVARCHAR(255),
    @LoaiDV NVARCHAR(100),
    @GiaTien DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra dịch vụ đã tồn tại chưa
    IF EXISTS (SELECT 1 FROM DichVu WHERE TenDV = @TenDV AND LoaiDV = @LoaiDV)
    BEGIN
        RAISERROR(N'Dịch vụ này đã tồn tại!', 16, 1);
        RETURN;
    END

    -- Thêm mới dịch vụ
    INSERT INTO DichVu (TenDV, LoaiDV, GiaTien)
    VALUES (@TenDV, @LoaiDV, @GiaTien);
END;
GO
/****** Object:  StoredProcedure [dbo].[spThemDoanhThu]    Script Date: 3/17/2025 1:09:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spThemDoanhThu]
    @RevenueID INT,
    @RevenueDate DATE,
    @TableRevenue DECIMAL(10,2),
    @FoodRevenue DECIMAL(10,2),
    @DrinkRevenue DECIMAL(10,2)
AS
BEGIN
    INSERT INTO Revenue (RevenueID, RevenueDate, TableRevenue, FoodRevenue, DrinkRevenue)
    VALUES (@RevenueID, @RevenueDate, @TableRevenue, @FoodRevenue, @DrinkRevenue);
END;
GO
/****** Object:  StoredProcedure [dbo].[spThemKhachHang]    Script Date: 3/17/2025 1:09:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spThemKhachHang]
    @maKH INT,
    @hoTen NVARCHAR(100),
    @soDienThoai VARCHAR(15),
    @diaChi NVARCHAR(255),
    @tienTichLuy DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;
    
    INSERT INTO customer (maKH, hoTen, soDienThoai, diaChi, tienTichLuy)
    VALUES (@maKH, @hoTen, @soDienThoai, @diaChi, @tienTichLuy);
END;

GO
/****** Object:  StoredProcedure [dbo].[spThemNhanVien]    Script Date: 3/17/2025 1:09:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spThemNhanVien]
    @MaNV INT,
    @Name NVARCHAR(100),
    @Salary DECIMAL(18,2),
    @Enter DATE,
    @Email NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra xem nhân viên đã tồn tại chưa
    IF EXISTS (SELECT 1 FROM Staff WHERE MaNV = @MaNV)
    BEGIN
        RAISERROR('Mã nhân viên đã tồn tại!', 16, 1);
        RETURN;
    END

    -- Thêm nhân viên mới
    INSERT INTO Staff (MaNV, Name, Salary, Enter, Email)
    VALUES (@MaNV, @Name, @Salary, @Enter, @Email);
END;
GO
/****** Object:  StoredProcedure [dbo].[spTimDichVuCoGiaTienLonNhat]    Script Date: 3/17/2025 1:09:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spTimDichVuCoGiaTienLonNhat]
AS
BEGIN
    SELECT * FROM DichVu WHERE GiaTien = (SELECT MAX(GiaTien) FROM DichVu)
END
GO
/****** Object:  StoredProcedure [dbo].[spTimDichVuCoGiaTienThapNhat]    Script Date: 3/17/2025 1:09:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spTimDichVuCoGiaTienThapNhat]
AS
BEGIN
    SELECT * FROM DichVu WHERE GiaTien = (SELECT MIN(GiaTien) FROM DichVu)
END
GO
/****** Object:  StoredProcedure [dbo].[spTimDichVuTheoTen]    Script Date: 3/17/2025 1:09:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spTimDichVuTheoTen]
    @TenDV NVARCHAR(100)
AS
BEGIN
    SELECT * FROM DichVu WHERE TenDV LIKE '%' + @TenDV + '%'
END
GO
/****** Object:  StoredProcedure [dbo].[spTimKhachHangTheoDiaChi]    Script Date: 3/17/2025 1:09:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spTimKhachHangTheoDiaChi]
    @Keyword NVARCHAR(100)
AS
BEGIN
    SELECT * 
    FROM customer
    WHERE diaChi LIKE '%' + @Keyword + '%';
END;
GO
/****** Object:  StoredProcedure [dbo].[spTimKhachHangTheoTen]    Script Date: 3/17/2025 1:09:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spTimKhachHangTheoTen]
    @Name NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    -- Tìm khách hàng có từ cuối cùng là @Name
    SELECT * 
    FROM Customer
    WHERE RIGHT(hoTen, CHARINDEX(' ', REVERSE(hoTen) + ' ') - 1) = @Name;
END
GO
/****** Object:  StoredProcedure [dbo].[spTimNhanVienLauNhat]    Script Date: 3/17/2025 1:09:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spTimNhanVienLauNhat]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 1 * 
    FROM Staff
    ORDER BY Enter ASC; -- Nhân viên có ngày vào làm sớm nhất
END;
GO
/****** Object:  StoredProcedure [dbo].[spTimNhanVienMoiLam]    Script Date: 3/17/2025 1:09:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spTimNhanVienMoiLam]
AS
BEGIN
    SET NOCOUNT ON;
    SELECT TOP 1 * FROM Staff ORDER BY Enter DESC;
END
GO
/****** Object:  StoredProcedure [dbo].[spTimNhanVienTheoLuongDuoi]    Script Date: 3/17/2025 1:09:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spTimNhanVienTheoLuongDuoi]
    @LuongMax DECIMAL(18,2) -- Kiểu dữ liệu DECIMAL phù hợp với lương
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Lọc nhân viên có lương nhỏ hơn hoặc bằng @LuongMax
    SELECT * FROM Staff WHERE Salary < @LuongMax;
END
GO
/****** Object:  StoredProcedure [dbo].[spTimNhanVienTheoLuongTren]    Script Date: 3/17/2025 1:09:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spTimNhanVienTheoLuongTren]
    @LuongMin DECIMAL(18, 2) -- Mức lương tối thiểu
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM Staff WHERE Salary > @LuongMin;
END
GO
/****** Object:  StoredProcedure [dbo].[spTimNhanVienTheoNam]    Script Date: 3/17/2025 1:09:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spTimNhanVienTheoNam]
    @Nam INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM Staff WHERE YEAR(Enter) = @Nam;
END;
GO
/****** Object:  StoredProcedure [dbo].[spTimNhanVienTheoTen]    Script Date: 3/17/2025 1:09:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spTimNhanVienTheoTen]
    @Name NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Tìm nhân viên có từ cuối cùng là @Name
    SELECT * 
    FROM Staff 
    WHERE RIGHT(Name, CHARINDEX(' ', REVERSE(Name) + ' ') - 1) = @Name;
END
GO
/****** Object:  StoredProcedure [dbo].[spTinhTongDoanhThuThueBan]    Script Date: 3/17/2025 1:09:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spTinhTongDoanhThuThueBan]
    @StartDate DATE,
    @EndDate DATE
AS
BEGIN
    SELECT SUM(TableRevenue) AS TongDoanhThuThueBan
    FROM Revenue
    WHERE RevenueDate BETWEEN @StartDate AND @EndDate;
END;
GO
/****** Object:  StoredProcedure [dbo].[spXoaBooking]    Script Date: 3/17/2025 1:09:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spXoaBooking]
    @BookingID NVARCHAR(10),
    @RowsAffected INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    DELETE FROM Booking
    WHERE BookingID = @BookingID;
    
    SET @RowsAffected = @@ROWCOUNT;
END;
GO
/****** Object:  StoredProcedure [dbo].[spXoaDichVu]    Script Date: 3/17/2025 1:09:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spXoaDichVu]
    @TenDV NVARCHAR(255),
    @LoaiDV NVARCHAR(100),
    @RowsAffected INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Xóa dịch vụ theo TenDV và LoaiDV
    DELETE FROM DichVu
    WHERE TenDV = @TenDV AND LoaiDV = @LoaiDV;

    -- Trả về số dòng bị ảnh hưởng
    SET @RowsAffected = @@ROWCOUNT;
END;
GO
/****** Object:  StoredProcedure [dbo].[spXoaDoanhThu]    Script Date: 3/17/2025 1:09:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spXoaDoanhThu]
    @RevenueID INT
AS
BEGIN
    DELETE FROM Revenue WHERE RevenueID = @RevenueID;
END;
GO
/****** Object:  StoredProcedure [dbo].[spXoaKhachHang]    Script Date: 3/17/2025 1:09:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- 📌 Xóa khách hàng
CREATE PROCEDURE [dbo].[spXoaKhachHang]
    @maKH INT,
    @RowsAffected INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    DELETE FROM customer WHERE maKH = @maKH;
    
    SET @RowsAffected = @@ROWCOUNT;
END;
GO
/****** Object:  StoredProcedure [dbo].[spXoaNhanVien]    Script Date: 3/17/2025 1:09:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spXoaNhanVien]
    @MaNV INT,
    @RowsAffected INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Xóa nhân viên theo MaNV
    DELETE FROM Staff WHERE MaNV = @MaNV;

    -- Trả về số dòng bị ảnh hưởng
    SET @RowsAffected = @@ROWCOUNT;

    -- Kiểm tra nếu không tìm thấy nhân viên để xóa
    IF @RowsAffected = 0
    BEGIN
        RAISERROR('Không tìm thấy nhân viên có MaNV này!', 16, 1);
    END
END;
GO
