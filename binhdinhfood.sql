USE [master]
GO
/****** Object:  Database [BinhDinhFood]    Script Date: 02-Oct-22 2:16:56 PM ******/
CREATE DATABASE [BinhDinhFood]
GO
ALTER DATABASE [BinhDinhFood] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BinhDinhFood].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BinhDinhFood] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BinhDinhFood] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BinhDinhFood] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BinhDinhFood] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BinhDinhFood] SET ARITHABORT OFF 
GO
ALTER DATABASE [BinhDinhFood] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BinhDinhFood] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BinhDinhFood] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BinhDinhFood] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BinhDinhFood] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BinhDinhFood] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BinhDinhFood] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BinhDinhFood] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BinhDinhFood] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BinhDinhFood] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BinhDinhFood] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BinhDinhFood] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BinhDinhFood] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BinhDinhFood] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BinhDinhFood] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BinhDinhFood] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [BinhDinhFood] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BinhDinhFood] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BinhDinhFood] SET  MULTI_USER 
GO
ALTER DATABASE [BinhDinhFood] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BinhDinhFood] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BinhDinhFood] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BinhDinhFood] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BinhDinhFood] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BinhDinhFood] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [BinhDinhFood] SET QUERY_STORE = OFF
GO
USE [BinhDinhFood]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 02-Oct-22 2:16:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 02-Oct-22 2:16:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[AdminId] [int] IDENTITY(1,1) NOT NULL,
	[AdminUserName] [nvarchar](50) NOT NULL,
	[AdminPassword] [nvarchar](50) NOT NULL,
	[AdminEmail] [nvarchar](max) NULL,
	[AdminImage] [nvarchar](max) NULL,
	[AdminDateCreated] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[AdminId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Banner]    Script Date: 02-Oct-22 2:16:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Banner](
	[BannerId] [int] IDENTITY(1,1) NOT NULL,
	[BannerName] [nvarchar](50) NULL,
	[ProductDiscount] [int] NULL,
	[BannerPrice] [float] NULL,
	[BannerDescription] [nvarchar](200) NULL,
	[BannerImage] [nvarchar](50) NULL,
	[BannerDateCreated] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Banner] PRIMARY KEY CLUSTERED 
(
	[BannerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Blog]    Script Date: 02-Oct-22 2:16:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blog](
	[BlogId] [int] IDENTITY(1,1) NOT NULL,
	[BlogName] [nvarchar](max) NOT NULL,
	[BlogContent] [nvarchar](max) NULL,
	[BlogImage] [nvarchar](max) NULL,
	[BlogDateCreated] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Blog] PRIMARY KEY CLUSTERED 
