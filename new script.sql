USE [WEBGIUPVIEC]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 5/19/2024 1:52:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[ContactID] [int] IDENTITY(1,1) NOT NULL,
	[Adress] [nvarchar](500) NOT NULL,
	[Phone] [varchar](20) NOT NULL,
	[Email] [nvarchar](200) NOT NULL,
	[SortOrder] [int] NOT NULL,
	[Mota] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ContactID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 5/19/2024 1:52:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[TenKH] [nvarchar](200) NOT NULL,
	[Ngaysinh] [nvarchar](100) NOT NULL,
	[GioiTinh] [nvarchar](10) NOT NULL,
	[Avatar] [nvarchar](max) NULL,
	[Diachi] [nvarchar](500) NULL,
	[Phone] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](200) NOT NULL,
	[Password] [varchar](26) NOT NULL,
	[MemberShip] [int] NULL,
	[RoleID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanhMuc]    Script Date: 5/19/2024 1:52:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhMuc](
	[MaDM] [int] IDENTITY(1,1) NOT NULL,
	[TenDM] [nvarchar](50) NOT NULL,
	[Mota] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Job]    Script Date: 5/19/2024 1:52:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Job](
	[JobID] [int] IDENTITY(1,1) NOT NULL,
	[MaDM] [int] NULL,
	[TenCV] [nvarchar](200) NOT NULL,
	[GiaGoc] [int] NOT NULL,
	[GiaDiscount] [int] NOT NULL,
	[CongTy] [nvarchar](200) NOT NULL,
	[MoTaNgan] [nvarchar](300) NOT NULL,
	[MoTaDai] [nvarchar](max) NOT NULL,
	[ThoiGianLam] [nvarchar](200) NOT NULL,
	[TrangThai] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[JobID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobOffer]    Script Date: 5/19/2024 1:52:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobOffer](
	[JobOfferID] [int] IDENTITY(1,1) NOT NULL,
	[JobID] [int] NOT NULL,
	[CustomerID] [int] NOT NULL,
	[StaffID] [int] NULL,
	[TrangThaiID] [int] NULL,
	[NgayDang] [nvarchar](200) NOT NULL,
	[NgayBDLam] [nvarchar](200) NOT NULL,
	[Gia] [nvarchar](200) NOT NULL,
	[Note] [nvarchar](500) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[JobOfferID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobPayment]    Script Date: 5/19/2024 1:52:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobPayment](
	[JobPaymentID] [int] IDENTITY(1,1) NOT NULL,
	[JobOfferID] [int] NOT NULL,
	[PaymentID] [int] NOT NULL,
	[TrangThai] [bit] NULL,
	[NgayTT] [nvarchar](200) NOT NULL,
	[TongTien] [nvarchar](200) NOT NULL,
	[Note] [nvarchar](500) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[JobPaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 5/19/2024 1:52:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[PaymentID] [int] IDENTITY(1,1) NOT NULL,
	[PaymentName] [nvarchar](50) NOT NULL,
	[Mota] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[PaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 5/19/2024 1:52:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[PostID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[MoTaNgan] [nvarchar](500) NOT NULL,
	[MoTaDai] [nvarchar](max) NOT NULL,
	[TacGia] [nvarchar](200) NOT NULL,
	[NgayDang] [nvarchar](200) NOT NULL,
	[TrangThai] [bit] NULL,
	[Anh] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[PostID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 5/19/2024 1:52:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](20) NOT NULL,
	[Mota] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Slide]    Script Date: 5/19/2024 1:52:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slide](
	[SlideID] [int] IDENTITY(1,1) NOT NULL,
	[SlideName] [nvarchar](200) NOT NULL,
	[Image] [nvarchar](max) NOT NULL,
	[Url] [nvarchar](max) NOT NULL,
	[SortOrder] [int] NOT NULL,
	[Mota] [nvarchar](500) NOT NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[SlideID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 5/19/2024 1:52:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[StaffID] [int] IDENTITY(1,1) NOT NULL,
	[TenNV] [nvarchar](200) NOT NULL,
	[Ngaysinh] [nvarchar](200) NOT NULL,
	[GioiTinh] [nvarchar](10) NOT NULL,
	[Avatar] [nvarchar](max) NULL,
	[Diachi] [nvarchar](500) NULL,
	[Phone] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](200) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[NgayVaoCty] [nvarchar](100) NOT NULL,
	[SoCVDaLam] [int] NULL,
	[StaffPoint] [int] NULL,
	[DanhGia] [varchar](1) NULL,
	[RoleID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[StaffID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrangThai]    Script Date: 5/19/2024 1:52:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrangThai](
	[TrangThaiID] [int] IDENTITY(1,1) NOT NULL,
	[TrangThaiName] [nvarchar](50) NOT NULL,
	[Mota] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[TrangThaiID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Contact] ON 

INSERT [dbo].[Contact] ([ContactID], [Adress], [Phone], [Email], [SortOrder], [Mota]) VALUES (1, N'Thanh Xuân - Hà Nội', N'099999999', N'company@gmail.com', 1, N'Công ty hỗ trợ thuê và tìm giúp việc nhà.')
SET IDENTITY_INSERT [dbo].[Contact] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([CustomerID], [TenKH], [Ngaysinh], [GioiTinh], [Avatar], [Diachi], [Phone], [Email], [Password], [MemberShip], [RoleID]) VALUES (1, N'Nguy?n Ti?n Dung', N'2023-10-06', N'Nam', N'https://firebasestorage.googleapis.com/v0/b/vue-upload-91ec4.appspot.com/o/user-441241140_1115982376286249_2018922306111818749_n.png?alt=media&token=89959e8e-5508-4e1b-b067-5d7cbeaed9c1', N'Hà N?i', N'0999992334', N'dung@gmail.com', N'123456', 100, 1)
INSERT [dbo].[Customer] ([CustomerID], [TenKH], [Ngaysinh], [GioiTinh], [Avatar], [Diachi], [Phone], [Email], [Password], [MemberShip], [RoleID]) VALUES (2, N'Nhân viên', N'2023-10-06', N'Nam', NULL, N'Hà N?i', N'0652651215', N'staff@gmail.com', N'123456', 100, 2)
INSERT [dbo].[Customer] ([CustomerID], [TenKH], [Ngaysinh], [GioiTinh], [Avatar], [Diachi], [Phone], [Email], [Password], [MemberShip], [RoleID]) VALUES (3, N'Khách hàng', N'2023-10-06', N'Nam', NULL, N'Hà N?i', N'0652651216', N'customer@gmail.com', N'123456', 100, 3)
INSERT [dbo].[Customer] ([CustomerID], [TenKH], [Ngaysinh], [GioiTinh], [Avatar], [Diachi], [Phone], [Email], [Password], [MemberShip], [RoleID]) VALUES (4, N'Nguyễn Văn Tèo', N'2000-01-19', N'Nam', NULL, N'HCM', N'0975224090', N'voquoctuanqn@gmail.com', N'Baoanh2019$', 100, 3)
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[DanhMuc] ON 

INSERT [dbo].[DanhMuc] ([MaDM], [TenDM], [Mota]) VALUES (1, N'Việc nhà', N'Việc nhà')
INSERT [dbo].[DanhMuc] ([MaDM], [TenDM], [Mota]) VALUES (2, N'Dịch Vụ', N'Dịch Vụ')
INSERT [dbo].[DanhMuc] ([MaDM], [TenDM], [Mota]) VALUES (3, N'Chuyển Nhà Cửa', N'Chuyển Nhà Cửa')
SET IDENTITY_INSERT [dbo].[DanhMuc] OFF
GO
SET IDENTITY_INSERT [dbo].[Job] ON 

INSERT [dbo].[Job] ([JobID], [MaDM], [TenCV], [GiaGoc], [GiaDiscount], [CongTy], [MoTaNgan], [MoTaDai], [ThoiGianLam], [TrangThai]) VALUES (1, 1, N'Quét dọn nhà cửa', 300000, 250000, N'Công ty lau d?n nhà c?a', N'Quét dọn nhà cửa', N'Quét dọn nhà cửa', N'1h', 1)
SET IDENTITY_INSERT [dbo].[Job] OFF
GO
SET IDENTITY_INSERT [dbo].[JobOffer] ON 

INSERT [dbo].[JobOffer] ([JobOfferID], [JobID], [CustomerID], [StaffID], [TrangThaiID], [NgayDang], [NgayBDLam], [Gia], [Note]) VALUES (3, 1, 3, 2, 1, N'9-6-2023', N'2023-10-06', N'250000', N'http://localhost:8080/#/admin_job')
INSERT [dbo].[JobOffer] ([JobOfferID], [JobID], [CustomerID], [StaffID], [TrangThaiID], [NgayDang], [NgayBDLam], [Gia], [Note]) VALUES (4, 1, 4, 2, 3, N'4-19-2024', N'2024-05-20', N'250000', N'')
INSERT [dbo].[JobOffer] ([JobOfferID], [JobID], [CustomerID], [StaffID], [TrangThaiID], [NgayDang], [NgayBDLam], [Gia], [Note]) VALUES (5, 1, 4, 2, 3, N'4-19-2024', N'2024-05-19', N'250000', N'test')
INSERT [dbo].[JobOffer] ([JobOfferID], [JobID], [CustomerID], [StaffID], [TrangThaiID], [NgayDang], [NgayBDLam], [Gia], [Note]) VALUES (6, 1, 4, 2, 3, N'4-19-2024', N'2024-05-19', N'250000', N'')
SET IDENTITY_INSERT [dbo].[JobOffer] OFF
GO
SET IDENTITY_INSERT [dbo].[JobPayment] ON 

INSERT [dbo].[JobPayment] ([JobPaymentID], [JobOfferID], [PaymentID], [TrangThai], [NgayTT], [TongTien], [Note]) VALUES (1, 4, 1, 1, N'4-19-2024', N'250000', N'')
INSERT [dbo].[JobPayment] ([JobPaymentID], [JobOfferID], [PaymentID], [TrangThai], [NgayTT], [TongTien], [Note]) VALUES (2, 5, 1, 1, N'4-19-2024', N'250000', N'')
INSERT [dbo].[JobPayment] ([JobPaymentID], [JobOfferID], [PaymentID], [TrangThai], [NgayTT], [TongTien], [Note]) VALUES (3, 6, 1, 1, N'4-19-2024', N'250000', N'')
SET IDENTITY_INSERT [dbo].[JobPayment] OFF
GO
SET IDENTITY_INSERT [dbo].[Payment] ON 

INSERT [dbo].[Payment] ([PaymentID], [PaymentName], [Mota]) VALUES (1, N'COD', N'COD')
SET IDENTITY_INSERT [dbo].[Payment] OFF
GO
SET IDENTITY_INSERT [dbo].[Post] ON 

INSERT [dbo].[Post] ([PostID], [Title], [MoTaNgan], [MoTaDai], [TacGia], [NgayDang], [TrangThai], [Anh]) VALUES (1, N'Euro 2024', N'Euro 2024', N'Euro 2024', N'Euro 2024', N'2024-05-20', 1, N'https://firebasestorage.googleapis.com/v0/b/vue-upload-91ec4.appspot.com/o/post%2F4.jpg?alt=media&token=180669a3-be5e-4e62-8c5c-51e44c6f2581')
INSERT [dbo].[Post] ([PostID], [Title], [MoTaNgan], [MoTaDai], [TacGia], [NgayDang], [TrangThai], [Anh]) VALUES (2, N'Chung kết C1', N'Chung kết C1', N'Chung kết C1', N'Chung kết C1', N'2024-06-05', 1, N'https://firebasestorage.googleapis.com/v0/b/vue-upload-91ec4.appspot.com/o/post%2F441185452_451991494075159_6741912786802962641_n.png?alt=media&token=180669a3-be5e-4e62-8c5c-51e44c6f2581')
SET IDENTITY_INSERT [dbo].[Post] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([RoleID], [RoleName], [Mota]) VALUES (1, N'admin', N'Admin')
INSERT [dbo].[Role] ([RoleID], [RoleName], [Mota]) VALUES (2, N'staff', N'Nhân viên')
INSERT [dbo].[Role] ([RoleID], [RoleName], [Mota]) VALUES (3, N'customer', N'Khách hàng')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Staff] ON 

INSERT [dbo].[Staff] ([StaffID], [TenNV], [Ngaysinh], [GioiTinh], [Avatar], [Diachi], [Phone], [Email], [Password], [NgayVaoCty], [SoCVDaLam], [StaffPoint], [DanhGia], [RoleID]) VALUES (1, N'Nhân viên', N'2023-10-06', N'Nam', NULL, N'Hà N?i', N'0652651215', N'staff1@gmail.com', N'123456', N'06-10-2023', 2, NULL, NULL, 2)
INSERT [dbo].[Staff] ([StaffID], [TenNV], [Ngaysinh], [GioiTinh], [Avatar], [Diachi], [Phone], [Email], [Password], [NgayVaoCty], [SoCVDaLam], [StaffPoint], [DanhGia], [RoleID]) VALUES (2, N'Nhân viên', N'2023-10-06', N'Nam', NULL, N'Hà N?i', N'0652651215', N'staff@gmail.com', N'123456', N'06-10-2023', 2, NULL, NULL, 2)
SET IDENTITY_INSERT [dbo].[Staff] OFF
GO
SET IDENTITY_INSERT [dbo].[TrangThai] ON 

INSERT [dbo].[TrangThai] ([TrangThaiID], [TrangThaiName], [Mota]) VALUES (1, N'Chưa thanh toán', N'Chưa thanh toán')
INSERT [dbo].[TrangThai] ([TrangThaiID], [TrangThaiName], [Mota]) VALUES (2, N'Ðã thanh toán', N'Ðã thanh toán')
INSERT [dbo].[TrangThai] ([TrangThaiID], [TrangThaiName], [Mota]) VALUES (3, N'Ðang làm', N'Ðang làm')
INSERT [dbo].[TrangThai] ([TrangThaiID], [TrangThaiName], [Mota]) VALUES (4, N'Ðã xong', N'Ðã xong')
SET IDENTITY_INSERT [dbo].[TrangThai] OFF
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[Job]  WITH CHECK ADD FOREIGN KEY([MaDM])
REFERENCES [dbo].[DanhMuc] ([MaDM])
GO
ALTER TABLE [dbo].[JobOffer]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[JobOffer]  WITH CHECK ADD FOREIGN KEY([JobID])
REFERENCES [dbo].[Job] ([JobID])
GO
ALTER TABLE [dbo].[JobOffer]  WITH CHECK ADD FOREIGN KEY([StaffID])
REFERENCES [dbo].[Staff] ([StaffID])
GO
ALTER TABLE [dbo].[JobOffer]  WITH CHECK ADD FOREIGN KEY([TrangThaiID])
REFERENCES [dbo].[TrangThai] ([TrangThaiID])
GO
ALTER TABLE [dbo].[JobPayment]  WITH CHECK ADD FOREIGN KEY([JobOfferID])
REFERENCES [dbo].[JobOffer] ([JobOfferID])
GO
ALTER TABLE [dbo].[JobPayment]  WITH CHECK ADD FOREIGN KEY([PaymentID])
REFERENCES [dbo].[Payment] ([PaymentID])
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
