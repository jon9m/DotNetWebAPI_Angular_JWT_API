https://www.microsoft.com/net/download/windows.

c# for vs code

https://www.microsoft.com/en-us/sql-server/sql-server-downloads.


dotnet new webapi

code .

private const string CONN = @"Server=(localdb)\MSSQLLocalDB;
Database=DB-name;
AttachDbFilename=D:\Samples\PTC\SqlData\somename.mdf;
MultipleActiveResultSets=true";

----------------------------------------------------------------
/****** Object:  Schema [Security]    Script Date: 3/11/2018 1:41:13 PM ******/
CREATE SCHEMA [Security]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 3/11/2018 1:41:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 3/11/2018 1:41:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](80) NULL,
	[IntroductionDate] [datetime] NULL,
	[Price] [money] NULL,
	[Url] [nvarchar](255) NULL,
	[CategoryId] [int] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Security].[User]    Script Date: 3/11/2018 1:41:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Security].[User](
	[UserId] [uniqueidentifier] NOT NULL,
	[UserName] [varchar](255) NOT NULL,
	[Password] [varchar](255) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [Security].[UserClaim]    Script Date: 3/11/2018 1:41:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Security].[UserClaim](
	[ClaimId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[ClaimType] [varchar](100) NOT NULL,
	[ClaimValue] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 
GO
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (1, N'Services')
GO
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (2, N'Training')
GO
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (3, N'Information')
GO
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 
GO
INSERT [dbo].[Product] ([ProductId], [ProductName], [IntroductionDate], [Price], [Url], [CategoryId]) VALUES (1, N'SQL Server Naming Standards', CAST(N'2015-02-01T00:00:00.000' AS DateTime), 1.0000, N'http://www.pdsa.com/downloads', 3)
GO
INSERT [dbo].[Product] ([ProductId], [ProductName], [IntroductionDate], [Price], [Url], [CategoryId]) VALUES (3, N'VB.NET Development Standards', CAST(N'2015-04-01T00:00:00.000' AS DateTime), 22.0000, N'http://www.pdsa.com/downloads', 3)
GO
INSERT [dbo].[Product] ([ProductId], [ProductName], [IntroductionDate], [Price], [Url], [CategoryId]) VALUES (5, N'VS.NET Standards', CAST(N'2015-06-01T00:00:00.000' AS DateTime), 22.0000, N'http://www.pdsa.com/downloads', 3)
GO
INSERT [dbo].[Product] ([ProductId], [ProductName], [IntroductionDate], [Price], [Url], [CategoryId]) VALUES (6, N'PDSA Application Security Audit', CAST(N'2015-07-01T00:00:00.000' AS DateTime), 2000.0000, N'http://www.pdsa.com/audits', 1)
GO
INSERT [dbo].[Product] ([ProductId], [ProductName], [IntroductionDate], [Price], [Url], [CategoryId]) VALUES (7, N'PDSA SQL Server and Database Design Audit', CAST(N'2015-08-01T00:00:00.000' AS DateTime), 2000.0000, N'http://www.pdsa.com/audits', 1)
GO
INSERT [dbo].[Product] ([ProductId], [ProductName], [IntroductionDate], [Price], [Url], [CategoryId]) VALUES (8, N'PDSA Mentoring', CAST(N'2015-09-01T00:00:00.000' AS DateTime), 200.0000, N'http://www.pdsa.com/mentoring', 1)
GO
INSERT [dbo].[Product] ([ProductId], [ProductName], [IntroductionDate], [Price], [Url], [CategoryId]) VALUES (9, N'PDSA Training', CAST(N'2015-10-01T00:00:00.000' AS DateTime), 2000.0000, N'http://www.pdsa.com/training', 1)
GO
INSERT [dbo].[Product] ([ProductId], [ProductName], [IntroductionDate], [Price], [Url], [CategoryId]) VALUES (10, N'Build HTML Helper Library for ASP.NET MVC 5', CAST(N'2016-11-05T00:00:00.000' AS DateTime), 49.0000, N'http://bit.ly/1myXBwj', 2)
GO
INSERT [dbo].[Product] ([ProductId], [ProductName], [IntroductionDate], [Price], [Url], [CategoryId]) VALUES (11, N'Consolidating MVC Views using Single Page Techniques', CAST(N'2015-10-09T00:00:00.000' AS DateTime), 499.0000, N'http://bit.ly/1G8TeQO', 2)
GO
INSERT [dbo].[Product] ([ProductId], [ProductName], [IntroductionDate], [Price], [Url], [CategoryId]) VALUES (12, N'Extending Bootstrap with CSS, JavaScript and jQuery', CAST(N'2015-06-11T00:00:00.000' AS DateTime), 499.0000, N'http://bit.ly/1SNzc0i', 2)
GO
INSERT [dbo].[Product] ([ProductId], [ProductName], [IntroductionDate], [Price], [Url], [CategoryId]) VALUES (13, N'Build your own Bootstrap Business Application Template in MVC', CAST(N'2015-01-29T00:00:00.000' AS DateTime), 499.0000, N'http://bit.ly/1I8ZqZg', 2)
GO
INSERT [dbo].[Product] ([ProductId], [ProductName], [IntroductionDate], [Price], [Url], [CategoryId]) VALUES (14, N'Building Mobile Web Sites Using Web Forms, Bootstrap, and HTML5', CAST(N'2014-08-28T00:00:00.000' AS DateTime), 499.0000, N'http://bit.ly/1J2dcrj', 2)
GO
INSERT [dbo].[Product] ([ProductId], [ProductName], [IntroductionDate], [Price], [Url], [CategoryId]) VALUES (15, N'How to Start and Run A Consulting Business', CAST(N'2013-09-12T00:00:00.000' AS DateTime), 499.0000, N'http://bit.ly/1L8kOwd', 2)
GO
INSERT [dbo].[Product] ([ProductId], [ProductName], [IntroductionDate], [Price], [Url], [CategoryId]) VALUES (16, N'The Many Approaches to XML Processing in .NET Applications', CAST(N'2013-07-22T00:00:00.000' AS DateTime), 499.0000, N'http://bit.ly/1DBfUqd', 2)
GO
INSERT [dbo].[Product] ([ProductId], [ProductName], [IntroductionDate], [Price], [Url], [CategoryId]) VALUES (17, N'WPF for the Business Programmer', CAST(N'2009-06-12T00:00:00.000' AS DateTime), 499.0000, N'http://bit.ly/1UF858z', 2)
GO
INSERT [dbo].[Product] ([ProductId], [ProductName], [IntroductionDate], [Price], [Url], [CategoryId]) VALUES (18, N'WPF for the Visual Basic Programmer - Part 1', CAST(N'2013-12-16T00:00:00.000' AS DateTime), 499.0000, N'http://bit.ly/1uFxS7C', 2)
GO
INSERT [dbo].[Product] ([ProductId], [ProductName], [IntroductionDate], [Price], [Url], [CategoryId]) VALUES (19, N'WPF for the Visual Basic Programmer - Part 2', CAST(N'2014-02-18T00:00:00.000' AS DateTime), 499.0000, N'http://bit.ly/1MjQ9NG', 2)
GO
INSERT [dbo].[Product] ([ProductId], [ProductName], [IntroductionDate], [Price], [Url], [CategoryId]) VALUES (20, N'PDSA Application Performance Audit', CAST(N'2016-01-01T00:00:00.000' AS DateTime), 2000.0000, N'http://www.pdsa.com/audits', 1)
GO
INSERT [dbo].[Product] ([ProductId], [ProductName], [IntroductionDate], [Price], [Url], [CategoryId]) VALUES (39, N'The Journey from MVC to Angular', CAST(N'2016-07-22T00:00:00.000' AS DateTime), 10.0000, N'http://bit.ly/2a3wVNU', 1)
GO
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
INSERT [Security].[User] ([UserId], [UserName], [Password]) VALUES (N'4a1947ec-099c-4532-8105-64cf8c8b4b94', N'PSheriff', N'P@ssw0rd')
GO
INSERT [Security].[User] ([UserId], [UserName], [Password]) VALUES (N'898c9784-e31f-4f37-927f-a157eb7ca215', N'BJones', N'P@ssw0rd')
GO
INSERT [Security].[UserClaim] ([ClaimId], [UserId], [ClaimType], [ClaimValue]) VALUES (N'a3530e23-bea8-4e68-807e-86db9e80db11', N'898c9784-e31f-4f37-927f-a157eb7ca215', N'CanAddProduct', N'false')
GO
INSERT [Security].[UserClaim] ([ClaimId], [UserId], [ClaimType], [ClaimValue]) VALUES (N'cbb1b376-e315-400f-8457-6d0753c24f0f', N'4a1947ec-099c-4532-8105-64cf8c8b4b94', N'CanAccessProducts', N'true')
GO
INSERT [Security].[UserClaim] ([ClaimId], [UserId], [ClaimType], [ClaimValue]) VALUES (N'408b006c-e76e-4503-aee9-1985a4a3786a', N'4a1947ec-099c-4532-8105-64cf8c8b4b94', N'CanAddProduct', N'true')
GO
INSERT [Security].[UserClaim] ([ClaimId], [UserId], [ClaimType], [ClaimValue]) VALUES (N'ec624240-6a3a-4557-bbed-4aca1dddbc6b', N'4a1947ec-099c-4532-8105-64cf8c8b4b94', N'CanSaveProduct', N'true')
GO
INSERT [Security].[UserClaim] ([ClaimId], [UserId], [ClaimType], [ClaimValue]) VALUES (N'4eb3c52b-1fd3-4f6e-8631-d99a4be7f3ae', N'4a1947ec-099c-4532-8105-64cf8c8b4b94', N'CanAccessCategories', N'true')
GO
INSERT [Security].[UserClaim] ([ClaimId], [UserId], [ClaimType], [ClaimValue]) VALUES (N'dea74b80-defb-4a73-9100-53ecd98b0b88', N'4a1947ec-099c-4532-8105-64cf8c8b4b94', N'CanAddCategory', N'true')
GO
INSERT [Security].[UserClaim] ([ClaimId], [UserId], [ClaimType], [ClaimValue]) VALUES (N'71baa2ad-e169-42d1-b913-10123ac68074', N'898c9784-e31f-4f37-927f-a157eb7ca215', N'CanAccessProducts', N'true')
GO
INSERT [Security].[UserClaim] ([ClaimId], [UserId], [ClaimType], [ClaimValue]) VALUES (N'057f4ecc-8245-4234-8a9d-5a63bb3df02c', N'898c9784-e31f-4f37-927f-a157eb7ca215', N'CanAddCategory', N'true')
GO
INSERT [Security].[UserClaim] ([ClaimId], [UserId], [ClaimType], [ClaimValue]) VALUES (N'0d8004ca-a9e1-4f25-b9d9-e7d1e2ec3283', N'898c9784-e31f-4f37-927f-a157eb7ca215', N'CanAccessCategories', N'true')
GO
/****** Object:  Index [PK__User__1788CC4D72609948]    Script Date: 3/11/2018 1:41:13 PM ******/
ALTER TABLE [Security].[User] ADD  CONSTRAINT [PK__User__1788CC4D72609948] PRIMARY KEY NONCLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK__UserClai__EF2E139A0133A934]    Script Date: 3/11/2018 1:41:13 PM ******/
ALTER TABLE [Security].[UserClaim] ADD  CONSTRAINT [PK__UserClai__EF2E139A0133A934] PRIMARY KEY NONCLUSTERED 
(
	[ClaimId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [Security].[User] ADD  CONSTRAINT [DF__User__UserId__31B762FC]  DEFAULT (newid()) FOR [UserId]
GO
ALTER TABLE [Security].[UserClaim] ADD  CONSTRAINT [DF__UserClaim__Claim__3493CFA7]  DEFAULT (newid()) FOR [ClaimId]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
ALTER TABLE [Security].[UserClaim]  WITH CHECK ADD  CONSTRAINT [FK_UserClaim_User] FOREIGN KEY([UserId])
REFERENCES [Security].[User] ([UserId])
GO
ALTER TABLE [Security].[UserClaim] CHECK CONSTRAINT [FK_UserClaim_User]
GO

----------------------------------------------------------------------------------------
										JWT
----------------------------------------------------------------------------------------
dotnet add package System.IdentityModel.Tokens.Jwt
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer

---------------
Resolve error - 
Package 'System.IdentityModel.Tokens' is incompatible with 'all' frameworks in project

dotnet nuget locals all --clear
dotnet restore --force
---------------