(
	[BlogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 02-Oct-22 2:16:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
	[CategoryDateCreated] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 02-Oct-22 2:16:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerFullName] [nvarchar](50) NOT NULL,
	[CustomerUserName] [nvarchar](50) NOT NULL,
	[CustomerPassword] [nvarchar](50) NOT NULL,
	[CustomerDateCreated] [datetime2](7) NOT NULL,
	[CustomerEmail] [nvarchar](50) NOT NULL,
	[CustomerAddress] [nvarchar](50) NOT NULL,
	[CustomerPhone] [nvarchar](max) NULL,
	[CustomerState] [bit] NOT NULL,
	[CustomerImage] [nvarchar](50) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Discount]    Script Date: 02-Oct-22 2:16:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Discount](
	[DiscountId] [int] IDENTITY(1,1) NOT NULL,
	[DateStart] [datetime2](7) NULL,
	[DateEnd] [datetime2](7) NULL,
	[DiscountPercent] [int] NOT NULL,
	[Description] [nvarchar](200) NULL,
 CONSTRAINT [PK_Discount] PRIMARY KEY CLUSTERED 
(
	[DiscountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DiscountDetail]    Script Date: 02-Oct-22 2:16:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiscountDetail](
	[DiscountId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
 CONSTRAINT [PK_DiscountDetail] PRIMARY KEY CLUSTERED 
(
	[DiscountId] ASC,
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Favorite]    Script Date: 02-Oct-22 2:16:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Favorite](
	[ProductId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[PRDateCreated] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Favorite] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC,
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 02-Oct-22 2:16:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[DayOrder] [datetime2](7) NOT NULL,
	[DayDelivery] [datetime2](7) NOT NULL,
	[PaidState] [bit] NOT NULL,
	[DeliveryState] [bit] NOT NULL,
	[TotalMoney] [float] NOT NULL,
	[CustomerId] [int] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 02-Oct-22 2:16:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[UnitPrice] [money] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC,
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 02-Oct-22 2:16:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](100) NOT NULL,
	[ProductPrice] [float] NOT NULL,
	[ProductDescription] [nvarchar](max) NULL,
	[ProductAmount] [int] NOT NULL,
	[ProductDiscount] [int] NOT NULL,
	[ProductImage] [nvarchar](max) NULL,
	[ProductDateCreated] [datetime2](7) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[ProductRating] [int] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductRating]    Script Date: 02-Oct-22 2:16:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductRating](
	[ProductRatingId] [int] IDENTITY(1,1) NOT NULL,
	[Stars] [int] NOT NULL,
	[RatingContent] [nvarchar](200) NULL,
	[PRDateCreated] [datetime2](7) NOT NULL,
	[ProductId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
 CONSTRAINT [PK_ProductRating] PRIMARY KEY CLUSTERED 
(
	[ProductRatingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Token]    Script Date: 02-Oct-22 2:16:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Token](
	[TokenID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerUserName] [nvarchar](max) NOT NULL,
	[TokenValue] [nvarchar](max) NOT NULL,
	[Expiry] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Token] PRIMARY KEY CLUSTERED 
(
	[TokenID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220906155452_create-new-database', N'6.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220929024440_AddDiscountDicountDetailTable', N'6.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221002025630_ADDfieldsRatinginProduct', N'6.0.8')
GO
SET IDENTITY_INSERT [dbo].[Admin] ON 

INSERT [dbo].[Admin] ([AdminId], [AdminUserName], [AdminPassword], [AdminEmail], [AdminImage], [AdminDateCreated]) VALUES (1, N'truongnhon', N'C4-CA-42-38-A0-B9-23-82-0D-CC-50-9A-6F-75-84-9B', N'vothuongtruongnhon2002@gmail.com', N'nhon.png', CAST(N'2022-08-19T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Admin] ([AdminId], [AdminUserName], [AdminPassword], [AdminEmail], [AdminImage], [AdminDateCreated]) VALUES (3, N'tai', N'C4-CA-42-38-A0-B9-23-82-0D-CC-50-9A-6F-75-84-9B', N'phamductaisomuc@gmail.com', N'null', CAST(N'2022-04-09T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Admin] ([AdminId], [AdminUserName], [AdminPassword], [AdminEmail], [AdminImage], [AdminDateCreated]) VALUES (4, N'thai', N'C4-CA-42-38-A0-B9-23-82-0D-CC-50-9A-6F-75-84-9B', N'phamhongthai@gmail.com', NULL, CAST(N'2022-04-09T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Admin] ([AdminId], [AdminUserName], [AdminPassword], [AdminEmail], [AdminImage], [AdminDateCreated]) VALUES (5, N'sa', N'C4-CA-42-38-A0-B9-23-82-0D-CC-50-9A-6F-75-84-9B', N'vothuongtruongnhon2002@gmail.com', N'nhon.png', CAST(N'2022-04-09T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Admin] OFF
GO
SET IDENTITY_INSERT [dbo].[Banner] ON 

INSERT [dbo].[Banner] ([BannerId], [BannerName], [ProductDiscount], [BannerPrice], [BannerDescription], [BannerImage], [BannerDateCreated]) VALUES (6, N'Chả cá Quy Nhơn', 0, 100000, N'banner1sss', N'slide_home_1.jpg', CAST(N'2022-08-19T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Banner] ([BannerId], [BannerName], [ProductDiscount], [BannerPrice], [BannerDescription], [BannerImage], [BannerDateCreated]) VALUES (8, N'Gỏi cá Chình', 0, 200000, N'banner2', N'slide_home_2.jpg', CAST(N'2022-08-19T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Banner] ([BannerId], [BannerName], [ProductDiscount], [BannerPrice], [BannerDescription], [BannerImage], [BannerDateCreated]) VALUES (9, N'Nem chợ huyện', 0, 150000, N'banner3', N'slide_home_3.jpg', CAST(N'2022-08-19T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Banner] ([BannerId], [BannerName], [ProductDiscount], [BannerPrice], [BannerDescription], [BannerImage], [BannerDateCreated]) VALUES (10, N'Nem chợ huyện', 0, 150000, N'banner4', N'slide_home_4.jpg', CAST(N'2022-08-19T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Banner] OFF
GO
SET IDENTITY_INSERT [dbo].[Blog] ON 

INSERT [dbo].[Blog] ([BlogId], [BlogName], [BlogContent], [BlogImage], [BlogDateCreated]) VALUES (1, N'Mực rim Quy Nhơn', N'Mực rim là món ăn phổ biến khiến du thích yêu thích có mặt ở hầu hết những vùng biển lớn. Tuy nhiên mực rim hay còn gọi là mực ngào Bình Định có một hương vị thơm ngon rất riêng từ vùng biển duyên hải miền Trung. Mực rim Quy Nhơn được người dân làm từ những con mực tươi nhất và hương vị không nơi nào giống được.

Với hương thơm ngon đặc biệt cùng vị cay cay kích thích vị giác, mực rim trở thành món ăn vặt siêu ngon và được mọi người vô cùng yêu thích. Đồng thời, với những hũ mực rim được làm sẵn giúp bạn có thể dễ dàng lựa chọn đặc sản Bình Định này để làm quà tặng.', N'mucrim.png', CAST(N'2022-08-25T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Blog] ([BlogId], [BlogName], [BlogContent], [BlogImage], [BlogDateCreated]) VALUES (2, N'Chả Tré rơm', N'Với tên gọi độc và lạ của món Chả Tré, món đặc sản Bình Định này đã gợi nên sự tò mò với nhiều du khách muốn tìm hiểu và được thử món ăn độc đáo này. Mặc dù đã có mặt phổ biến khắp các tỉnh thành Trung Trung bộ, nhưng hương vị thơm ngon nhất vẫn là chả Tré Bình Định với cách làm và công thức chỉ vùng đất Bình Định mới làm nên được.

Thành phần nguyên liệu làm chả Tré cũng tương tự với các loại nem, bì của miền bắc. Nhưng Tré Bình Định được người dân nơi đây khéo léo thay thế bằng nhiều loại nguyên liệu khác như tai heo, lỗ mũi heo, da heo, thịt ba chỉ,...Tré cũng thích hợp để trở thành món quà mang về khi bạn đến thăm Bình Định.', N'chatre.png', CAST(N'2022-08-25T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Blog] ([BlogId], [BlogName], [BlogContent], [BlogImage], [BlogDateCreated]) VALUES (3, N'Chả cá Quy Nhơn', N'Mặc dù chả cá có thể là đặc sản và có mặt ở nhiều nơi nhưng không phải hương vị chả cá nào cũng như nhau. Sở dĩ chả cá Quy Nhơn là một trong các đặc sản Bình Định nổi tiếng vì vị ngon và lạ đặc trưng. Với nguyên liệu được tuyển chọn từ những con cá biển tươi ngon nhất và công thức chế biến độc quyền của người dân đã tạo nên sự khác biệt cho chả cá Quy Nhơn.

Chả cá Quy Nhơn phổ biến có 2 loại là chả hấp và chả chiên. Ngoài việc thưởng thức thực tiếp miếng chả dai, giòn, thơm ngon đặc biệt, các bạn có thể dùng chả cá này để làm “topping” cho các món ăn khác như cơm, bún, phở. Đây cũng là một lựa chọn thích hợp để bạn mua về làm quà cho người thân và bạn bè nữa đó.', N'chaca.png', CAST(N'2022-08-25T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Blog] ([BlogId], [BlogName], [BlogContent], [BlogImage], [BlogDateCreated]) VALUES (4, N'Bánh Xèo Mỹ Cang', N'Đây là một món ngon đặc sản Quy Nhơn rất đỗi bình dị nhưng được du khách rất yêu thích. Nó được bày bán ở hầu hết các quán xá vỉa hè ở Bình Định. Bánh xèo được làm được những  nguyên liệu đơn giản như thịt heo băm nhuyễn, hành phi, rau thơm, trứng và bột gạo. Gaọ sẽ được tuyển chọn những những gạo to chắc mẩy không bị sâu để tạo độ ngọt của bánh. Gạo sẽ được đem đi xay và nấu bột thành một thứ hỗn hợp dẻo, đập trứng cho thịt băm và một số loại gia vị vào. Bên cạnh đó đac có một cái chảo đang được đun nóng. Người nấu sẽ múc từng múc lên chảo để tráng những miếng bánh, dải thịt băm nhuyễn đã được xào chín lên bên trên bề mặt bánh và guộn đều tay để bánh to tròn và đẹp. Hoặc có thể là những con tôm tươi ngon. Khi  ăn ăn kèm với rau thơm và nước chấm.

', N'banh-xeo-my-cang-dac-san-binh-dinh.vntrip-e1501650332846.jpg', CAST(N'2022-09-03T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Blog] ([BlogId], [BlogName], [BlogContent], [BlogImage], [BlogDateCreated]) VALUES (5, N'Bánh tráng nước dừa', N'Khi đến du lịch Bình Định không thể không nhắc tới  món bánh tráng nước dừa. Đây là một món đặc sản nơi xứ dừa. Công đoạn chế biến bánh không quá cầu kì nhưng đòi hỏi sự tỉ mỉ, có kinh nghiệm của người tráng bánh. Nguyên liệu của bánh chủ yếu là Củ Mì ( củ sắn) được sắt nhỏ, xay lấy nước. Cơm dừa được nạo thành sợi nhỏ,  nước dừa và vừng đen. Tất cả đều được đổ chung vào một nồi lớn, trộn đều cho các gia vị hòa quyện cùng với nhau và được đun nóng. Bên cạnh đó có một chảo đang được đun nóng. Khi chảo nóng lên người tráng bánh sẽ dùng một cái gáo làm bằng sọ dừa có cán dài múc từng gáo nước bánh lên chảo và tráng đều. Tráng bánh phải đều tay để cơm dừa và vừng đen được dàn đều mặt bánh. Bánh phải tròn mỏng và không bị chỗ dày, chỗ mỏng thì mới là bánh đạt chuẩn. cứ tráng được mười chiếc  bánh thì đem ra phơi. khi ăn bạn cần nướng lên để bánh có độ phồng và dậy hết mùi thơm của vừng, của nước cốt dừa và cơm dừa. Có thể ăn bánh thay cơm ăn chỉ thấy no mà không thấy chán.', N'Banh-trang-nuoc-dua-am-thuc-binh-dinh.jpg', CAST(N'2022-09-03T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Blog] ([BlogId], [BlogName], [BlogContent], [BlogImage], [BlogDateCreated]) VALUES (6, N'Bún song  thần', N'Bún song thần có chút khác biệt với các loại bún thông thường khác bởi thay vì sợi bún được làm từ bột gạo hay bột củ mì kéo sợi thì bún song thần lại được làm từ bột đậu xanh. Bún Song thần đặc sản Bình Định có màu trắng đặc trưng. Bún được đặt song  song bên nhau nên có tên là bún song thần. Món đặc sản này có giá trị dinh dưỡng cao hơn các loại bún khác. Tuy nhiên giá thành của bún khá cao bởi 5kg đậu xanh chỉ là được 1kg bún.', N'bat-bun-song-than.jpg', CAST(N'2022-09-03T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Blog] ([BlogId], [BlogName], [BlogContent], [BlogImage], [BlogDateCreated]) VALUES (7, N'Cua Huỳnh Đế', N'Món món hải sản ngon nức tiếng ở Bình Định. Cua Huỳnh đếđược xem là vua của các loại cua bởi nó có mai đỏ vàng như một bộ long bào uy nghi của các nhà vua, hai bên có gai li ti sắc nhọn, hai chiếc càng to chắc khỏe. Cua thường sống trong những ngách đá trên biển Bình Định. Cua Huỳnh Đế có thịt thơm, chắc  và có thể chế biến thành nhiều món ăn ngon khác nhau như cua nướng, cua hấp… đều rất thơm ngon.', N'cua-huynh-de-vntrip-e1536313616403.jpg', CAST(N'2022-09-03T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Blog] ([BlogId], [BlogName], [BlogContent], [BlogImage], [BlogDateCreated]) VALUES (8, N'Gỏi cá chích', N'Cá Chích là loại cá nước ngọt sống ở các sông hồ ao suối. Cũng bởi Bình Định có nhiều sông hồ nên đây là môi trường thuận lợi để loài đặc sản này sinh sống. Cá Chích đặc sản Bình Định có thân  hình nhỏ, dài. Cá Chích sau khi được  đánh bắt lên sẽ được làm  sạch  và chiên giòn. Vì  là loài cá có kích cỡ nhỏ nên  khi ăn  người ta sẽ kẹp cả con cá đã được chiên vàng ăn với bánh phở cuốn, kèm rau thơm, dưa chuột. Cá ngọt thịt nên bạn ăn sẽ không bị chán. Tuy Nhiên nếu bạn là tín đồ gỏi sống bạn có thể được  thưởng thức gỏi cá chích với những thớ thịt  đc lọc xương làm sạch.

', N'goi-ca-chinh-binh-dinh.jpg', CAST(N'2022-09-03T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Blog] ([BlogId], [BlogName], [BlogContent], [BlogImage], [BlogDateCreated]) VALUES (9, N'Bánh hồng Tam Quan', N'Bánh hồng Tam Quan là một trong những món đặc sản của Bình Định, được xem như biểu trưng cho tin vui, thường xuất hiện trong các dịp cưới hỏi của người dân nơi đây.

Điều đặc biệt bánh hồng Tam Quan là bánh được làm từ gạo nếp Ngự nổi tiếng dẻo thơm. Do hoàn toàn không có chất bảo quản nên bánh chỉ để được 5 ngày thôi bạn nhé.', N'banhhong.jpg', CAST(N'2022-09-03T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Blog] ([BlogId], [BlogName], [BlogContent], [BlogImage], [BlogDateCreated]) VALUES (10, N'Bánh tráng chả cá', N'Bánh tráng chả cá là một trong những đặc sản nổi tiếng gần xa của Bình Định. Bánh tráng chả cá được làm từ nguyên liệu chính là cá cùng một ít gia vị và bột năng. Để món ăn đúng vị hơn bạn nên ăn kèm với rau răm nhé.', N'banhtrangchaca.jpg', CAST(N'2022-09-03T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Blog] ([BlogId], [BlogName], [BlogContent], [BlogImage], [BlogDateCreated]) VALUES (11, N'Mực ngào vị tỏi', N'Nếu đã đến với đất Bình Định thì bạn nhất định phải thử qua món mực ngào vị tỏi nhé. Món ăn là sự hòa quyện giữa vị mực vừa tươi vừa giòn cùng vị cay đặc trưng của ớt và tỏi. Bạn nhớ bảo quản món này ở nhiệt độ thoáng mát nha.', N'Mực ngào vị tỏi', CAST(N'2022-09-03T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Blog] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [CategoryDateCreated]) VALUES (1, N'Đồ khô', CAST(N'2022-08-19T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [CategoryDateCreated]) VALUES (6, N'Bánh truyền thống', CAST(N'2022-08-19T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [CategoryDateCreated]) VALUES (7, N'Đồ đặc sản', CAST(N'2022-08-19T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([CustomerId], [CustomerFullName], [CustomerUserName], [CustomerPassword], [CustomerDateCreated], [CustomerEmail], [CustomerAddress], [CustomerPhone], [CustomerState], [CustomerImage]) VALUES (1, N'Võ Thương Trường Nhơn', N'truongnhon', N'C4-CA-42-38-A0-B9-23-82-0D-CC-50-9A-6F-75-84-9B', CAST(N'2022-08-19T00:00:00.0000000' AS DateTime2), N'vothuongtruongnhon2002@gmail.com', N'48/29/8 Lê Văn Hưng, Quy Nhơn', N'0905726748', 1, N'nhon.jpg')
INSERT [dbo].[Customer] ([CustomerId], [CustomerFullName], [CustomerUserName], [CustomerPassword], [CustomerDateCreated], [CustomerEmail], [CustomerAddress], [CustomerPhone], [CustomerState], [CustomerImage]) VALUES (2, N'Nguyễn Hồng Thái', N'thai', N'C4-CA-42-38-A0-B9-23-82-0D-CC-50-9A-6F-75-84-9B', CAST(N'2022-08-19T00:00:00.0000000' AS DateTime2), N'phamhongthai@gmail.com', N'Tây Ninh', N'0905726748', 1, N'thai.jpg')
INSERT [dbo].[Customer] ([CustomerId], [CustomerFullName], [CustomerUserName], [CustomerPassword], [CustomerDateCreated], [CustomerEmail], [CustomerAddress], [CustomerPhone], [CustomerState], [CustomerImage]) VALUES (3, N'Phạm Đức Tài', N'tai', N'C4-CA-42-38-A0-B9-23-82-0D-CC-50-9A-6F-75-84-9B', CAST(N'2022-08-19T00:00:00.0000000' AS DateTime2), N'taiphamduc@gmail.com', N'Nam Định', N'0905726748', 1, N'tai.jpg')
INSERT [dbo].[Customer] ([CustomerId], [CustomerFullName], [CustomerUserName], [CustomerPassword], [CustomerDateCreated], [CustomerEmail], [CustomerAddress], [CustomerPhone], [CustomerState], [CustomerImage]) VALUES (4, N'dotnet evil', N'nhondeptrai', N'C4-CA-42-38-A0-B9-23-82-0D-CC-50-9A-6F-75-84-9B', CAST(N'2022-08-28T12:23:12.2852149' AS DateTime2), N'vothuongtruongnhon2002@gmail.com', N'Saigon', N'0905726748', 1, N'0d45bade8d1e402fa2615717f3808101.jpg')
INSERT [dbo].[Customer] ([CustomerId], [CustomerFullName], [CustomerUserName], [CustomerPassword], [CustomerDateCreated], [CustomerEmail], [CustomerAddress], [CustomerPhone], [CustomerState], [CustomerImage]) VALUES (16, N'Jeff Bezos', N'acc1', N'C4-CA-42-38-A0-B9-23-82-0D-CC-50-9A-6F-75-84-9B', CAST(N'2022-08-30T22:58:33.6830114' AS DateTime2), N'vothuongtruongnhon2002@gmail.com', N'America', N'0905726748', 1, N'avatar.jpg')
INSERT [dbo].[Customer] ([CustomerId], [CustomerFullName], [CustomerUserName], [CustomerPassword], [CustomerDateCreated], [CustomerEmail], [CustomerAddress], [CustomerPhone], [CustomerState], [CustomerImage]) VALUES (18, N'Bill Gate', N'acc2', N'C4-CA-42-38-A0-B9-23-82-0D-CC-50-9A-6F-75-84-9B', CAST(N'2022-09-01T11:32:18.5884344' AS DateTime2), N'vothuongtruongnhon2002@gmail.com', N'NewYork', N'0905726748', 1, N'avatar.jpg')
INSERT [dbo].[Customer] ([CustomerId], [CustomerFullName], [CustomerUserName], [CustomerPassword], [CustomerDateCreated], [CustomerEmail], [CustomerAddress], [CustomerPhone], [CustomerState], [CustomerImage]) VALUES (19, N'Edward NewGate', N'acc3', N'C4-CA-42-38-A0-B9-23-82-0D-CC-50-9A-6F-75-84-9B', CAST(N'2022-09-04T00:00:00.0000000' AS DateTime2), N'vothuongtruongnhon2002@gmail.com', N'NewWorld', N'0905726748', 1, N'avatar.jpg')
INSERT [dbo].[Customer] ([CustomerId], [CustomerFullName], [CustomerUserName], [CustomerPassword], [CustomerDateCreated], [CustomerEmail], [CustomerAddress], [CustomerPhone], [CustomerState], [CustomerImage]) VALUES (22, N'Monkey D Luffy', N'acc4', N'C4-CA-42-38-A0-B9-23-82-0D-CC-50-9A-6F-75-84-9B', CAST(N'2022-09-04T00:00:00.0000000' AS DateTime2), N'vothuongtruongnhon2002@gmail.com', N'East Sea', N'0905726748', 1, N'avatar.jpg')
INSERT [dbo].[Customer] ([CustomerId], [CustomerFullName], [CustomerUserName], [CustomerPassword], [CustomerDateCreated], [CustomerEmail], [CustomerAddress], [CustomerPhone], [CustomerState], [CustomerImage]) VALUES (23, N'Ái Quyên President', N'acc5', N'C4-CA-42-38-A0-B9-23-82-0D-CC-50-9A-6F-75-84-9B', CAST(N'2022-09-04T00:00:00.0000000' AS DateTime2), N'vothuongtruongnhon2002@gmail.com', N'Bình Định', N'0905726748', 1, N'avatar.jpg')
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
INSERT [dbo].[Favorite] ([ProductId], [CustomerId], [PRDateCreated]) VALUES (3, 1, CAST(N'2022-09-06T23:07:07.2327191' AS DateTime2))
INSERT [dbo].[Favorite] ([ProductId], [CustomerId], [PRDateCreated]) VALUES (6, 1, CAST(N'2022-09-06T23:07:06.4396086' AS DateTime2))
INSERT [dbo].[Favorite] ([ProductId], [CustomerId], [PRDateCreated]) VALUES (7, 1, CAST(N'2022-09-06T23:07:05.3108839' AS DateTime2))
INSERT [dbo].[Favorite] ([ProductId], [CustomerId], [PRDateCreated]) VALUES (16, 1, CAST(N'2022-09-06T23:07:11.6383891' AS DateTime2))
INSERT [dbo].[Favorite] ([ProductId], [CustomerId], [PRDateCreated]) VALUES (19, 1, CAST(N'2022-09-06T23:03:14.8057723' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([OrderId], [DayOrder], [DayDelivery], [PaidState], [DeliveryState], [TotalMoney], [CustomerId]) VALUES (1, CAST(N'2022-08-19T00:00:00.0000000' AS DateTime2), CAST(N'2022-08-25T00:00:00.0000000' AS DateTime2), 1, 1, 100000, 1)
INSERT [dbo].[Order] ([OrderId], [DayOrder], [DayDelivery], [PaidState], [DeliveryState], [TotalMoney], [CustomerId]) VALUES (2, CAST(N'2022-08-19T00:00:00.0000000' AS DateTime2), CAST(N'2022-08-25T00:00:00.0000000' AS DateTime2), 1, 0, 500000, 2)
INSERT [dbo].[Order] ([OrderId], [DayOrder], [DayDelivery], [PaidState], [DeliveryState], [TotalMoney], [CustomerId]) VALUES (3, CAST(N'2022-08-19T00:00:00.0000000' AS DateTime2), CAST(N'2022-08-25T00:00:00.0000000' AS DateTime2), 0, 0, 400000, 3)
INSERT [dbo].[Order] ([OrderId], [DayOrder], [DayDelivery], [PaidState], [DeliveryState], [TotalMoney], [CustomerId]) VALUES (4, CAST(N'2022-08-19T00:00:00.0000000' AS DateTime2), CAST(N'2022-08-25T00:00:00.0000000' AS DateTime2), 1, 1, 200000, 1)
INSERT [dbo].[Order] ([OrderId], [DayOrder], [DayDelivery], [PaidState], [DeliveryState], [TotalMoney], [CustomerId]) VALUES (5, CAST(N'2022-08-19T00:00:00.0000000' AS DateTime2), CAST(N'2022-08-25T00:00:00.0000000' AS DateTime2), 1, 0, 100000, 2)
INSERT [dbo].[Order] ([OrderId], [DayOrder], [DayDelivery], [PaidState], [DeliveryState], [TotalMoney], [CustomerId]) VALUES (6, CAST(N'2022-08-19T00:00:00.0000000' AS DateTime2), CAST(N'2022-08-25T00:00:00.0000000' AS DateTime2), 1, 1, 50000, 1)
INSERT [dbo].[Order] ([OrderId], [DayOrder], [DayDelivery], [PaidState], [DeliveryState], [TotalMoney], [CustomerId]) VALUES (7, CAST(N'2022-08-29T22:45:37.5985233' AS DateTime2), CAST(N'2022-09-01T22:45:37.5985233' AS DateTime2), 0, 0, 330000, 4)
INSERT [dbo].[Order] ([OrderId], [DayOrder], [DayDelivery], [PaidState], [DeliveryState], [TotalMoney], [CustomerId]) VALUES (8, CAST(N'2022-08-29T22:45:37.5795433' AS DateTime2), CAST(N'2022-09-01T22:45:37.5795732' AS DateTime2), 1, 0, 330000, 4)
INSERT [dbo].[Order] ([OrderId], [DayOrder], [DayDelivery], [PaidState], [DeliveryState], [TotalMoney], [CustomerId]) VALUES (9, CAST(N'2021-08-29T22:48:21.4314529' AS DateTime2), CAST(N'2022-09-01T22:48:21.4314819' AS DateTime2), 1, 0, 50000, 4)
INSERT [dbo].[Order] ([OrderId], [DayOrder], [DayDelivery], [PaidState], [DeliveryState], [TotalMoney], [CustomerId]) VALUES (10, CAST(N'2022-09-01T22:49:08.5078405' AS DateTime2), CAST(N'2022-09-01T22:49:08.5078406' AS DateTime2), 1, 1, 330000, 4)
INSERT [dbo].[Order] ([OrderId], [DayOrder], [DayDelivery], [PaidState], [DeliveryState], [TotalMoney], [CustomerId]) VALUES (11, CAST(N'2022-09-02T13:11:13.3004576' AS DateTime2), CAST(N'2022-09-02T13:11:13.3004893' AS DateTime2), 1, 0, 230000, 4)
INSERT [dbo].[Order] ([OrderId], [DayOrder], [DayDelivery], [PaidState], [DeliveryState], [TotalMoney], [CustomerId]) VALUES (12, CAST(N'2022-09-01T11:32:38.1410296' AS DateTime2), CAST(N'2022-09-04T11:32:38.1410617' AS DateTime2), 1, 0, 130000, 18)
INSERT [dbo].[Order] ([OrderId], [DayOrder], [DayDelivery], [PaidState], [DeliveryState], [TotalMoney], [CustomerId]) VALUES (13, CAST(N'2022-09-03T13:08:56.5749476' AS DateTime2), CAST(N'2022-09-06T13:08:56.5749769' AS DateTime2), 1, 1, 72500, 4)
INSERT [dbo].[Order] ([OrderId], [DayOrder], [DayDelivery], [PaidState], [DeliveryState], [TotalMoney], [CustomerId]) VALUES (14, CAST(N'2022-09-03T13:43:14.1481958' AS DateTime2), CAST(N'2022-09-06T13:43:14.1482246' AS DateTime2), 1, 0, 30000, 4)
INSERT [dbo].[Order] ([OrderId], [DayOrder], [DayDelivery], [PaidState], [DeliveryState], [TotalMoney], [CustomerId]) VALUES (15, CAST(N'2022-09-04T13:57:16.1185248' AS DateTime2), CAST(N'2022-09-07T13:57:16.1185768' AS DateTime2), 0, 1, 240000, 1)
INSERT [dbo].[Order] ([OrderId], [DayOrder], [DayDelivery], [PaidState], [DeliveryState], [TotalMoney], [CustomerId]) VALUES (16, CAST(N'2022-09-05T09:17:41.5758479' AS DateTime2), CAST(N'2022-09-08T09:17:41.5758949' AS DateTime2), 0, 0, 120000, 1)
INSERT [dbo].[Order] ([OrderId], [DayOrder], [DayDelivery], [PaidState], [DeliveryState], [TotalMoney], [CustomerId]) VALUES (17, CAST(N'2022-09-05T09:47:27.6758837' AS DateTime2), CAST(N'2022-09-08T09:47:27.6759421' AS DateTime2), 0, 0, 89000, 1)
INSERT [dbo].[Order] ([OrderId], [DayOrder], [DayDelivery], [PaidState], [DeliveryState], [TotalMoney], [CustomerId]) VALUES (18, CAST(N'2022-09-05T09:49:36.9039283' AS DateTime2), CAST(N'2022-09-08T09:49:36.9039563' AS DateTime2), 0, 0, 172500, 1)
INSERT [dbo].[Order] ([OrderId], [DayOrder], [DayDelivery], [PaidState], [DeliveryState], [TotalMoney], [CustomerId]) VALUES (19, CAST(N'2022-09-05T09:49:46.4593172' AS DateTime2), CAST(N'2022-09-08T09:49:46.4593177' AS DateTime2), 0, 0, 30000, 1)
INSERT [dbo].[Order] ([OrderId], [DayOrder], [DayDelivery], [PaidState], [DeliveryState], [TotalMoney], [CustomerId]) VALUES (20, CAST(N'2022-09-05T09:51:42.5923898' AS DateTime2), CAST(N'2022-09-08T09:51:42.5924147' AS DateTime2), 0, 0, 120000, 1)
INSERT [dbo].[Order] ([OrderId], [DayOrder], [DayDelivery], [PaidState], [DeliveryState], [TotalMoney], [CustomerId]) VALUES (21, CAST(N'2022-09-05T09:52:02.2684095' AS DateTime2), CAST(N'2022-09-08T09:52:02.2684102' AS DateTime2), 0, 0, 30000, 1)
INSERT [dbo].[Order] ([OrderId], [DayOrder], [DayDelivery], [PaidState], [DeliveryState], [TotalMoney], [CustomerId]) VALUES (22, CAST(N'2022-09-05T09:52:07.5483973' AS DateTime2), CAST(N'2022-09-08T09:52:07.5483977' AS DateTime2), 0, 0, 30000, 1)
INSERT [dbo].[Order] ([OrderId], [DayOrder], [DayDelivery], [PaidState], [DeliveryState], [TotalMoney], [CustomerId]) VALUES (23, CAST(N'2022-09-05T09:53:43.3561547' AS DateTime2), CAST(N'2022-09-08T09:53:43.3561843' AS DateTime2), 0, 0, 30000, 1)
INSERT [dbo].[Order] ([OrderId], [DayOrder], [DayDelivery], [PaidState], [DeliveryState], [TotalMoney], [CustomerId]) VALUES (24, CAST(N'2022-09-05T09:54:04.6676561' AS DateTime2), CAST(N'2022-09-08T09:54:04.6676813' AS DateTime2), 0, 0, 30000, 1)
INSERT [dbo].[Order] ([OrderId], [DayOrder], [DayDelivery], [PaidState], [DeliveryState], [TotalMoney], [CustomerId]) VALUES (25, CAST(N'2022-09-05T09:54:41.9787114' AS DateTime2), CAST(N'2022-09-08T09:54:41.9787368' AS DateTime2), 0, 0, 30000, 1)
INSERT [dbo].[Order] ([OrderId], [DayOrder], [DayDelivery], [PaidState], [DeliveryState], [TotalMoney], [CustomerId]) VALUES (26, CAST(N'2022-09-05T09:54:49.0441385' AS DateTime2), CAST(N'2022-09-08T09:54:49.0441398' AS DateTime2), 0, 0, 30000, 1)
INSERT [dbo].[Order] ([OrderId], [DayOrder], [DayDelivery], [PaidState], [DeliveryState], [TotalMoney], [CustomerId]) VALUES (27, CAST(N'2022-09-05T09:55:52.4174974' AS DateTime2), CAST(N'2022-09-08T09:55:52.4175418' AS DateTime2), 0, 0, 30000, 1)
INSERT [dbo].[Order] ([OrderId], [DayOrder], [DayDelivery], [PaidState], [DeliveryState], [TotalMoney], [CustomerId]) VALUES (28, CAST(N'2022-09-05T09:56:15.6350077' AS DateTime2), CAST(N'2022-09-08T09:56:15.6350096' AS DateTime2), 0, 0, 30000, 1)
INSERT [dbo].[Order] ([OrderId], [DayOrder], [DayDelivery], [PaidState], [DeliveryState], [TotalMoney], [CustomerId]) VALUES (29, CAST(N'2022-09-05T09:56:49.3548958' AS DateTime2), CAST(N'2022-09-08T09:56:49.3549240' AS DateTime2), 0, 0, 30000, 1)
INSERT [dbo].[Order] ([OrderId], [DayOrder], [DayDelivery], [PaidState], [DeliveryState], [TotalMoney], [CustomerId]) VALUES (30, CAST(N'2022-09-05T09:58:13.1324436' AS DateTime2), CAST(N'2022-09-08T09:58:13.1324722' AS DateTime2), 0, 0, 30000, 1)
INSERT [dbo].[Order] ([OrderId], [DayOrder], [DayDelivery], [PaidState], [DeliveryState], [TotalMoney], [CustomerId]) VALUES (31, CAST(N'2022-09-05T10:00:05.0302378' AS DateTime2), CAST(N'2022-09-08T10:00:05.0302670' AS DateTime2), 0, 0, 30000, 1)
INSERT [dbo].[Order] ([OrderId], [DayOrder], [DayDelivery], [PaidState], [DeliveryState], [TotalMoney], [CustomerId]) VALUES (32, CAST(N'2022-09-05T10:00:11.3521948' AS DateTime2), CAST(N'2022-09-08T10:00:11.3521957' AS DateTime2), 0, 0, 30000, 1)
INSERT [dbo].[Order] ([OrderId], [DayOrder], [DayDelivery], [PaidState], [DeliveryState], [TotalMoney], [CustomerId]) VALUES (33, CAST(N'2022-09-05T10:00:19.5624530' AS DateTime2), CAST(N'2022-09-08T10:00:19.5624536' AS DateTime2), 0, 0, 30000, 1)
INSERT [dbo].[Order] ([OrderId], [DayOrder], [DayDelivery], [PaidState], [DeliveryState], [TotalMoney], [CustomerId]) VALUES (34, CAST(N'2022-09-05T10:00:30.4814112' AS DateTime2), CAST(N'2022-09-08T10:00:30.4814115' AS DateTime2), 0, 0, 30000, 1)
INSERT [dbo].[Order] ([OrderId], [DayOrder], [DayDelivery], [PaidState], [DeliveryState], [TotalMoney], [CustomerId]) VALUES (35, CAST(N'2022-09-05T10:00:43.4498740' AS DateTime2), CAST(N'2022-09-08T10:00:43.4498743' AS DateTime2), 0, 0, 30000, 1)
INSERT [dbo].[Order] ([OrderId], [DayOrder], [DayDelivery], [PaidState], [DeliveryState], [TotalMoney], [CustomerId]) VALUES (36, CAST(N'2022-09-05T10:00:58.5639621' AS DateTime2), CAST(N'2022-09-08T10:00:58.5639627' AS DateTime2), 0, 0, 30000, 1)
INSERT [dbo].[Order] ([OrderId], [DayOrder], [DayDelivery], [PaidState], [DeliveryState], [TotalMoney], [CustomerId]) VALUES (37, CAST(N'2022-09-05T10:01:08.6562515' AS DateTime2), CAST(N'2022-09-08T10:01:08.6562521' AS DateTime2), 0, 0, 30000, 1)
INSERT [dbo].[Order] ([OrderId], [DayOrder], [DayDelivery], [PaidState], [DeliveryState], [TotalMoney], [CustomerId]) VALUES (38, CAST(N'2022-09-05T10:02:22.5482243' AS DateTime2), CAST(N'2022-09-08T10:02:22.5482553' AS DateTime2), 0, 0, 30000, 1)
INSERT [dbo].[Order] ([OrderId], [DayOrder], [DayDelivery], [PaidState], [DeliveryState], [TotalMoney], [CustomerId]) VALUES (39, CAST(N'2022-09-05T10:02:27.4549087' AS DateTime2), CAST(N'2022-09-08T10:02:27.4549093' AS DateTime2), 0, 0, 30000, 1)
INSERT [dbo].[Order] ([OrderId], [DayOrder], [DayDelivery], [PaidState], [DeliveryState], [TotalMoney], [CustomerId]) VALUES (40, CAST(N'2022-09-05T10:03:06.7544845' AS DateTime2), CAST(N'2022-09-08T10:03:06.7545275' AS DateTime2), 0, 0, 30000, 1)
INSERT [dbo].[Order] ([OrderId], [DayOrder], [DayDelivery], [PaidState], [DeliveryState], [TotalMoney], [CustomerId]) VALUES (41, CAST(N'2022-09-05T10:04:38.4557464' AS DateTime2), CAST(N'2022-09-08T10:04:38.4557811' AS DateTime2), 0, 0, 30000, 1)
INSERT [dbo].[Order] ([OrderId], [DayOrder], [DayDelivery], [PaidState], [DeliveryState], [TotalMoney], [CustomerId]) VALUES (42, CAST(N'2022-10-02T13:36:57.1494656' AS DateTime2), CAST(N'2022-10-05T13:36:57.1494994' AS DateTime2), 0, 0, 430000, 1)
INSERT [dbo].[Order] ([OrderId], [DayOrder], [DayDelivery], [PaidState], [DeliveryState], [TotalMoney], [CustomerId]) VALUES (43, CAST(N'2022-10-02T13:38:07.8084085' AS DateTime2), CAST(N'2022-10-05T13:38:07.8084765' AS DateTime2), 0, 0, 430000, 1)
INSERT [dbo].[Order] ([OrderId], [DayOrder], [DayDelivery], [PaidState], [DeliveryState], [TotalMoney], [CustomerId]) VALUES (44, CAST(N'2022-10-02T13:40:21.8778092' AS DateTime2), CAST(N'2022-10-05T13:40:21.8778094' AS DateTime2), 0, 0, 430000, 1)
INSERT [dbo].[Order] ([OrderId], [DayOrder], [DayDelivery], [PaidState], [DeliveryState], [TotalMoney], [CustomerId]) VALUES (45, CAST(N'2022-10-02T13:42:17.5381813' AS DateTime2), CAST(N'2022-10-05T13:42:17.5382484' AS DateTime2), 0, 0, 430000, 1)
INSERT [dbo].[Order] ([OrderId], [DayOrder], [DayDelivery], [PaidState], [DeliveryState], [TotalMoney], [CustomerId]) VALUES (46, CAST(N'2022-10-02T13:46:22.9785208' AS DateTime2), CAST(N'2022-10-05T13:46:22.9785209' AS DateTime2), 0, 0, 106500, 1)
INSERT [dbo].[Order] ([OrderId], [DayOrder], [DayDelivery], [PaidState], [DeliveryState], [TotalMoney], [CustomerId]) VALUES (47, CAST(N'2022-10-02T13:52:28.5065264' AS DateTime2), CAST(N'2022-10-05T13:52:28.5065916' AS DateTime2), 0, 0, 30000, 1)
INSERT [dbo].[Order] ([OrderId], [DayOrder], [DayDelivery], [PaidState], [DeliveryState], [TotalMoney], [CustomerId]) VALUES (48, CAST(N'2022-10-02T13:56:08.3086574' AS DateTime2), CAST(N'2022-10-05T13:56:08.3087664' AS DateTime2), 0, 0, 30000, 1)
INSERT [dbo].[Order] ([OrderId], [DayOrder], [DayDelivery], [PaidState], [DeliveryState], [TotalMoney], [CustomerId]) VALUES (49, CAST(N'2022-10-02T13:56:46.6630128' AS DateTime2), CAST(N'2022-10-05T13:56:46.6630139' AS DateTime2), 0, 0, 30000, 1)
INSERT [dbo].[Order] ([OrderId], [DayOrder], [DayDelivery], [PaidState], [DeliveryState], [TotalMoney], [CustomerId]) VALUES (50, CAST(N'2022-10-02T14:02:15.5145548' AS DateTime2), CAST(N'2022-10-05T14:02:15.5146162' AS DateTime2), 0, 0, 30000, 1)
INSERT [dbo].[Order] ([OrderId], [DayOrder], [DayDelivery], [PaidState], [DeliveryState], [TotalMoney], [CustomerId]) VALUES (51, CAST(N'2022-10-02T14:15:26.6829970' AS DateTime2), CAST(N'2022-10-05T14:15:26.6830250' AS DateTime2), 0, 0, 45300, 1)
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [UnitPrice], [Quantity]) VALUES (1, 6, 50000.0000, 2)
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [UnitPrice], [Quantity]) VALUES (17, 6, 50000.0000, 1)
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [UnitPrice], [Quantity]) VALUES (1, 7, 50000.0000, 1)
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [UnitPrice], [Quantity]) VALUES (9, 7, 20000.0000, 1)
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [UnitPrice], [Quantity]) VALUES (17, 7, 20000.0000, 1)
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [UnitPrice], [Quantity]) VALUES (2, 16, 10000.0000, 1)
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [UnitPrice], [Quantity]) VALUES (13, 16, 50000.0000, 1)
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [UnitPrice], [Quantity]) VALUES (51, 16, 18000.0000, 1)
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [UnitPrice], [Quantity]) VALUES (3, 17, 20000.0000, 5)
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [UnitPrice], [Quantity]) VALUES (15, 17, 150000.0000, 1)
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [UnitPrice], [Quantity]) VALUES (2, 18, 70000.0000, 1)
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [UnitPrice], [Quantity]) VALUES (4, 18, 10000.0000, 3)
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [UnitPrice], [Quantity]) VALUES (15, 18, 100000.0000, 1)
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [UnitPrice], [Quantity]) VALUES (16, 18, 100000.0000, 1)
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [UnitPrice], [Quantity]) VALUES (20, 18, 100000.0000, 1)
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [UnitPrice], [Quantity]) VALUES (5, 19, 10000.0000, 1)
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [UnitPrice], [Quantity]) VALUES (10, 19, 100000.0000, 1)
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [UnitPrice], [Quantity]) VALUES (11, 19, 100000.0000, 1)
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [UnitPrice], [Quantity]) VALUES (18, 19, 150000.0000, 1)
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [UnitPrice], [Quantity]) VALUES (6, 20, 30000.0000, 5)
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [UnitPrice], [Quantity]) VALUES (7, 20, 100000.0000, 1)
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [UnitPrice], [Quantity]) VALUES (8, 20, 100000.0000, 1)
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [UnitPrice], [Quantity]) VALUES (10, 20, 100000.0000, 2)
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [UnitPrice], [Quantity]) VALUES (11, 20, 100000.0000, 1)
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [UnitPrice], [Quantity]) VALUES (12, 20, 100000.0000, 1)
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [UnitPrice], [Quantity]) VALUES (7, 22, 100000.0000, 2)
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [UnitPrice], [Quantity]) VALUES (8, 22, 100000.0000, 2)
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [UnitPrice], [Quantity]) VALUES (46, 36, 90000.0000, 1)
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [UnitPrice], [Quantity]) VALUES (42, 37, 500000.0000, 1)
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [UnitPrice], [Quantity]) VALUES (43, 37, 500000.0000, 1)
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [UnitPrice], [Quantity]) VALUES (44, 37, 500000.0000, 1)
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [UnitPrice], [Quantity]) VALUES (45, 37, 500000.0000, 1)
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductId], [ProductName], [ProductPrice], [ProductDescription], [ProductAmount], [ProductDiscount], [ProductImage], [ProductDateCreated], [CategoryId], [ProductRating]) VALUES (3, N'Chả cá Quy Nhơn', 120000, N'Mặc dù chả cá có thể là đặc sản và có mặt ở nhiều nơi nhưng không phải hương vị chả cá nào cũng như nhau. Sở dĩ chả cá Quy Nhơn là một trong các đặc sản Bình Định nổi tiếng vì vị ngon và lạ đặc trưng. Với nguyên liệu được tuyển chọn từ những con cá biển tươi ngon nhất và công thức chế biến độc quyền của người dân đã tạo nên sự khác biệt cho chả cá Quy Nhơn.

Chả cá Quy Nhơn phổ biến có 2 loại là chả hấp và chả chiên. Ngoài việc thưởng thức thực tiếp miếng chả dai, giòn, thơm ngon đặc biệt, các bạn có thể dùng chả cá này để làm “topping” cho các món ăn khác như cơm, bún, phở. Đây cũng là một lựa chọn thích hợp để bạn mua về làm quà cho người thân và bạn bè nữa đó.', 100, 10, N'chaca.png', CAST(N'2022-08-19T00:00:00.0000000' AS DateTime2), 1, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [ProductPrice], [ProductDescription], [ProductAmount], [ProductDiscount], [ProductImage], [ProductDateCreated], [CategoryId], [ProductRating]) VALUES (6, N'Tôm khô', 84000, N'
Tôm khô còn gọi là tôm nõn khô là một trong các loại thực phẩm giàu dinh dưỡng rất tốt cho sức khỏe. Chúng được làm từ tôm tươi tự nhiên và phơi khô dưới ánh nắng mặt trời hoặc sấy khô thủ công. 1kg tôm tươi làm được khoảng 2 lạng tôm khô, thành phẩm tôm có kích thước nhỏ hơn, có vị ngọt thanh đậm đà rất thơm.

Giá trị dinh dưỡng của tôm vẫn giữ gần như nguyên vẹn, trong 100g tôm khô có: 347 kcal, 75,6g đạm, 235mg canxi, 4,6mg sắt, vitamin B1, B2, PP và 3,8g chất béo chưa bảo hòa.', 20, 20, N'tom-kho-gia-bao-nhieu-1kg.jpg', CAST(N'2022-08-19T00:00:00.0000000' AS DateTime2), 1, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [ProductPrice], [ProductDescription], [ProductAmount], [ProductDiscount], [ProductImage], [ProductDateCreated], [CategoryId], [ProductRating]) VALUES (7, N'Mắm Nhum Mỹ An Bình Định', 20000, N'Nhum có rất nhiều loại khác nhau, nhưng mắm nhum tại Bình Định đặc biệt được làm từ con nhum ta, tạo hương vị ngon đến nỗi “ăn với món gì cũng ngon”. Đồng thời mắm Nhum tại Mỹ An cũng từng là đặc sản Bình Định được tiến vua, và hiện nay là một món ăn mà du khách không thể bỏ lỡ khi đến Bình Định du lịch.

Nhum vốn là động vật với bê ngoài gai góc có thể làm đau người dân nếu đạp phải, và người dân nơi đây đã biến chúng thành một món ngon tuyệt vời. Mắm nhum còn có thể là món quà hảo hạng giúp bạn dùng làm quà tặng sau khi đến Bình Định du lịch, nếu được thì bạn nên đến Mỹ An để mua mắm nhum nhé.', 100, 5, N'mamnhum.png', CAST(N'2022-08-19T00:00:00.0000000' AS DateTime2), 7, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [ProductPrice], [ProductDescription], [ProductAmount], [ProductDiscount], [ProductImage], [ProductDateCreated], [CategoryId], [ProductRating]) VALUES (16, N'Cá cơm khô', 18000, N'cá cơm giàu vitamin A, nhiều axit béo, vitamin E, canxi, Vitamin A, giúp mắt sáng, ngăn ngừa các bệnh về mắt, duy trì làn da khỏe mạnh. Ăn cá cơm giúp giảm lượng cholesterol trong máu, ngăn ngừa các bệnh về tim mạch.

Cá cơm cung cấp một lượng lớn protein và đạm, nên chúng được sử dụng để làm nước mắm nhĩ', 55, 15, N'cach-lam-ca-kho-tam-gia-vi.jpg', CAST(N'2022-08-19T00:00:00.0000000' AS DateTime2), 1, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [ProductPrice], [ProductDescription], [ProductAmount], [ProductDiscount], [ProductImage], [ProductDateCreated], [CategoryId], [ProductRating]) VALUES (17, N'Nem chợ huyện', 150000, N'Nem chua là một trong các đặc sản Bình Định được chế biến cầu kỳ và công phu. Với công thức hương vị đặc biệt để ướp những miếng thịt heo tươi ngon nhất và gói bên trong những lớp lá khế non và lớp lá chuối cầu kì, hương vị thơm ngon nổi tiếng của nem chợ huyện cũng từ đó mà vang xa.

Đến Bình Định ngồi cắn một miếng nem và nhâm nhi một ít rượu Bàu Đá cũng đủ để bạn nhớ về hương vị ấy mỗi khi nhắc đến chuyến du lịch này đó. Ngoài ra, nem cũng là lựa chọn thích hợp để làm quà tặng, với hương vị tuyệt vời ấy ai lại lỡ không thích món quà mà bạn tặng.', 100, 20, N'nem.png', CAST(N'2022-08-19T00:00:00.0000000' AS DateTime2), 6, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [ProductPrice], [ProductDescription], [ProductAmount], [ProductDiscount], [ProductImage], [ProductDateCreated], [CategoryId], [ProductRating]) VALUES (18, N'Bánh ít lá gai', 100000, N'“Muốn ăn bánh ít lá gai
Lấy chồng Bình Định sợ dài đường đi”

Bánh ít lá gai là một trong các đặc sản Bình Định nổi tiếng. Để làm nên những chiếc bánh ít thơm ngon nức tiếng, người làm bánh phải lựa chọn và chuẩn bị những chiếc lá gai rất cầu kỳ vì đây là yếu tố quan trong quyết định đến hương vị của bánh. Kế đến là nếp và nhân cũng được lựa chọn và chế biến từ những nguyên liệu ngon nhất.

Sau một quá trình xay bột, làm nhân, gói và hấp bánh, những chiếc bánh ít lá gai thơm ngon, dẻo dai với vị ngọt của nhân đậu xanh hoặc nhân dừa đã được ra lò. Với đặc sản này bạn nên thử ít nhất một lần, và đây cũng được xem là một món quà mà chắc chắn người thân của bạn sẽ thích.', 100, 10, N'banhit.png', CAST(N'2022-08-19T00:00:00.0000000' AS DateTime2), 6, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [ProductPrice], [ProductDescription], [ProductAmount], [ProductDiscount], [ProductImage], [ProductDateCreated], [CategoryId], [ProductRating]) VALUES (19, N'Mực rim Quy Nhơn', 150000, N'Mực rim là món ăn phổ biến khiến du thích yêu thích có mặt ở hầu hết những vùng biển lớn. Tuy nhiên mực rim hay còn gọi là mực ngào Bình Định có một hương vị thơm ngon rất riêng từ vùng biển duyên hải miền Trung. Mực rim Quy Nhơn được người dân làm từ những con mực tươi nhất và hương vị không nơi nào giống được.

Với hương thơm ngon đặc biệt cùng vị cay cay kích thích vị giác, mực rim trở thành món ăn vặt siêu ngon và được mọi người vô cùng yêu thích. Đồng thời, với những hũ mực rim được làm sẵn giúp bạn có thể dễ dàng lựa chọn đặc sản Bình Định này để làm quà tặng.', 100, 5, N'mucrim.png', CAST(N'2022-08-19T00:00:00.0000000' AS DateTime2), 1, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [ProductPrice], [ProductDescription], [ProductAmount], [ProductDiscount], [ProductImage], [ProductDateCreated], [CategoryId], [ProductRating]) VALUES (20, N'Chả Tré rơm', 35000, N'Với tên gọi độc và lạ của món Chả Tré, món đặc sản Bình Định này đã gợi nên sự tò mò với nhiều du khách muốn tìm hiểu và được thử món ăn độc đáo này. Mặc dù đã có mặt phổ biến khắp các tỉnh thành Trung Trung bộ, nhưng hương vị thơm ngon nhất vẫn là chả Tré Bình Định với cách làm và công thức chỉ vùng đất Bình Định mới làm nên được.

Thành phần nguyên liệu làm chả Tré cũng tương tự với các loại nem, bì của miền bắc. Nhưng Tré Bình Định được người dân nơi đây khéo léo thay thế bằng nhiều loại nguyên liệu khác như tai heo, lỗ mũi heo, da heo, thịt ba chỉ,...Tré cũng thích hợp để trở thành món quà mang về khi bạn đến thăm Bình Định.', 100, 20, N'chatre.png', CAST(N'2022-08-19T00:00:00.0000000' AS DateTime2), 7, 3)
INSERT [dbo].[Product] ([ProductId], [ProductName], [ProductPrice], [ProductDescription], [ProductAmount], [ProductDiscount], [ProductImage], [ProductDateCreated], [CategoryId], [ProductRating]) VALUES (21, N'Bánh thuẫn', 15000, N'Nếu như Hà Nội có bánh cốm, Hải Dương có bánh đậu xanh, Vũng Tàu có bánh bông lan trứng muối,...và những loại bánh làm quà đặc trưng của nhiều tỉnh khác thì Quy Nhơn lại bánh thuẫn nổi tiếng để làm quà tặng cho người thân và bạn bè. Đây cũng là loại bánh phổ biến vào ngày Tết của người dân miền Trung.

Bánh thuẫn có vị thơm ngon từ nguyên liệu như trứng gà, bột năng, bột bình tinh, đường, đâu ăn, vani và đặc biệt là khuôn đúc bánh. Quá trình đúc bánh bằng than đã góp phần tạo nên được mùi thơm đặc trưng của đặc sản Bình Định này.', 100, 0, N'banhthuan.png', CAST(N'2022-08-19T00:00:00.0000000' AS DateTime2), 6, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [ProductPrice], [ProductDescription], [ProductAmount], [ProductDiscount], [ProductImage], [ProductDateCreated], [CategoryId], [ProductRating]) VALUES (22, N'Rượu Bầu đá', 40000, N'Sở dĩ rượu Bàu đá được biết đến là một trong những đặc sản Bình Định nổi tiếng vì đây là loại rượu không nấu từ gạo thông thường như những loại rượu khác. Rượu Bàu đá Bình Định được nấu từ gạo lứt và chỉ khi sử dụng một nguồn nước trong một làng của tỉnh Bình Định mới đạt được hương vị ngon nhất.

Từ xưa, rượu Bàu đá đã được tiến cung cho vua nên được xếp vào loại đặc sản thượng hạng của Bình Định. Rượu nổi tiếng dễ say vì có độ cồn rất cao, lên đến 50. Nhưng điều khiến người ta yêu thích hương vị của rượu là vị thanh mát mang lại cảm giác sảng khoái vô cùng. Đây cũng là một món quà thích hợp thể hiện sự kính trọng bạn có thể chọn.', 100, 0, N'ruoubauda.png', CAST(N'2022-08-19T00:00:00.0000000' AS DateTime2), 7, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [ProductPrice], [ProductDescription], [ProductAmount], [ProductDiscount], [ProductImage], [ProductDateCreated], [CategoryId], [ProductRating]) VALUES (23, N'Mực ngào Bình Định', 250000, N'Một trong những món ăn phải kể đến đầu tiên trong dah sách những món đặc sản Bình Định đó chính là mực ngào. Mực ngào có một hương vị thơm ngon rất riêng thu hút khách du lịch. Để chế biến được món mực ngào người đầu bếp đã phải rất công phu, tài tình tỉ mỉ chăm chút cho món ăn. Mực sau khi đươc thu mua từ những cảng hải sản tươi ngon được đem về sơ chế và chế biến luôn để giữ được độ tươi ngon nguyên vẹn  của mực.

Mực được  ướp cùng tiêu, tỏi, ớt, mắm và một số loại gia vị khác để tạo độ thơm ngon đặc trưng của mực. Món ăn này có vị cay đặc trưng, thơm thơm của các loại gia vị sẽ làm bạn thích thú và muốn ăn ngay từ cái nhìn đầu tiên. Gía của một cân mực ngào giao động từ  200.000 – 400.000 đồng.', 100, 0, N'muc-ngao-ot-dac-san-binh-dinh-lam-qua.jpg', CAST(N'2022-09-03T00:00:00.0000000' AS DateTime2), 1, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [ProductPrice], [ProductDescription], [ProductAmount], [ProductDiscount], [ProductImage], [ProductDateCreated], [CategoryId], [ProductRating]) VALUES (27, N'Khô cá chỉ vàng', 135000, N'Cá chỉ vàng là loài cá nước mặn (còn gọi là cá ngân chỉ) thức ăn của chúng là những sinh vật nổi. Thân cá dẹp hình thoi, hai bên có một sọc vàng chạy thẳng từ sau mắt đến gần vây đuôi, phần lưng màu xanh xám, bụng trắng bạc, trên mang cá có chấm đen, vây đuôi vàng, đầu cá hơi nhọn, miệng chếch, hàm dưới nhô ra.

Cá chỉ vàng thịt trắng có vị ngọt thơm, giàu vitamin B, Omega 3 giúp ngăn ngừa bệnh tim mạch, tốt cho não bộ, cải thiện giấc ngủ...', 100, 0, N'cach-lua-ca-chi-vang-kho-ngon.jpg', CAST(N'2022-09-03T00:00:00.0000000' AS DateTime2), 1, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [ProductPrice], [ProductDescription], [ProductAmount], [ProductDiscount], [ProductImage], [ProductDateCreated], [CategoryId], [ProductRating]) VALUES (28, N'Bánh tráng nước dừa', 120000, N'Khi đến du lịch Bình Định không thể không nhắc tới  món bánh tráng nước dừa. Đây là một món đặc sản nơi xứ dừa. Công đoạn chế biến bánh không quá cầu kì nhưng đòi hỏi sự tỉ mỉ, có kinh nghiệm của người tráng bánh. Nguyên liệu của bánh chủ yếu là Củ Mì ( củ sắn) được sắt nhỏ, xay lấy nước. Cơm dừa được nạo thành sợi nhỏ,  nước dừa và vừng đen. Tất cả đều được đổ chung vào một nồi lớn, trộn đều cho các gia vị hòa quyện cùng với nhau và được đun nóng. Bên cạnh đó có một chảo đang được đun nóng. Khi chảo nóng lên người tráng bánh sẽ dùng một cái gáo làm bằng sọ dừa có cán dài múc từng gáo nước bánh lên chảo và tráng đều. Tráng bánh phải đều tay để cơm dừa và vừng đen được dàn đều mặt bánh. Bánh phải tròn mỏng và không bị chỗ dày, chỗ mỏng thì mới là bánh đạt chuẩn. cứ tráng được mười chiếc  bánh thì đem ra phơi. khi ăn bạn cần nướng lên để bánh có độ phồng và dậy hết mùi thơm của vừng, của nước cốt dừa và cơm dừa. Có thể ăn bánh thay cơm ăn chỉ thấy no mà không thấy chán.', 50, 0, N'Banh-trang-nuoc-dua-am-thuc-binh-dinh.jpg', CAST(N'2022-09-03T00:00:00.0000000' AS DateTime2), 6, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [ProductPrice], [ProductDescription], [ProductAmount], [ProductDiscount], [ProductImage], [ProductDateCreated], [CategoryId], [ProductRating]) VALUES (29, N'Nước mắm nhĩ Bình Định', 95000, N'Nước mắm nhĩ hay nhỉ còn gọi là nước mắm kéo lù hoặc mắm cốt, là loại nước mắm được hứng từ các giọt nước mắm đầu tiên được “nhỉ” ra. Hay nói cách khác là rò rỉ ra từng giọt, từng giọt từ lỗ van đang đóng kín ở đáy của thùng hay lu vại đang muối cá đã đến thời gian chín có thể lấy nước mắm thành phẩm.', 50, 0, N'nuoc-mam-nhi-nguyen-chat-tam-quan-binh-dinh.jpg', CAST(N'2022-09-03T00:00:00.0000000' AS DateTime2), 1, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [ProductPrice], [ProductDescription], [ProductAmount], [ProductDiscount], [ProductImage], [ProductDateCreated], [CategoryId], [ProductRating]) VALUES (30, N'Ruốt khô', 200000, N'Con ruốc còn gọi là tép biển, tép moi, ở Việt Nam được coi là đặc sản. Chúng là động vật giáp xác 10 chân sống ở vùng nước mặn ven biển hay nước lợ. Ruốc dạng như tôm nhỏ, chỉ lớn khoảng 10–40 mm Do kích thước của con ruốc biển nhỏ, nên thường được dùng để làm nước mắm ruốc (là một loại mắm đặc sản của miền biển) hoặc phơi khô ruốc để chế biến thành các món ăn dân dã đậm đà hương vị biển.

', 50, 0, N'các-món-từ-ruốc-khô.jpg', CAST(N'2022-09-03T00:00:00.0000000' AS DateTime2), 1, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [ProductPrice], [ProductDescription], [ProductAmount], [ProductDiscount], [ProductImage], [ProductDateCreated], [CategoryId], [ProductRating]) VALUES (31, N'Cá Lao Khô Tẩm Gia Vị', 125000, N'Hải sản Quy Nhơn nổi tiếng khắp cả nước với nhiều loại hải sản phong phú đa dạng, trong đó Cá lao là một loại hải sản khô đặc biệt thơm ngon, chúng là một loại cá biển, sau khi được ngư dân đánh bắt được xẻ thịt, phơi khô tạo nên một loại thực phẩm thơm ngon đúng chất tinh túy từ biển.', 50, 0, N'cá-lao-khô-quy-nhơn.jpg', CAST(N'2022-09-03T00:00:00.0000000' AS DateTime2), 1, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [ProductPrice], [ProductDescription], [ProductAmount], [ProductDiscount], [ProductImage], [ProductDateCreated], [CategoryId], [ProductRating]) VALUES (32, N'Bánh hồng Tam Quan', 200000, N'Bánh hồng Tam Quan là một trong những món đặc sản của Bình Định, được xem như biểu trưng cho tin vui, thường xuất hiện trong các dịp cưới hỏi của người dân nơi đây.

Điều đặc biệt bánh hồng Tam Quan là bánh được làm từ gạo nếp Ngự nổi tiếng dẻo thơm. Do hoàn toàn không có chất bảo quản nên bánh chỉ để được 5 ngày thôi bạn nhé.', 50, 0, N'banhhong.jpg', CAST(N'2022-09-03T00:00:00.0000000' AS DateTime2), 6, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [ProductPrice], [ProductDescription], [ProductAmount], [ProductDiscount], [ProductImage], [ProductDateCreated], [CategoryId], [ProductRating]) VALUES (33, N'Bánh tráng chả cá', 400000, N'Bánh tráng chả cá là một trong những đặc sản nổi tiếng gần xa của Bình Định. Bánh tráng chả cá được làm từ nguyên liệu chính là cá cùng một ít gia vị và bột năng. Để món ăn đúng vị hơn bạn nên ăn kèm với rau răm nhé.', 50, 0, N'banhtrangchaca.jpg', CAST(N'2022-09-03T00:00:00.0000000' AS DateTime2), 6, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [ProductPrice], [ProductDescription], [ProductAmount], [ProductDiscount], [ProductImage], [ProductDateCreated], [CategoryId], [ProductRating]) VALUES (34, N'Mực ngào vị tỏi
', 200000, N'Nếu đã đến với đất Bình Định thì bạn nhất định phải thử qua món mực ngào vị tỏi nhé. Món ăn là sự hòa quyện giữa vị mực vừa tươi vừa giòn cùng vị cay đặc trưng của ớt và tỏi. Bạn nhớ bảo quản món này ở nhiệt độ thoáng mát nha.', 100, 0, N'muc-ngao-ot-dac-san-binh-dinh-lam-qua.jpg', CAST(N'2022-09-03T00:00:00.0000000' AS DateTime2), 1, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [ProductPrice], [ProductDescription], [ProductAmount], [ProductDiscount], [ProductImage], [ProductDateCreated], [CategoryId], [ProductRating]) VALUES (35, N'Chả ram tôm đất', 890000, N'
Chả ram tôm đất là một trong những món ngon đặc sản nổi tiếng của miền đất võ Bình Định, món ăn này phù hợp với mọi lứa tuổi, từ già đến trẻ đều yêu thích và thường xuyên xuất hiện trong các bữa cơm gia đình.

Miếng chả ram tôm đất Bình Định giòn tan của lớp bánh tráng chiên bên ngoài, bên trong có thịt tôm ngọt tự nhiên, một chút ngầy ngậy của thịt mỡ, tất cả tạo nên hương vị đặc biệt hấp dẫn, gây nghiện cho thực khách khi dùng thử món ăn độc đáo này.', 45, 0, N'chả-ram-tôm-đất-quy-nhơn-ngon-loại-1.jpg', CAST(N'2022-09-06T00:00:00.0000000' AS DateTime2), 1, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [ProductPrice], [ProductDescription], [ProductAmount], [ProductDiscount], [ProductImage], [ProductDateCreated], [CategoryId], [ProductRating]) VALUES (36, N'Ghẹ sữa rim tỏi ớt, rang me, chiên giòn', 90000, N'Ghẹ sữa là ghẹ còn non có kích thước nhỏ, cỡ ngón chân cái người lớn, nhiều nhất vào tháng 5 đến tháng 11, thời điểm ghẹ sinh sản nhiều.

Ghẹ sữa có hàm lượng dinh dưỡng cao, nhiều canxi, đạm, sắt, các vitamin A, B1, B2, C và đặc biệt là magnesium, calcium và axit béo omega 3, có lợi cho sức khỏe và rất tốt cho người có vấn đề tim mạch và hỗ trợ tăng trưởng chiều cao cho trẻ.', 44, 15, N'ghe-sua-chien-gion.jpg', CAST(N'2022-09-06T00:00:00.0000000' AS DateTime2), 1, 4)
INSERT [dbo].[Product] ([ProductId], [ProductName], [ProductPrice], [ProductDescription], [ProductAmount], [ProductDiscount], [ProductImage], [ProductDateCreated], [CategoryId], [ProductRating]) VALUES (37, N'Mực một nắng', 500000, N'Mực một nắng là loại hải sản đặc biệt, để làm mực 1 nắng được ngon, sau khi xẻ phải rửa mực tươi bằng nước biển, rồi phơi dưới trời nắng gắt. Chỉ được phơi qua một nắng để mực vẫn giữ được độ tươi ngon, bên ngoài ráo nước, bên trong dẻo và giòn.

Những vùng biển có nước biển càng mặn thì mực 1 nắng sẽ càng ngon, đặc biệt là các khu vực miền Trung. Mực một nắng có nhiều loại, nhưng mực ngon nhất vẫn là làm từ những con mực ống và mực lá.

Đây là một trong các đặc sản nổi tiếng của Bình Định được du khách tìm mua làm quà.', 50, 20, N'muc-mot-nang-gia-bao-nhieu-1kg.jpg', CAST(N'2022-09-06T00:00:00.0000000' AS DateTime2), 1, 2)
INSERT [dbo].[Product] ([ProductId], [ProductName], [ProductPrice], [ProductDescription], [ProductAmount], [ProductDiscount], [ProductImage], [ProductDateCreated], [CategoryId], [ProductRating]) VALUES (38, N'Cá đù một nắng', 16000, N'Cá đù hay Cá lù đù là một họ cá thuộc bộ Cá vược (Perciformes) có kích thước lớn, chúng sống ở vùng biển nhiệt đới, cận nhiệt đới. Tại vùng biển Việt Nam, có khoảng 270 loài trong 70 chi, đáng kể nhất là cá lù đù bạc chiếm số lượng lớn trong 20 loài như cá lù đù măng đen, cá lù đù lỗ tai đen, cá lù đù kẽm, cá lù đù sóc, cá lù đù đỏ dạ…

Chúng sống thành từng đàn lớn ở gần bờ, thường núp trong những rạn, hốc đá. Thức ăn của chúng là các loại động vật thủy sinh, côn trùng hay cá nhỏ, giáp xác.

 Vì muốn dự trữ được lâu nên sau khi được đánh bắt, ngư dân chọn cá tươi làm sạch, xẻ lóc bỏ xương, bỏ đầu để ráo. Sau đó, đem phơi khô dưới 1 nắng gắt để cá se lại để thịt dẻo dẻo. Hoặc có thể phơi cho thật khô để dự trữ ăn dần.

Cá đù 1 nắng phần thân sau của cá có nhiều mỡ, rất béo. Loại cá này có vị ngọt dịu deo dẻo và đặc biệt thịt mềm, hậu bùi, có thể chế biến thành nhiều món ngon hấp dẫn.

Hiện nay, đây là đặc sản được rất nhiều người săn lùng, kể cả người nước ngoài cũng rất thích thú với vị ngon ngọt của nó “đặc biệt là giá cả phải chăng”.', 12, 0, N'cá-đù-một-nắng.jpg', CAST(N'2022-09-06T00:00:00.0000000' AS DateTime2), 1, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [ProductPrice], [ProductDescription], [ProductAmount], [ProductDiscount], [ProductImage], [ProductDateCreated], [CategoryId], [ProductRating]) VALUES (39, N'Chả Bò (Giò Bò) Bình Định Chính Gốc – Cây 500G', 180000, N'Chả Bò (Giò Bò) Bình Định Chính Gốc – Cây 500G', 15, 0, N'cha-bo-binh-dinh-nha-lam.jpg', CAST(N'2022-09-06T00:00:00.0000000' AS DateTime2), 7, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [ProductPrice], [ProductDescription], [ProductAmount], [ProductDiscount], [ProductImage], [ProductDateCreated], [CategoryId], [ProductRating]) VALUES (40, N'Bánh Tráng Nhúng Giòn Phù Mỹ', 45000, N'Đến với Bình Định, du khách sẽ được thưởng thức những món được làm từ các loại bánh tráng. Nào là bánh tráng mè nướng, bánh tráng nước cốt dừa Tam Quan hay bánh tráng bột mì nhứt nướng, bánh tráng gạo nhúng, … loại bánh nào cũng ngon nhứt nách.

Hôm nay, Đặc Sản Bình Định Online xin được giới thiệu đến quý khách một loại bánh tráng độc đáo hơn cả đó là bánh tráng nhúng giòn Phù Mỹ. Hãy cùng khám phá bạn nhé. Nếu có cơ hội đến Bình Định hãy thử một lần thưởng thức loại bánh tráng đặc sản Phù Mỹ để tự cảm nhận hương vị thơm ngon đặc trưng của nó nhé.', 20, 0, N'banh-trang-nhung-binh-dinh.jpg', CAST(N'2022-09-06T00:00:00.0000000' AS DateTime2), 6, 0)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductRating] ON 

INSERT [dbo].[ProductRating] ([ProductRatingId], [Stars], [RatingContent], [PRDateCreated], [ProductId], [CustomerId]) VALUES (4, 5, N'That''s so amazing!', CAST(N'2022-08-24T00:00:00.0000000' AS DateTime2), 6, 1)
INSERT [dbo].[ProductRating] ([ProductRatingId], [Stars], [RatingContent], [PRDateCreated], [ProductId], [CustomerId]) VALUES (5, 4, N'Hợp túi tiền', CAST(N'2022-08-24T00:00:00.0000000' AS DateTime2), 7, 2)
INSERT [dbo].[ProductRating] ([ProductRatingId], [Stars], [RatingContent], [PRDateCreated], [ProductId], [CustomerId]) VALUES (8, 2, N'Tệ quá đắt không ngon', CAST(N'2022-08-24T00:00:00.0000000' AS DateTime2), 16, 2)
INSERT [dbo].[ProductRating] ([ProductRatingId], [Stars], [RatingContent], [PRDateCreated], [ProductId], [CustomerId]) VALUES (9, 5, N'That''s so amazing!', CAST(N'2022-08-24T00:00:00.0000000' AS DateTime2), 6, 2)
INSERT [dbo].[ProductRating] ([ProductRatingId], [Stars], [RatingContent], [PRDateCreated], [ProductId], [CustomerId]) VALUES (12, 0, N'thai is my name', CAST(N'2022-08-26T15:24:26.9507962' AS DateTime2), 17, 1)
INSERT [dbo].[ProductRating] ([ProductRatingId], [Stars], [RatingContent], [PRDateCreated], [ProductId], [CustomerId]) VALUES (20, 5, N'aa', CAST(N'2022-08-27T12:58:37.2251950' AS DateTime2), 22, 1)
INSERT [dbo].[ProductRating] ([ProductRatingId], [Stars], [RatingContent], [PRDateCreated], [ProductId], [CustomerId]) VALUES (21, 5, N'bình', CAST(N'2022-08-27T13:03:39.2023918' AS DateTime2), 22, 3)
INSERT [dbo].[ProductRating] ([ProductRatingId], [Stars], [RatingContent], [PRDateCreated], [ProductId], [CustomerId]) VALUES (22, 3, N'That''s pretty goood!!
', CAST(N'2022-08-27T13:11:31.8401963' AS DateTime2), 21, 2)
INSERT [dbo].[ProductRating] ([ProductRatingId], [Stars], [RatingContent], [PRDateCreated], [ProductId], [CustomerId]) VALUES (23, 1, N'bo may bom', CAST(N'2022-09-03T23:15:15.4561211' AS DateTime2), 6, 3)
INSERT [dbo].[ProductRating] ([ProductRatingId], [Stars], [RatingContent], [PRDateCreated], [ProductId], [CustomerId]) VALUES (24, 2, N'hi everybody i give this product 2 stars', CAST(N'2022-09-03T23:21:26.4713415' AS DateTime2), 6, 16)
INSERT [dbo].[ProductRating] ([ProductRatingId], [Stars], [RatingContent], [PRDateCreated], [ProductId], [CustomerId]) VALUES (25, 2, N'2', CAST(N'2022-09-03T23:22:10.4407502' AS DateTime2), 3, 18)
INSERT [dbo].[ProductRating] ([ProductRatingId], [Stars], [RatingContent], [PRDateCreated], [ProductId], [CustomerId]) VALUES (26, 2, N'2asdfas', CAST(N'2022-09-03T23:22:22.1397991' AS DateTime2), 3, 19)
INSERT [dbo].[ProductRating] ([ProductRatingId], [Stars], [RatingContent], [PRDateCreated], [ProductId], [CustomerId]) VALUES (27, 2, N'1', CAST(N'2022-09-03T23:23:01.2695930' AS DateTime2), 3, 2)
INSERT [dbo].[ProductRating] ([ProductRatingId], [Stars], [RatingContent], [PRDateCreated], [ProductId], [CustomerId]) VALUES (28, 4, N'sdf', CAST(N'2022-09-03T23:27:29.5572530' AS DateTime2), 18, 19)
INSERT [dbo].[ProductRating] ([ProductRatingId], [Stars], [RatingContent], [PRDateCreated], [ProductId], [CustomerId]) VALUES (29, 4, N'ngon vl', CAST(N'2022-10-02T10:13:43.9989671' AS DateTime2), 20, 18)
INSERT [dbo].[ProductRating] ([ProductRatingId], [Stars], [RatingContent], [PRDateCreated], [ProductId], [CustomerId]) VALUES (30, 5, N'chắc là giòn lắm', CAST(N'2022-10-02T10:16:04.9089544' AS DateTime2), 20, 16)
INSERT [dbo].[ProductRating] ([ProductRatingId], [Stars], [RatingContent], [PRDateCreated], [ProductId], [CustomerId]) VALUES (31, 3, N'final', CAST(N'2022-10-02T10:17:57.0010207' AS DateTime2), 20, 2)
INSERT [dbo].[ProductRating] ([ProductRatingId], [Stars], [RatingContent], [PRDateCreated], [ProductId], [CustomerId]) VALUES (32, 3, N'final', CAST(N'2022-10-02T10:17:57.0477836' AS DateTime2), 20, 19)
INSERT [dbo].[ProductRating] ([ProductRatingId], [Stars], [RatingContent], [PRDateCreated], [ProductId], [CustomerId]) VALUES (33, 5, N'error', CAST(N'2022-10-02T10:19:14.8400316' AS DateTime2), 20, 16)
INSERT [dbo].[ProductRating] ([ProductRatingId], [Stars], [RatingContent], [PRDateCreated], [ProductId], [CustomerId]) VALUES (34, 5, N'error', CAST(N'2022-10-02T10:19:14.8007019' AS DateTime2), 20, 1)
INSERT [dbo].[ProductRating] ([ProductRatingId], [Stars], [RatingContent], [PRDateCreated], [ProductId], [CustomerId]) VALUES (35, 4, N'alo', CAST(N'2022-10-02T10:21:23.4505966' AS DateTime2), 36, 1)
INSERT [dbo].[ProductRating] ([ProductRatingId], [Stars], [RatingContent], [PRDateCreated], [ProductId], [CustomerId]) VALUES (36, 5, N'mực siêu ngon!!!', CAST(N'2022-10-02T13:39:42.9460227' AS DateTime2), 37, 1)
INSERT [dbo].[ProductRating] ([ProductRatingId], [Stars], [RatingContent], [PRDateCreated], [ProductId], [CustomerId]) VALUES (37, 1, N'thích cho 1 sao', CAST(N'2022-10-02T13:40:06.5046320' AS DateTime2), 37, 1)
SET IDENTITY_INSERT [dbo].[ProductRating] OFF
GO
SET IDENTITY_INSERT [dbo].[Token] ON 

INSERT [dbo].[Token] ([TokenID], [CustomerUserName], [TokenValue], [Expiry]) VALUES (1, N'nhondeptrai', N'KL9dncY9gqFneGMIFGhCDPRnDua0hRGvyPFIjqNv95ekZokjUmGBLjBSqckWdF9L', CAST(N'2022-08-30T12:14:00.9179008' AS DateTime2))
INSERT [dbo].[Token] ([TokenID], [CustomerUserName], [TokenValue], [Expiry]) VALUES (2, N'nhondeptrai', N'Ch1LrsEvTGEGjcTlaAnFIf7KIRBJ4tlSVaUsYvM9DqQYgRQimWCC1xDpsI2DWsEi', CAST(N'2022-08-30T12:27:26.8080564' AS DateTime2))
INSERT [dbo].[Token] ([TokenID], [CustomerUserName], [TokenValue], [Expiry]) VALUES (3, N'sa', N'1Ah79ioKIn50rlmf4wZ5c6HB9wtdUcCNbYJVI8Ymzj1vlU7tccjiF6oPE3GixrUu', CAST(N'2022-09-03T12:35:31.5288961' AS DateTime2))
INSERT [dbo].[Token] ([TokenID], [CustomerUserName], [TokenValue], [Expiry]) VALUES (4, N'sa', N'5b3cxBGQjM9NjpjHoZex1jAEooBNG5vEbPAGOXBunCS5UpJvsPY0a1swF2cz5bXj', CAST(N'2022-09-03T14:08:12.1463861' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Token] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Admin_AdminUserName]    Script Date: 02-Oct-22 2:16:56 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Admin_AdminUserName] ON [dbo].[Admin]
(
	[AdminUserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Customer_CustomerUserName]    Script Date: 02-Oct-22 2:16:56 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Customer_CustomerUserName] ON [dbo].[Customer]
(
	[CustomerUserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DiscountDetail_ProductId]    Script Date: 02-Oct-22 2:16:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_DiscountDetail_ProductId] ON [dbo].[DiscountDetail]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Favorite_CustomerId]    Script Date: 02-Oct-22 2:16:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_Favorite_CustomerId] ON [dbo].[Favorite]
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Order_CustomerId]    Script Date: 02-Oct-22 2:16:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_Order_CustomerId] ON [dbo].[Order]
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderDetail_OrderId]    Script Date: 02-Oct-22 2:16:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderDetail_OrderId] ON [dbo].[OrderDetail]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Product_CategoryId]    Script Date: 02-Oct-22 2:16:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_Product_CategoryId] ON [dbo].[Product]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductRating_CustomerId]    Script Date: 02-Oct-22 2:16:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductRating_CustomerId] ON [dbo].[ProductRating]
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductRating_ProductId]    Script Date: 02-Oct-22 2:16:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductRating_ProductId] ON [dbo].[ProductRating]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Product] ADD  DEFAULT ((0)) FOR [ProductRating]
GO
ALTER TABLE [dbo].[DiscountDetail]  WITH CHECK ADD  CONSTRAINT [FK_DiscountDetail_Discount_DiscountId] FOREIGN KEY([DiscountId])
REFERENCES [dbo].[Discount] ([DiscountId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DiscountDetail] CHECK CONSTRAINT [FK_DiscountDetail_Discount_DiscountId]
GO
ALTER TABLE [dbo].[DiscountDetail]  WITH CHECK ADD  CONSTRAINT [FK_DiscountDetail_Product_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DiscountDetail] CHECK CONSTRAINT [FK_DiscountDetail_Product_ProductId]
GO
ALTER TABLE [dbo].[Favorite]  WITH CHECK ADD  CONSTRAINT [FK_Favorite_Customer_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Favorite] CHECK CONSTRAINT [FK_Favorite_Customer_CustomerId]
GO
ALTER TABLE [dbo].[Favorite]  WITH CHECK ADD  CONSTRAINT [FK_Favorite_Product_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Favorite] CHECK CONSTRAINT [FK_Favorite_Product_ProductId]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Customer_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Customer_CustomerId]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Order_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([OrderId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order_OrderId]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Product_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Product_ProductId]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Categories_CategoryId]
GO
ALTER TABLE [dbo].[ProductRating]  WITH CHECK ADD  CONSTRAINT [FK_ProductRating_Customer_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductRating] CHECK CONSTRAINT [FK_ProductRating_Customer_CustomerId]
GO
ALTER TABLE [dbo].[ProductRating]  WITH CHECK ADD  CONSTRAINT [FK_ProductRating_Product_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductRating] CHECK CONSTRAINT [FK_ProductRating_Product_ProductId]
GO
USE [master]
GO
ALTER DATABASE [BinhDinhFood] SET  READ_WRITE 
GO
