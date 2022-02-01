USE [PrivacyDB]
GO
/****** Object:  Table [dbo].[Linked]    Script Date: 2022/1/26 22:45:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Linked](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[TraineeId] [bigint] NOT NULL,
	[TrainerId] [bigint] NOT NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_Linked] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PrivacyUser]    Script Date: 2022/1/26 22:45:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PrivacyUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](100) NULL,
	[UserType] [nvarchar](50) NULL,
	[FKId] [bigint] NULL,
 CONSTRAINT [PK_PrivacyUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trainee]    Script Date: 2022/1/26 22:45:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trainee](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Gender] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](200) NOT NULL,
	[Interesting] [nvarchar](500) NOT NULL,
	[Location] [nvarchar](500) NULL,
	[Email] [nvarchar](50) NOT NULL,
	[CreateDateTime] [datetime] NOT NULL,
	[ImageUrl] [nvarchar](500) NULL,
 CONSTRAINT [PK_Trainee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trainer]    Script Date: 2022/1/26 22:45:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trainer](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Gender] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[KindOfTrainer] [nvarchar](500) NOT NULL,
	[Certificate] [nvarchar](50) NULL,
	[DescribeYourself] [nvarchar](max) NULL,
	[Location] [nvarchar](500) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[CreateDateTime] [datetime] NOT NULL,
	[TeachingType] [nvarchar](50) NULL,
	[ImageUrl] [nvarchar](500) NULL,
 CONSTRAINT [PK_Trainer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Linked] ON 
GO
INSERT [dbo].[Linked] ([Id], [TraineeId], [TrainerId], [Status]) VALUES (2, 9, 0, 0)
GO
INSERT [dbo].[Linked] ([Id], [TraineeId], [TrainerId], [Status]) VALUES (3, 9, 0, 0)
GO
INSERT [dbo].[Linked] ([Id], [TraineeId], [TrainerId], [Status]) VALUES (4, 9, 0, 0)
GO
INSERT [dbo].[Linked] ([Id], [TraineeId], [TrainerId], [Status]) VALUES (6, 9, 10, 1)
GO
INSERT [dbo].[Linked] ([Id], [TraineeId], [TrainerId], [Status]) VALUES (8, 9, 11, 1)
GO
SET IDENTITY_INSERT [dbo].[Linked] OFF
GO
SET IDENTITY_INSERT [dbo].[PrivacyUser] ON 
GO
INSERT [dbo].[PrivacyUser] ([Id], [Username], [Password], [UserType], [FKId]) VALUES (2, N'admin', N'8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', N'Admin', 0)
GO
INSERT [dbo].[PrivacyUser] ([Id], [Username], [Password], [UserType], [FKId]) VALUES (8, N'111', N'f6e0a1e2ac41945a9aa7ff8a8aaa0cebc12a3bcc981a929ad5cf810a090e11ae', N'Trainee', 9)
GO
INSERT [dbo].[PrivacyUser] ([Id], [Username], [Password], [UserType], [FKId]) VALUES (11, N'444', N'3538a1ef2e113da64249eea7bd068b585ec7ce5df73b2d1e319d8c9bf47eb314', N'Trainer', 10)
GO
INSERT [dbo].[PrivacyUser] ([Id], [Username], [Password], [UserType], [FKId]) VALUES (12, N'555', N'91a73fd806ab2c005c13b4dc19130a884e909dea3f72d46e30266fe1a1f588d8', N'Trainer', 11)
GO
SET IDENTITY_INSERT [dbo].[PrivacyUser] OFF
GO
SET IDENTITY_INSERT [dbo].[Trainee] ON 
GO
INSERT [dbo].[Trainee] ([Id], [Gender], [Phone], [Interesting], [Location], [Email], [CreateDateTime], [ImageUrl]) VALUES (7, N'Femail', N'+6115838232222', N'Health,Education', N'1321321', N'2834400100@qq.com', CAST(N'2021-12-29T00:35:03.343' AS DateTime), NULL)
GO
INSERT [dbo].[Trainee] ([Id], [Gender], [Phone], [Interesting], [Location], [Email], [CreateDateTime], [ImageUrl]) VALUES (8, N'Male', N'+61158333333', N'Health,Education,Arts,Sports', N'333333', N'5820460114@qq.com', CAST(N'2022-01-17T19:02:46.600' AS DateTime), NULL)
GO
INSERT [dbo].[Trainee] ([Id], [Gender], [Phone], [Interesting], [Location], [Email], [CreateDateTime], [ImageUrl]) VALUES (9, N'Male', N'+6115838232222', N'Health,Education', N'1111', N'582046014@qq.com', CAST(N'2022-01-23T21:19:29.110' AS DateTime), N'/Images/2019c425-e077-492b-81e6-8861575db717.jpg')
GO
SET IDENTITY_INSERT [dbo].[Trainee] OFF
GO
SET IDENTITY_INSERT [dbo].[Trainer] ON 
GO
INSERT [dbo].[Trainer] ([Id], [Gender], [Phone], [KindOfTrainer], [Certificate], [DescribeYourself], [Location], [Email], [CreateDateTime], [TeachingType], [ImageUrl]) VALUES (10, N'Femail', N'+61157777777', N'Health,Education', N'2342432', N'2432432', N'32423', N'582046014@qq.com', CAST(N'2022-01-24T23:17:25.237' AS DateTime), N'In person', N'/Images/af1faf2b-d49b-484b-b5da-11187d0ec866.jpg')
GO
INSERT [dbo].[Trainer] ([Id], [Gender], [Phone], [KindOfTrainer], [Certificate], [DescribeYourself], [Location], [Email], [CreateDateTime], [TeachingType], [ImageUrl]) VALUES (11, N'Femail', N'+61555', N'Education', N'2342432', N'2432432', N'32423', N'582046014@qq.com', CAST(N'2022-01-26T22:04:05.653' AS DateTime), N'In person', N'/Images/e6016ebb-06eb-48c3-bd2e-ccea7f538c40.jpg')
GO
SET IDENTITY_INSERT [dbo].[Trainer] OFF
GO