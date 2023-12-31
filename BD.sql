USE [KinderGartenDB]
GO
/****** Object:  User [admins]    Script Date: 24.06.2023 12:07:48 ******/
CREATE USER [admins] FOR LOGIN [admins] WITH DEFAULT_SCHEMA=[db_accessadmin]
GO
/****** Object:  User [KinderGartens]    Script Date: 24.06.2023 12:07:48 ******/
CREATE USER [KinderGartens] FOR LOGIN [KinderGarten] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Children]    Script Date: 24.06.2023 12:07:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Children](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FatherId] [int] NULL,
	[MomId] [int] NULL,
	[GroupID] [int] NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
 CONSTRAINT [PK__Children__3214EC27ED892BF4] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Groups]    Script Date: 24.06.2023 12:07:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Teachers1Id] [int] NULL,
	[Teachers2Id] [int] NULL,
	[Name] [nvarchar](50) NOT NULL,
	[AgeFrom] [int] NOT NULL,
	[AgeTo] [int] NOT NULL,
	[MaxCapacity] [int] NOT NULL,
 CONSTRAINT [PK__Groups__3214EC271CC39AEF] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Parents]    Script Date: 24.06.2023 12:07:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parents](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[NumberPhone] [char](18) NOT NULL,
	[SerialPasport] [char](4) NOT NULL,
	[NumberPasport] [char](6) NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK__Parents__3214EC27961A67A5] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedule]    Script Date: 24.06.2023 12:07:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedule](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NOT NULL,
	[StartTime] [time](7) NOT NULL,
	[EndTime] [time](7) NOT NULL,
	[Activity] [nvarchar](100) NOT NULL,
	[GroupID] [int] NULL,
	[TeacherID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 24.06.2023 12:07:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teachers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[NumberPhone] [char](18) NOT NULL,
	[SerialPasport] [char](4) NOT NULL,
	[NumberPasport] [char](6) NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
	[Salary] [char](12) NOT NULL,
	[HireDate] [date] NULL,
	[PhotoTeachers] [nvarchar](max) NULL,
 CONSTRAINT [PK__Teachers__3214EC277CB56365] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 24.06.2023 12:07:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](55) NOT NULL,
	[Password] [char](55) NOT NULL,
	[FullName] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Children] ON 

INSERT [dbo].[Children] ([ID], [FatherId], [MomId], [GroupID], [Name], [Surname], [DateOfBirth]) VALUES (1, 4, 5, 2, N'Иван', N'Кирносов', CAST(N'2019-05-22' AS Date))
INSERT [dbo].[Children] ([ID], [FatherId], [MomId], [GroupID], [Name], [Surname], [DateOfBirth]) VALUES (2, 6, 7, 3, N'Борис', N'Туов', CAST(N'2020-03-21' AS Date))
INSERT [dbo].[Children] ([ID], [FatherId], [MomId], [GroupID], [Name], [Surname], [DateOfBirth]) VALUES (3, 8, 9, 3, N'Жанибек', N'Юсупов', CAST(N'2019-12-01' AS Date))
SET IDENTITY_INSERT [dbo].[Children] OFF
GO
SET IDENTITY_INSERT [dbo].[Groups] ON 

INSERT [dbo].[Groups] ([ID], [Teachers1Id], [Teachers2Id], [Name], [AgeFrom], [AgeTo], [MaxCapacity]) VALUES (2, 8, 9, N'Солнышки', 2, 3, 22)
INSERT [dbo].[Groups] ([ID], [Teachers1Id], [Teachers2Id], [Name], [AgeFrom], [AgeTo], [MaxCapacity]) VALUES (3, 9, 8, N'Журавлики', 3, 4, 21)
SET IDENTITY_INSERT [dbo].[Groups] OFF
GO
SET IDENTITY_INSERT [dbo].[Parents] ON 

INSERT [dbo].[Parents] ([ID], [Name], [Surname], [NumberPhone], [SerialPasport], [NumberPasport], [Address]) VALUES (4, N'Серафим', N'Кирносов', N'79182334214       ', N'3213', N'543566', N'Г.Майкоп Ул.Кужорская 102')
INSERT [dbo].[Parents] ([ID], [Name], [Surname], [NumberPhone], [SerialPasport], [NumberPasport], [Address]) VALUES (5, N'Валерия', N'Кирносова', N'79214334123       ', N'4324', N'432432', N'Г.Майкоп Ул.Кужорская 102')
INSERT [dbo].[Parents] ([ID], [Name], [Surname], [NumberPhone], [SerialPasport], [NumberPasport], [Address]) VALUES (6, N'Эльдар', N'Туов', N'79432442342       ', N'5243', N'534253', N'Г.Майкоп Ул.Кооперативная 76')
INSERT [dbo].[Parents] ([ID], [Name], [Surname], [NumberPhone], [SerialPasport], [NumberPasport], [Address]) VALUES (7, N'Юлия', N'Туова', N'79432432344       ', N'5343', N'432432', N'Г.Майкоп Ул.Кооперативная 76')
INSERT [dbo].[Parents] ([ID], [Name], [Surname], [NumberPhone], [SerialPasport], [NumberPasport], [Address]) VALUES (8, N'Айдамир', N'Юсупов', N'79382132432       ', N'4324', N'423452', N'Г.Майкоп Ул.Хакурате 342')
INSERT [dbo].[Parents] ([ID], [Name], [Surname], [NumberPhone], [SerialPasport], [NumberPasport], [Address]) VALUES (9, N'Жанна', N'Юсупова', N'79823442342       ', N'2344', N'654321', N'Г.Майкоп Ул.Хакурате 432')
INSERT [dbo].[Parents] ([ID], [Name], [Surname], [NumberPhone], [SerialPasport], [NumberPasport], [Address]) VALUES (12, N'Давид', N'Крицкий', N'+7(918) 320 32 42 ', N'3211', N'32324 ', N'ва')
SET IDENTITY_INSERT [dbo].[Parents] OFF
GO
SET IDENTITY_INSERT [dbo].[Schedule] ON 

