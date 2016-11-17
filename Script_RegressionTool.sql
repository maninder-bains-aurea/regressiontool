USE [RegressionTool]
GO
/****** Object:  Table [dbo].[LoginUser]    Script Date: 11/16/2016 7:02:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginUser](
	[Id] [int] NOT NULL,
	[UserName] [nvarchar](200) NOT NULL,
	[Password] [nvarchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Regression]    Script Date: 11/16/2016 7:02:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Regression](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[MapName] [nvarchar](200) NULL,
	[StatusId] [int] NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
 CONSTRAINT [PK__Regressi__3214EC07A97D1DC6] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Regression_ASP_TP]    Script Date: 11/16/2016 7:02:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Regression_ASP_TP](
	[Id] [int] NOT NULL,
	[RegressionId] [int] NOT NULL,
	[Asp_tpId] [int] NOT NULL,
	[Asp_tpCode] [nvarchar](100) NOT NULL,
	[Client] [nvarchar](100) NOT NULL,
	[Utility] [nvarchar](100) NOT NULL,
	[Matches] [int] NULL,
	[Diff] [int] NULL,
	[StatusId] [int] NOT NULL,
 CONSTRAINT [PK__Regressi__3214EC07780E7E02] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RegressionFiles]    Script Date: 11/16/2016 7:02:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegressionFiles](
	[Id] [int] NOT NULL,
	[Regression_ASP_TPID] [int] NOT NULL,
	[PresTranslatedFilename] [nvarchar](200) NOT NULL,
	[PostTranslatedFilename ] [nvarchar](200) NOT NULL,
	[LocalLoationPreTranslatedFile] [nvarchar](200) NOT NULL,
	[LocalLoationPostTranslatedFile] [nvarchar](200) NOT NULL,
	[TransDate] [datetime] NOT NULL,
	[Matching] [bit] NULL,
	[StatusId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RegressionStatus]    Script Date: 11/16/2016 7:02:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegressionStatus](
	[Id] [int] NOT NULL,
	[StatusType] [int] NOT NULL,
	[Description] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[LoginUser] ([Id], [UserName], [Password]) VALUES (1, N'admin', N'admin123')
GO
SET IDENTITY_INSERT [dbo].[Regression] ON 

GO
INSERT [dbo].[Regression] ([Id], [UserId], [MapName], [StatusId], [StartDate], [EndDate]) VALUES (1, 1, N'OECP8104010V40_PGE_GIS', 1, CAST(N'2016-11-13 19:17:23.507' AS DateTime), NULL)
GO
INSERT [dbo].[Regression] ([Id], [UserId], [MapName], [StatusId], [StartDate], [EndDate]) VALUES (2, 1, N'OECP8104010V40_PGE_GIS', 2, CAST(N'2016-11-13 19:17:23.507' AS DateTime), CAST(N'2016-11-16 16:16:48.963' AS DateTime))
GO
INSERT [dbo].[Regression] ([Id], [UserId], [MapName], [StatusId], [StartDate], [EndDate]) VALUES (3, 1, N'Test New Map', 1, CAST(N'2016-11-16 00:00:00.000' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[Regression] OFF
GO
INSERT [dbo].[Regression_ASP_TP] ([Id], [RegressionId], [Asp_tpId], [Asp_tpCode], [Client], [Utility], [Matches], [Diff], [StatusId]) VALUES (1, 1, 19990, N'COMCA006912877', N'Continuum', N'Semco', NULL, NULL, 1)
GO
INSERT [dbo].[Regression_ASP_TP] ([Id], [RegressionId], [Asp_tpId], [Asp_tpCode], [Client], [Utility], [Matches], [Diff], [StatusId]) VALUES (2, 1, 20020, N'CO3CA006912877', N'Continuum', N'Semco', NULL, NULL, 1)
GO
INSERT [dbo].[Regression_ASP_TP] ([Id], [RegressionId], [Asp_tpId], [Asp_tpCode], [Client], [Utility], [Matches], [Diff], [StatusId]) VALUES (3, 2, 38356, N'CONMIMICHCONG1ENRO', N'Continuum', N'Semco', NULL, NULL, 1)
GO
INSERT [dbo].[RegressionFiles] ([Id], [Regression_ASP_TPID], [PresTranslatedFilename], [PostTranslatedFilename ], [LocalLoationPreTranslatedFile], [LocalLoationPostTranslatedFile], [TransDate], [Matching], [StatusId]) VALUES (1, 3, N'Requirements\\File_1.txt', N'Requirements\\File_2.txt', N'D:\\', N'D:\\', CAST(N'2016-11-13 19:19:26.063' AS DateTime), 1, 8)
GO
INSERT [dbo].[RegressionFiles] ([Id], [Regression_ASP_TPID], [PresTranslatedFilename], [PostTranslatedFilename ], [LocalLoationPreTranslatedFile], [LocalLoationPostTranslatedFile], [TransDate], [Matching], [StatusId]) VALUES (2, 3, N'Requirements\\File_1.txt', N'Requirements\\File_2.txt', N'D:\\', N'D:\\', CAST(N'2016-11-13 19:19:26.063' AS DateTime), 1, 8)
GO
INSERT [dbo].[RegressionFiles] ([Id], [Regression_ASP_TPID], [PresTranslatedFilename], [PostTranslatedFilename ], [LocalLoationPreTranslatedFile], [LocalLoationPostTranslatedFile], [TransDate], [Matching], [StatusId]) VALUES (3, 3, N'Requirements\\File_1.txt', N'Requirements\\File_2.txt', N'D:\\', N'D:\\', CAST(N'2016-11-13 19:19:26.063' AS DateTime), 1, 8)
GO
INSERT [dbo].[RegressionFiles] ([Id], [Regression_ASP_TPID], [PresTranslatedFilename], [PostTranslatedFilename ], [LocalLoationPreTranslatedFile], [LocalLoationPostTranslatedFile], [TransDate], [Matching], [StatusId]) VALUES (4, 2, N'Requirements\\File_1.txt', N'Requirements\\File_2.txt', N'D:\\', N'D:\\', CAST(N'2016-11-13 19:19:26.060' AS DateTime), 1, 8)
GO
INSERT [dbo].[RegressionFiles] ([Id], [Regression_ASP_TPID], [PresTranslatedFilename], [PostTranslatedFilename ], [LocalLoationPreTranslatedFile], [LocalLoationPostTranslatedFile], [TransDate], [Matching], [StatusId]) VALUES (5, 2, N'Requirements\\File_1.txt', N'Requirements\\File_2.txt', N'D:\\', N'D:\\', CAST(N'2016-11-13 19:19:26.060' AS DateTime), 1, 8)
GO
INSERT [dbo].[RegressionFiles] ([Id], [Regression_ASP_TPID], [PresTranslatedFilename], [PostTranslatedFilename ], [LocalLoationPreTranslatedFile], [LocalLoationPostTranslatedFile], [TransDate], [Matching], [StatusId]) VALUES (6, 2, N'Requirements\\File_1.txt', N'Requirements\\File_2.txt', N'D:\\', N'D:\\', CAST(N'2016-11-13 19:19:26.060' AS DateTime), 1, 8)
GO
INSERT [dbo].[RegressionFiles] ([Id], [Regression_ASP_TPID], [PresTranslatedFilename], [PostTranslatedFilename ], [LocalLoationPreTranslatedFile], [LocalLoationPostTranslatedFile], [TransDate], [Matching], [StatusId]) VALUES (7, 2, N'Requirements\\File_1.txt', N'Requirements\\File_2.txt', N'D:\\', N'D:\\', CAST(N'2016-11-13 19:19:26.063' AS DateTime), 1, 8)
GO
INSERT [dbo].[RegressionFiles] ([Id], [Regression_ASP_TPID], [PresTranslatedFilename], [PostTranslatedFilename ], [LocalLoationPreTranslatedFile], [LocalLoationPostTranslatedFile], [TransDate], [Matching], [StatusId]) VALUES (8, 2, N'Requirements\\File_1.txt', N'Requirements\\File_2.txt', N'D:\\', N'D:\\', CAST(N'2016-11-13 19:19:26.063' AS DateTime), 1, 8)
GO
INSERT [dbo].[RegressionFiles] ([Id], [Regression_ASP_TPID], [PresTranslatedFilename], [PostTranslatedFilename ], [LocalLoationPreTranslatedFile], [LocalLoationPostTranslatedFile], [TransDate], [Matching], [StatusId]) VALUES (9, 2, N'Requirements\\File_1.txt', N'Requirements\\File_2.txt', N'D:\\', N'D:\\', CAST(N'2016-11-13 19:19:26.063' AS DateTime), 1, 8)
GO
INSERT [dbo].[RegressionStatus] ([Id], [StatusType], [Description]) VALUES (1, 1, N'In Progress')
GO
INSERT [dbo].[RegressionStatus] ([Id], [StatusType], [Description]) VALUES (2, 1, N'Completed')
GO
INSERT [dbo].[RegressionStatus] ([Id], [StatusType], [Description]) VALUES (3, 2, N'Needs Download')
GO
INSERT [dbo].[RegressionStatus] ([Id], [StatusType], [Description]) VALUES (4, 2, N'Downloading')
GO
INSERT [dbo].[RegressionStatus] ([Id], [StatusType], [Description]) VALUES (5, 2, N'Downloaded')
GO
INSERT [dbo].[RegressionStatus] ([Id], [StatusType], [Description]) VALUES (6, 2, N'Need Dropping')
GO
INSERT [dbo].[RegressionStatus] ([Id], [StatusType], [Description]) VALUES (7, 2, N'Dropped')
GO
INSERT [dbo].[RegressionStatus] ([Id], [StatusType], [Description]) VALUES (8, 2, N'Translated')
GO
INSERT [dbo].[RegressionStatus] ([Id], [StatusType], [Description]) VALUES (9, 3, N'Not Calculated')
GO
INSERT [dbo].[RegressionStatus] ([Id], [StatusType], [Description]) VALUES (10, 3, N'Calculated')
GO
ALTER TABLE [dbo].[Regression]  WITH CHECK ADD  CONSTRAINT [fk_regression_statusid] FOREIGN KEY([StatusId])
REFERENCES [dbo].[RegressionStatus] ([Id])
GO
ALTER TABLE [dbo].[Regression] CHECK CONSTRAINT [fk_regression_statusid]
GO
ALTER TABLE [dbo].[Regression]  WITH CHECK ADD  CONSTRAINT [fk_regression_userid] FOREIGN KEY([UserId])
REFERENCES [dbo].[LoginUser] ([Id])
GO
ALTER TABLE [dbo].[Regression] CHECK CONSTRAINT [fk_regression_userid]
GO
ALTER TABLE [dbo].[Regression_ASP_TP]  WITH CHECK ADD  CONSTRAINT [FK_Regression_ASP_TP_Regression] FOREIGN KEY([RegressionId])
REFERENCES [dbo].[Regression] ([Id])
GO
ALTER TABLE [dbo].[Regression_ASP_TP] CHECK CONSTRAINT [FK_Regression_ASP_TP_Regression]
GO
ALTER TABLE [dbo].[Regression_ASP_TP]  WITH CHECK ADD  CONSTRAINT [FK_Regression_ASP_TP_RegressionStatus] FOREIGN KEY([StatusId])
REFERENCES [dbo].[RegressionStatus] ([Id])
GO
ALTER TABLE [dbo].[Regression_ASP_TP] CHECK CONSTRAINT [FK_Regression_ASP_TP_RegressionStatus]
GO
ALTER TABLE [dbo].[RegressionFiles]  WITH CHECK ADD  CONSTRAINT [fk_regressionfiles_regression_asp_tpid] FOREIGN KEY([Regression_ASP_TPID])
REFERENCES [dbo].[Regression_ASP_TP] ([Id])
GO
ALTER TABLE [dbo].[RegressionFiles] CHECK CONSTRAINT [fk_regressionfiles_regression_asp_tpid]
GO
ALTER TABLE [dbo].[RegressionFiles]  WITH CHECK ADD  CONSTRAINT [fk_regressionfiles_statusid] FOREIGN KEY([StatusId])
REFERENCES [dbo].[RegressionStatus] ([Id])
GO
ALTER TABLE [dbo].[RegressionFiles] CHECK CONSTRAINT [fk_regressionfiles_statusid]
GO
USE [master]
GO
ALTER DATABASE [RegressionTool] SET  READ_WRITE 
GO
