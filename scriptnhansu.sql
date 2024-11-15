USE [master]
GO
/****** Object:  Database [QuanLyNhanSu_u1]    Script Date: 19-09-2024 1:01:46 PM ******/
CREATE DATABASE [QuanLyNhanSu_u1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyNhanSu_u1', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\QuanLyNhanSu_u1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QuanLyNhanSu_u1_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\QuanLyNhanSu_u1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [QuanLyNhanSu_u1] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyNhanSu_u1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyNhanSu_u1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyNhanSu_u1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyNhanSu_u1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyNhanSu_u1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyNhanSu_u1] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyNhanSu_u1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QuanLyNhanSu_u1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyNhanSu_u1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyNhanSu_u1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyNhanSu_u1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyNhanSu_u1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyNhanSu_u1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyNhanSu_u1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyNhanSu_u1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyNhanSu_u1] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QuanLyNhanSu_u1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyNhanSu_u1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyNhanSu_u1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyNhanSu_u1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyNhanSu_u1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyNhanSu_u1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyNhanSu_u1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyNhanSu_u1] SET RECOVERY FULL 
GO
ALTER DATABASE [QuanLyNhanSu_u1] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyNhanSu_u1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyNhanSu_u1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyNhanSu_u1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyNhanSu_u1] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QuanLyNhanSu_u1] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QuanLyNhanSu_u1] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'QuanLyNhanSu_u1', N'ON'
GO
ALTER DATABASE [QuanLyNhanSu_u1] SET QUERY_STORE = ON
GO
ALTER DATABASE [QuanLyNhanSu_u1] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [QuanLyNhanSu_u1]
GO
/****** Object:  Table [dbo].[CapNhatLuongs]    Script Date: 19-09-2024 1:01:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CapNhatLuongs](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[MaNhanVien] [varchar](30) NOT NULL,
	[LuongHienTai] [int] NOT NULL,
	[LuongSauCapNhat] [int] NOT NULL,
	[BHXH] [float] NULL,
	[BHYT] [float] NULL,
	[BHTN] [float] NULL,
	[PhuCap] [float] NULL,
	[ThueThuNhap] [float] NULL,
	[NgayCapNhat] [datetime] NULL,
	[HeSoLuong] [float] NULL,
 CONSTRAINT [PK_CapNhatLuongs] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CapNhatTrinhDoHocVans]    Script Date: 19-09-2024 1:01:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CapNhatTrinhDoHocVans](
	[MaCapNhat] [int] IDENTITY(1,1) NOT NULL,
	[MaNhanVien] [varchar](30) NOT NULL,
	[NgayCapNhat] [datetime] NOT NULL,
	[MaTrinhDoTruoc] [varchar](30) NOT NULL,
	[MaTrinhDoCapNhat] [varchar](30) NOT NULL,
 CONSTRAINT [PK_CapNhatTrinhDoHocVans] PRIMARY KEY CLUSTERED 
(
	[MaCapNhat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietLuongs]    Script Date: 19-09-2024 1:01:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietLuongs](
	[MaChiTietBangLuong] [varchar](30) NOT NULL,
	[MaNhanVien] [varchar](30) NOT NULL,
	[LuongCoBan] [float] NOT NULL,
	[BHXH] [float] NULL,
	[BHYT] [float] NULL,
	[BHTN] [float] NULL,
	[PhuCap] [float] NULL,
	[ThueThuNhap] [float] NULL,
	[TienThuong] [int] NULL,
	[TienPhat] [int] NULL,
	[NgayNhanLuong] [datetime] NOT NULL,
	[TongTienLuong] [varchar](30) NULL,
 CONSTRAINT [PK_ChiTietLuongs] PRIMARY KEY CLUSTERED 
(
	[MaChiTietBangLuong] ASC,
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChucVuNhanViens]    Script Date: 19-09-2024 1:01:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChucVuNhanViens](
	[MaChucVuNV] [varchar](30) NOT NULL,
	[TenChucVu] [nvarchar](50) NOT NULL,
	[HSPC] [float] NULL,
	[MaPhongBan] [varchar](30) NULL,
 CONSTRAINT [PK_ChucVuNhanViens] PRIMARY KEY CLUSTERED 
(
	[MaChucVuNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChuyenNganhs]    Script Date: 19-09-2024 1:01:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChuyenNganhs](
	[MaChuyenNganh] [varchar](30) NOT NULL,
	[TenChuyenNganh] [nvarchar](50) NULL,
 CONSTRAINT [PK_ChuyenNganhs] PRIMARY KEY CLUSTERED 
(
	[MaChuyenNganh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HeSoLuong]    Script Date: 19-09-2024 1:01:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HeSoLuong](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NOT NULL,
	[HeSo] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HopDongs]    Script Date: 19-09-2024 1:01:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HopDongs](
	[MaHopDong] [varchar](30) NOT NULL,
	[LoaiHopDong] [nvarchar](50) NULL,
	[NgayBatDau] [datetime] NULL,
	[NgayKetThuc] [datetime] NULL,
	[GhiChu] [nvarchar](max) NULL,
 CONSTRAINT [PK_HopDongs] PRIMARY KEY CLUSTERED 
(
	[MaHopDong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhenThuongs]    Script Date: 19-09-2024 1:01:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhenThuongs](
	[MaNhanVien] [varchar](30) NOT NULL,
	[ThangThuong] [datetime] NOT NULL,
	[LyDo] [nvarchar](max) NULL,
	[TienThuong] [int] NULL,
 CONSTRAINT [PK_KhenThuongs] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KyLuats]    Script Date: 19-09-2024 1:01:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KyLuats](
	[MaNhanVien] [varchar](30) NOT NULL,
	[LyDo] [nvarchar](max) NULL,
	[ThangKiLuat] [datetime] NOT NULL,
	[TienKyLuat] [int] NULL,
 CONSTRAINT [PK_KyLuats] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LuanChuyenNhanViens]    Script Date: 19-09-2024 1:01:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LuanChuyenNhanViens](
	[MaNhanVien] [varchar](30) NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[NgayChuyen] [datetime] NOT NULL,
	[LyDoChuyen] [nvarchar](max) NULL,
	[PhongBanChuyen] [varchar](30) NULL,
	[PhongBanDen] [varchar](30) NULL,
 CONSTRAINT [PK_LuanChuyenNhanViens] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC,
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Luongs]    Script Date: 19-09-2024 1:01:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Luongs](
	[MaNhanVien] [varchar](30) NOT NULL,
	[LuongToiThieu] [int] NOT NULL,
	[HeSoLuong] [float] NULL,
	[BHXH] [float] NULL,
	[BHYT] [float] NULL,
	[BHTN] [float] NULL,
	[PhuCap] [float] NULL,
	[ThueThuNhap] [float] NULL,
 CONSTRAINT [PK_Luongs] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanViens]    Script Date: 19-09-2024 1:01:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanViens](
	[MaNhanVien] [varchar](30) NOT NULL,
	[MatKhau] [nvarchar](100) NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[NgaySinh] [datetime] NULL,
	[QueQuan] [nvarchar](100) NULL,
	[HinhAnh] [nvarchar](max) NULL,
	[GioiTinh] [int] NULL,
	[DanToc] [nvarchar](10) NULL,
	[sdt_NhanVien] [varchar](11) NULL,
	[MaChucVuNV] [varchar](30) NULL,
	[TrangThai] [bit] NOT NULL,
	[MaPhongBan] [varchar](30) NULL,
	[MaHopDong] [varchar](30) NULL,
	[MaChuyenNganh] [varchar](30) NULL,
	[MaTrinhDoHocVan] [varchar](30) NULL,
	[CMND] [varchar](50) NULL,
 CONSTRAINT [PK_NhanViens] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhongBans]    Script Date: 19-09-2024 1:01:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhongBans](
	[MaPhongBan] [varchar](30) NOT NULL,
	[TenPhongBan] [nvarchar](50) NOT NULL,
	[DiaChi] [nvarchar](50) NULL,
	[sdt_PhongBan] [varchar](11) NULL,
 CONSTRAINT [PK_PhongBans] PRIMARY KEY CLUSTERED 
(
	[MaPhongBan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sysdiagrams]    Script Date: 19-09-2024 1:01:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sysdiagrams](
	[name] [nvarchar](128) NOT NULL,
	[principal_id] [int] NOT NULL,
	[diagram_id] [int] IDENTITY(1,1) NOT NULL,
	[version] [int] NULL,
	[definition] [varbinary](max) NULL,
 CONSTRAINT [PK_sysdiagrams] PRIMARY KEY CLUSTERED 
(
	[diagram_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThoiViecs]    Script Date: 19-09-2024 1:01:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThoiViecs](
	[MaNhanVien] [varchar](30) NOT NULL,
	[Lydo] [nvarchar](max) NULL,
	[NgayThoiViec] [datetime] NOT NULL,
 CONSTRAINT [PK_ThoiViecs] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrinhDoHocVans]    Script Date: 19-09-2024 1:01:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrinhDoHocVans](
	[MaTrinhDoHocVan] [varchar](30) NOT NULL,
	[TenTrinhDo] [nvarchar](max) NOT NULL,
	[HeSoBac] [float] NULL,
 CONSTRAINT [PK_TrinhDoHocVans] PRIMARY KEY CLUSTERED 
(
	[MaTrinhDoHocVan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CapNhatLuongs] ON 

INSERT [dbo].[CapNhatLuongs] ([id], [MaNhanVien], [LuongHienTai], [LuongSauCapNhat], [BHXH], [BHYT], [BHTN], [PhuCap], [ThueThuNhap], [NgayCapNhat], [HeSoLuong]) VALUES (3, N'nhanvien4', 1150000, 1150000, 8, 1.5, 1, NULL, 900, CAST(N'2024-05-27T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[CapNhatLuongs] ([id], [MaNhanVien], [LuongHienTai], [LuongSauCapNhat], [BHXH], [BHYT], [BHTN], [PhuCap], [ThueThuNhap], [NgayCapNhat], [HeSoLuong]) VALUES (4, N'nhanvien4', 1150000, 2900000, 8, 1.5, 100, NULL, 900, CAST(N'2024-05-27T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[CapNhatLuongs] ([id], [MaNhanVien], [LuongHienTai], [LuongSauCapNhat], [BHXH], [BHYT], [BHTN], [PhuCap], [ThueThuNhap], [NgayCapNhat], [HeSoLuong]) VALUES (6, N'nhanvien6', 1150000, 1150000, 8, 1.5, 1, NULL, 15, CAST(N'2024-05-27T00:00:00.000' AS DateTime), 8)
INSERT [dbo].[CapNhatLuongs] ([id], [MaNhanVien], [LuongHienTai], [LuongSauCapNhat], [BHXH], [BHYT], [BHTN], [PhuCap], [ThueThuNhap], [NgayCapNhat], [HeSoLuong]) VALUES (8, N'nhanvien01', 1150000, 1150000, 8, 1.5, 1, NULL, 0, CAST(N'2024-09-18T00:00:00.000' AS DateTime), 2.34)
INSERT [dbo].[CapNhatLuongs] ([id], [MaNhanVien], [LuongHienTai], [LuongSauCapNhat], [BHXH], [BHYT], [BHTN], [PhuCap], [ThueThuNhap], [NgayCapNhat], [HeSoLuong]) VALUES (9, N'nhanvien4', 2900000, 2900000, 8, 1.5, 100, NULL, 900, CAST(N'2024-09-18T00:00:00.000' AS DateTime), 2.34)
SET IDENTITY_INSERT [dbo].[CapNhatLuongs] OFF
GO
INSERT [dbo].[ChiTietLuongs] ([MaChiTietBangLuong], [MaNhanVien], [LuongCoBan], [BHXH], [BHYT], [BHTN], [PhuCap], [ThueThuNhap], [TienThuong], [TienPhat], [NgayNhanLuong], [TongTienLuong]) VALUES (N't10', N'nhanvien01', 2691000, 92000, 17250, 11500, 287500, 0, 0, 0, CAST(N'2024-10-31T00:00:00.000' AS DateTime), N'2857750')
INSERT [dbo].[ChiTietLuongs] ([MaChiTietBangLuong], [MaNhanVien], [LuongCoBan], [BHXH], [BHYT], [BHTN], [PhuCap], [ThueThuNhap], [TienThuong], [TienPhat], [NgayNhanLuong], [TongTienLuong]) VALUES (N't10', N'nhanvien4', 6786000, 232000, 43500, 2900000, 725000, -16849672, 0, 0, CAST(N'2024-10-31T00:00:00.000' AS DateTime), N'21185172')
INSERT [dbo].[ChiTietLuongs] ([MaChiTietBangLuong], [MaNhanVien], [LuongCoBan], [BHXH], [BHYT], [BHTN], [PhuCap], [ThueThuNhap], [TienThuong], [TienPhat], [NgayNhanLuong], [TongTienLuong]) VALUES (N't10', N'nhanvien6', 9200000, 92000, 17250, 11500, 517500, 172500, 0, 0, CAST(N'2024-10-31T00:00:00.000' AS DateTime), N'9424250')
INSERT [dbo].[ChiTietLuongs] ([MaChiTietBangLuong], [MaNhanVien], [LuongCoBan], [BHXH], [BHYT], [BHTN], [PhuCap], [ThueThuNhap], [TienThuong], [TienPhat], [NgayNhanLuong], [TongTienLuong]) VALUES (N't9', N'nhanvien01', 2691000, 92000, 17250, 11500, 287500, 0, 0, 0, CAST(N'2024-09-30T00:00:00.000' AS DateTime), N'2857750')
INSERT [dbo].[ChiTietLuongs] ([MaChiTietBangLuong], [MaNhanVien], [LuongCoBan], [BHXH], [BHYT], [BHTN], [PhuCap], [ThueThuNhap], [TienThuong], [TienPhat], [NgayNhanLuong], [TongTienLuong]) VALUES (N't9', N'nhanvien4', 6786000, 232000, 43500, 2900000, 725000, -16849672, 0, 0, CAST(N'2024-09-30T00:00:00.000' AS DateTime), N'21185172')
INSERT [dbo].[ChiTietLuongs] ([MaChiTietBangLuong], [MaNhanVien], [LuongCoBan], [BHXH], [BHYT], [BHTN], [PhuCap], [ThueThuNhap], [TienThuong], [TienPhat], [NgayNhanLuong], [TongTienLuong]) VALUES (N't9', N'nhanvien6', 9200000, 92000, 17250, 11500, 517500, 172500, 0, 0, CAST(N'2024-09-30T00:00:00.000' AS DateTime), N'9424250')
GO
INSERT [dbo].[ChucVuNhanViens] ([MaChucVuNV], [TenChucVu], [HSPC], [MaPhongBan]) VALUES (N'baove', N'Bảo vệ', 0.25, N'baove')
INSERT [dbo].[ChucVuNhanViens] ([MaChucVuNV], [TenChucVu], [HSPC], [MaPhongBan]) VALUES (N'giamdoc', N'Giám đốc', 0.35, N'giamdoc')
INSERT [dbo].[ChucVuNhanViens] ([MaChucVuNV], [TenChucVu], [HSPC], [MaPhongBan]) VALUES (N'nhanvienbanhang', N'Nhân viên bán hàng', 0.25, N'banhang')
INSERT [dbo].[ChucVuNhanViens] ([MaChucVuNV], [TenChucVu], [HSPC], [MaPhongBan]) VALUES (N'nhanvienketoan', N'Nhân viên kế toán', 0.25, N'ketoan')
INSERT [dbo].[ChucVuNhanViens] ([MaChucVuNV], [TenChucVu], [HSPC], [MaPhongBan]) VALUES (N'nhanvienkythuat', N'Nhân viên kỹ thuật', 0.25, N'kythuat')
INSERT [dbo].[ChucVuNhanViens] ([MaChucVuNV], [TenChucVu], [HSPC], [MaPhongBan]) VALUES (N'nhanvientapvu', N'Nhân viên tạp vụ', 0.25, N'tapvu')
INSERT [dbo].[ChucVuNhanViens] ([MaChucVuNV], [TenChucVu], [HSPC], [MaPhongBan]) VALUES (N'phogiamdoc', N'Phó giám đốc', 0.35, N'giamdoc')
INSERT [dbo].[ChucVuNhanViens] ([MaChucVuNV], [TenChucVu], [HSPC], [MaPhongBan]) VALUES (N'quanlynhansu', N'Quản lý nhân sự', 0.25, N'nhansu')
GO
INSERT [dbo].[ChuyenNganhs] ([MaChuyenNganh], [TenChuyenNganh]) VALUES (N'cntt', N'Công nghệ thông tin')
INSERT [dbo].[ChuyenNganhs] ([MaChuyenNganh], [TenChuyenNganh]) VALUES (N'dientu', N'Điện tử')
INSERT [dbo].[ChuyenNganhs] ([MaChuyenNganh], [TenChuyenNganh]) VALUES (N'kt', N'Kế toán')
INSERT [dbo].[ChuyenNganhs] ([MaChuyenNganh], [TenChuyenNganh]) VALUES (N'qtkd', N'Quản trị kinh doanh')
INSERT [dbo].[ChuyenNganhs] ([MaChuyenNganh], [TenChuyenNganh]) VALUES (N'tm', N'Thợ mộc')
GO
SET IDENTITY_INSERT [dbo].[HeSoLuong] ON 

INSERT [dbo].[HeSoLuong] ([id], [title], [HeSo]) VALUES (1, N'Bậc 1: 3', 3)
INSERT [dbo].[HeSoLuong] ([id], [title], [HeSo]) VALUES (2, N'Bậc 2: 4', 4)
INSERT [dbo].[HeSoLuong] ([id], [title], [HeSo]) VALUES (3, N'Bậc 3: 5', 5)
SET IDENTITY_INSERT [dbo].[HeSoLuong] OFF
GO
INSERT [dbo].[HopDongs] ([MaHopDong], [LoaiHopDong], [NgayBatDau], [NgayKetThuc], [GhiChu]) VALUES (N'nhanvien01', NULL, CAST(N'2024-09-18T00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[HopDongs] ([MaHopDong], [LoaiHopDong], [NgayBatDau], [NgayKetThuc], [GhiChu]) VALUES (N'nhanvien1', NULL, CAST(N'2024-05-27T00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[HopDongs] ([MaHopDong], [LoaiHopDong], [NgayBatDau], [NgayKetThuc], [GhiChu]) VALUES (N'nhanvien2', NULL, CAST(N'2024-05-27T00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[HopDongs] ([MaHopDong], [LoaiHopDong], [NgayBatDau], [NgayKetThuc], [GhiChu]) VALUES (N'nhanvien3', NULL, CAST(N'2024-05-27T00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[HopDongs] ([MaHopDong], [LoaiHopDong], [NgayBatDau], [NgayKetThuc], [GhiChu]) VALUES (N'nhanvien4', NULL, CAST(N'2024-05-27T00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[HopDongs] ([MaHopDong], [LoaiHopDong], [NgayBatDau], [NgayKetThuc], [GhiChu]) VALUES (N'nhanvien5', NULL, CAST(N'2024-05-27T00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[HopDongs] ([MaHopDong], [LoaiHopDong], [NgayBatDau], [NgayKetThuc], [GhiChu]) VALUES (N'nhanvien6', NULL, CAST(N'2024-05-27T00:00:00.000' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Luongs] ([MaNhanVien], [LuongToiThieu], [HeSoLuong], [BHXH], [BHYT], [BHTN], [PhuCap], [ThueThuNhap]) VALUES (N'nhanvien01', 1150000, 2.34, 8, 1.5, 1, 0.25, 0)
INSERT [dbo].[Luongs] ([MaNhanVien], [LuongToiThieu], [HeSoLuong], [BHXH], [BHYT], [BHTN], [PhuCap], [ThueThuNhap]) VALUES (N'nhanvien4', 2900000, 2.34, 8, 1.5, 100, 0.25, 900)
INSERT [dbo].[Luongs] ([MaNhanVien], [LuongToiThieu], [HeSoLuong], [BHXH], [BHYT], [BHTN], [PhuCap], [ThueThuNhap]) VALUES (N'nhanvien6', 1150000, 8, 8, 1.5, 1, 0.45, 15)
GO
INSERT [dbo].[NhanViens] ([MaNhanVien], [MatKhau], [HoTen], [NgaySinh], [QueQuan], [HinhAnh], [GioiTinh], [DanToc], [sdt_NhanVien], [MaChucVuNV], [TrangThai], [MaPhongBan], [MaHopDong], [MaChuyenNganh], [MaTrinhDoHocVan], [CMND]) VALUES (N'admin', N'admin', N'admin', NULL, NULL, N'icon.jpg', 1, NULL, NULL, N'giamdoc', 1, N'giamdoc', N'nhanvien1', N'dientu', N'dh', N'34345')
INSERT [dbo].[NhanViens] ([MaNhanVien], [MatKhau], [HoTen], [NgaySinh], [QueQuan], [HinhAnh], [GioiTinh], [DanToc], [sdt_NhanVien], [MaChucVuNV], [TrangThai], [MaPhongBan], [MaHopDong], [MaChuyenNganh], [MaTrinhDoHocVan], [CMND]) VALUES (N'nhanvien01', N'123', N'Hoàng Thị Kiều Nga', NULL, NULL, N'icon.jpg', 0, NULL, NULL, N'nhanvienbanhang', 1, N'banhang', N'nhanvien01', N'kt', N'thpt', NULL)
INSERT [dbo].[NhanViens] ([MaNhanVien], [MatKhau], [HoTen], [NgaySinh], [QueQuan], [HinhAnh], [GioiTinh], [DanToc], [sdt_NhanVien], [MaChucVuNV], [TrangThai], [MaPhongBan], [MaHopDong], [MaChuyenNganh], [MaTrinhDoHocVan], [CMND]) VALUES (N'nhanvien4', N'nhanvien4', N'nhanvien3', NULL, NULL, N'icon.jpg', 1, NULL, NULL, N'nhanvientapvu', 1, N'ketoan', N'nhanvien4', N'dientu', N'dh', NULL)
INSERT [dbo].[NhanViens] ([MaNhanVien], [MatKhau], [HoTen], [NgaySinh], [QueQuan], [HinhAnh], [GioiTinh], [DanToc], [sdt_NhanVien], [MaChucVuNV], [TrangThai], [MaPhongBan], [MaHopDong], [MaChuyenNganh], [MaTrinhDoHocVan], [CMND]) VALUES (N'nhanvien6', N'nhanvien6', N'nhanvien5', NULL, NULL, N'icon.jpg', 1, NULL, NULL, N'quanlynhansu', 1, N'ketoan', N'nhanvien6', N'cntt', N'dh', NULL)
GO
INSERT [dbo].[PhongBans] ([MaPhongBan], [TenPhongBan], [DiaChi], [sdt_PhongBan]) VALUES (N'banhang', N'Phòng bán hàng', N'Tầng 2, khu C', N'03992422')
INSERT [dbo].[PhongBans] ([MaPhongBan], [TenPhongBan], [DiaChi], [sdt_PhongBan]) VALUES (N'baove', N'Phòng bảo vệ', N'Lầu 7, nhà D', N'03943949')
INSERT [dbo].[PhongBans] ([MaPhongBan], [TenPhongBan], [DiaChi], [sdt_PhongBan]) VALUES (N'giamdoc', N'Phòng giám đốc', N'Phòng 370K2', N'09793892')
INSERT [dbo].[PhongBans] ([MaPhongBan], [TenPhongBan], [DiaChi], [sdt_PhongBan]) VALUES (N'ketoan', N'Kế toán', N'Lầu 3 nhà D', N'089372732')
INSERT [dbo].[PhongBans] ([MaPhongBan], [TenPhongBan], [DiaChi], [sdt_PhongBan]) VALUES (N'kythuat', N'Phòng kỹ thuật', N'Tầng 7, khu A', N'02938434')
INSERT [dbo].[PhongBans] ([MaPhongBan], [TenPhongBan], [DiaChi], [sdt_PhongBan]) VALUES (N'nhansu', N'Phòng nhân sự', N'Phòng 738C1', N'02938483')
INSERT [dbo].[PhongBans] ([MaPhongBan], [TenPhongBan], [DiaChi], [sdt_PhongBan]) VALUES (N'tapvu', N'Phòng tạp vụ', N'Lầu 9, nhà C', N'02938834')
GO
INSERT [dbo].[TrinhDoHocVans] ([MaTrinhDoHocVan], [TenTrinhDo], [HeSoBac]) VALUES (N'cd', N'Tốt nghiệp Cao Đẳng', 0)
INSERT [dbo].[TrinhDoHocVans] ([MaTrinhDoHocVan], [TenTrinhDo], [HeSoBac]) VALUES (N'dh', N'Tốt nghiệp đại học', 0)
INSERT [dbo].[TrinhDoHocVans] ([MaTrinhDoHocVan], [TenTrinhDo], [HeSoBac]) VALUES (N'kbc', N'Không bằng cấp', 0)
INSERT [dbo].[TrinhDoHocVans] ([MaTrinhDoHocVan], [TenTrinhDo], [HeSoBac]) VALUES (N'nghe', N'Tốt nghiệp Trường nghề', 0)
INSERT [dbo].[TrinhDoHocVans] ([MaTrinhDoHocVan], [TenTrinhDo], [HeSoBac]) VALUES (N'th', N'Tốt nghiệp tiểu học', 0)
INSERT [dbo].[TrinhDoHocVans] ([MaTrinhDoHocVan], [TenTrinhDo], [HeSoBac]) VALUES (N'thcs', N'Tốt nghiệp THCS', 0)
INSERT [dbo].[TrinhDoHocVans] ([MaTrinhDoHocVan], [TenTrinhDo], [HeSoBac]) VALUES (N'thpt', N'Tốt nghiệp THPT', 0)
GO
ALTER TABLE [dbo].[CapNhatLuongs]  WITH CHECK ADD  CONSTRAINT [FK_CapNhatLuong_Luong] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[Luongs] ([MaNhanVien])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CapNhatLuongs] CHECK CONSTRAINT [FK_CapNhatLuong_Luong]
GO
ALTER TABLE [dbo].[CapNhatTrinhDoHocVans]  WITH CHECK ADD  CONSTRAINT [FK_CapNhatTrinhDoHocVan_NhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanViens] ([MaNhanVien])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CapNhatTrinhDoHocVans] CHECK CONSTRAINT [FK_CapNhatTrinhDoHocVan_NhanVien]
GO
ALTER TABLE [dbo].[ChiTietLuongs]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietLuong_Luong] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[Luongs] ([MaNhanVien])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ChiTietLuongs] CHECK CONSTRAINT [FK_ChiTietLuong_Luong]
GO
ALTER TABLE [dbo].[KhenThuongs]  WITH CHECK ADD  CONSTRAINT [FK__Thuong__MaNhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanViens] ([MaNhanVien])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KhenThuongs] CHECK CONSTRAINT [FK__Thuong__MaNhanVien]
GO
ALTER TABLE [dbo].[KyLuats]  WITH CHECK ADD  CONSTRAINT [FK_KyLuat_KyLuat] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanViens] ([MaNhanVien])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KyLuats] CHECK CONSTRAINT [FK_KyLuat_KyLuat]
GO
ALTER TABLE [dbo].[LuanChuyenNhanViens]  WITH CHECK ADD  CONSTRAINT [FK__LuanChuyen__MaNhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanViens] ([MaNhanVien])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LuanChuyenNhanViens] CHECK CONSTRAINT [FK__LuanChuyen__MaNhanVien]
GO
ALTER TABLE [dbo].[Luongs]  WITH CHECK ADD  CONSTRAINT [FK_Luong_NhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanViens] ([MaNhanVien])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Luongs] CHECK CONSTRAINT [FK_Luong_NhanVien]
GO
ALTER TABLE [dbo].[NhanViens]  WITH CHECK ADD  CONSTRAINT [FK__NhanVien__MaChuyenNganh] FOREIGN KEY([MaChuyenNganh])
REFERENCES [dbo].[ChuyenNganhs] ([MaChuyenNganh])
GO
ALTER TABLE [dbo].[NhanViens] CHECK CONSTRAINT [FK__NhanVien__MaChuyenNganh]
GO
ALTER TABLE [dbo].[NhanViens]  WITH CHECK ADD  CONSTRAINT [FK__NhanVien__MaHopDong] FOREIGN KEY([MaHopDong])
REFERENCES [dbo].[HopDongs] ([MaHopDong])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NhanViens] CHECK CONSTRAINT [FK__NhanVien__MaHopDong]
GO
ALTER TABLE [dbo].[NhanViens]  WITH CHECK ADD  CONSTRAINT [FK__NhanVien__MaPhongBan] FOREIGN KEY([MaPhongBan])
REFERENCES [dbo].[PhongBans] ([MaPhongBan])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NhanViens] CHECK CONSTRAINT [FK__NhanVien__MaPhongBan]
GO
ALTER TABLE [dbo].[NhanViens]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_ChucVuNhanVien] FOREIGN KEY([MaChucVuNV])
REFERENCES [dbo].[ChucVuNhanViens] ([MaChucVuNV])
GO
ALTER TABLE [dbo].[NhanViens] CHECK CONSTRAINT [FK_NhanVien_ChucVuNhanVien]
GO
ALTER TABLE [dbo].[NhanViens]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_TrinhDoHocVan] FOREIGN KEY([MaTrinhDoHocVan])
REFERENCES [dbo].[TrinhDoHocVans] ([MaTrinhDoHocVan])
GO
ALTER TABLE [dbo].[NhanViens] CHECK CONSTRAINT [FK_NhanVien_TrinhDoHocVan]
GO
ALTER TABLE [dbo].[ThoiViecs]  WITH CHECK ADD  CONSTRAINT [FK__ThoiViec__MaNhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanViens] ([MaNhanVien])
GO
ALTER TABLE [dbo].[ThoiViecs] CHECK CONSTRAINT [FK__ThoiViec__MaNhanVien]
GO
USE [master]
GO
ALTER DATABASE [QuanLyNhanSu_u1] SET  READ_WRITE 
GO