INSERT [dbo].[Schedule] ([ID], [Date], [StartTime], [EndTime], [Activity], [GroupID], [TeacherID]) VALUES (17, CAST(N'2023-05-29' AS Date), CAST(N'10:00:00' AS Time), CAST(N'10:40:00' AS Time), N'Рисование', 3, 9)
INSERT [dbo].[Schedule] ([ID], [Date], [StartTime], [EndTime], [Activity], [GroupID], [TeacherID]) VALUES (19, CAST(N'2023-05-29' AS Date), CAST(N'10:00:00' AS Time), CAST(N'10:40:00' AS Time), N'Физкультура', 2, 15)
INSERT [dbo].[Schedule] ([ID], [Date], [StartTime], [EndTime], [Activity], [GroupID], [TeacherID]) VALUES (20, CAST(N'2023-05-30' AS Date), CAST(N'10:00:00' AS Time), CAST(N'10:40:00' AS Time), N'Технология', 3, 10)
SET IDENTITY_INSERT [dbo].[Schedule] OFF
GO
SET IDENTITY_INSERT [dbo].[Teachers] ON 

INSERT [dbo].[Teachers] ([ID], [Name], [Surname], [NumberPhone], [SerialPasport], [NumberPasport], [Address], [Salary], [HireDate], [PhotoTeachers]) VALUES (8, N'Анна', N'Валерьевна', N'79123428342       ', N'4324', N'423564', N'Г.Майкоп Ул.Димитрова 32', N'25000.00    ', CAST(N'2022-02-21' AS Date), N'77.jpg')
INSERT [dbo].[Teachers] ([ID], [Name], [Surname], [NumberPhone], [SerialPasport], [NumberPasport], [Address], [Salary], [HireDate], [PhotoTeachers]) VALUES (9, N'Борис', N'Демидов', N'79132134242       ', N'4325', N'423423', N'Г.Майкоп Ул.Шовгенова 322', N'30000.00    ', CAST(N'2022-04-22' AS Date), N'photo2.jpg')
INSERT [dbo].[Teachers] ([ID], [Name], [Surname], [NumberPhone], [SerialPasport], [NumberPasport], [Address], [Salary], [HireDate], [PhotoTeachers]) VALUES (10, N'Ева', N'Кутузова', N'79813424325       ', N'4236', N'654463', N'Г.Майкоп Ул.Комунаров 123', N'45000.00    ', CAST(N'2022-02-01' AS Date), N'photo3.jpg')
INSERT [dbo].[Teachers] ([ID], [Name], [Surname], [NumberPhone], [SerialPasport], [NumberPasport], [Address], [Salary], [HireDate], [PhotoTeachers]) VALUES (11, N'Светлана', N'Боярко', N'79143284324       ', N'7433', N'438438', N'Г.Майкоп Ул.Кирпичная 21', N'25000.00    ', CAST(N'2018-12-12' AS Date), N'99.jpg')
INSERT [dbo].[Teachers] ([ID], [Name], [Surname], [NumberPhone], [SerialPasport], [NumberPasport], [Address], [Salary], [HireDate], [PhotoTeachers]) VALUES (15, N'Алла', N'Фёдоровна', N'79238257799       ', N'8734', N'432324', N'Г.Майкоп Ул.Юнатов 10', N'30000.00    ', CAST(N'2021-01-21' AS Date), N'photo6.jpg')
SET IDENTITY_INSERT [dbo].[Teachers] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([ID], [Login], [Password], [FullName]) VALUES (1, N'qwert', N'1234                                                   ', N'Жасмин Алибековна')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Children]  WITH CHECK ADD  CONSTRAINT [FK__Children__GroupI__2E1BDC42] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Groups] ([ID])
GO
ALTER TABLE [dbo].[Children] CHECK CONSTRAINT [FK__Children__GroupI__2E1BDC42]
GO
ALTER TABLE [dbo].[Children]  WITH CHECK ADD  CONSTRAINT [FK__Children__Parent__2D27B809] FOREIGN KEY([MomId])
REFERENCES [dbo].[Parents] ([ID])
GO
ALTER TABLE [dbo].[Children] CHECK CONSTRAINT [FK__Children__Parent__2D27B809]
GO
ALTER TABLE [dbo].[Children]  WITH CHECK ADD  CONSTRAINT [FK_Children_Parents] FOREIGN KEY([FatherId])
REFERENCES [dbo].[Parents] ([ID])
GO
ALTER TABLE [dbo].[Children] CHECK CONSTRAINT [FK_Children_Parents]
GO
ALTER TABLE [dbo].[Groups]  WITH CHECK ADD  CONSTRAINT [FK_Groups_Teachers] FOREIGN KEY([Teachers1Id])
REFERENCES [dbo].[Teachers] ([ID])
GO
ALTER TABLE [dbo].[Groups] CHECK CONSTRAINT [FK_Groups_Teachers]
GO
ALTER TABLE [dbo].[Groups]  WITH CHECK ADD  CONSTRAINT [FK_Groups_Teachers1] FOREIGN KEY([Teachers2Id])
REFERENCES [dbo].[Teachers] ([ID])
GO
ALTER TABLE [dbo].[Groups] CHECK CONSTRAINT [FK_Groups_Teachers1]
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [FK_Schedule_Teachers] FOREIGN KEY([TeacherID])
REFERENCES [dbo].[Teachers] ([ID])
GO
ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [FK_Schedule_Teachers]
GO
