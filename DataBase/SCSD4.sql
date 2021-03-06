USE [SCSD]
GO
/****** Object:  Table [dbo].[FileMetadata]    Script Date: 03/18/2015 16:27:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FileMetadata](
	[Id] [varchar](300) NOT NULL,
	[Name] [varbinary](max) NULL,
	[Type] [varbinary](max) NULL,
	[Description] [varchar](max) NULL,
	[ApplicationType] [varbinary](max) NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_FileMetadata] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FileKey]    Script Date: 03/18/2015 16:27:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FileKey](
	[Id] [int] IDENTITY(2000,1) NOT NULL,
	[SYMKey] [varchar](max) NULL,
	[ASYMKey] [varbinary](max) NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_FileKey] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FileContent]    Script Date: 03/18/2015 16:27:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FileContent](
	[Id] [int] IDENTITY(1000,1) NOT NULL,
	[FileId] [varchar](300) NULL,
	[FileData] [varbinary](max) NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_FileContent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FileBanar]    Script Date: 03/18/2015 16:27:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FileBanar](
	[Id] [int] IDENTITY(1000,1) NOT NULL,
	[Banar] [varbinary](max) NULL,
	[Type] [varchar](max) NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_FileBanar] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MappingUsers]    Script Date: 03/18/2015 16:27:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MappingUsers](
	[Id] [int] IDENTITY(1000,1) NOT NULL,
	[ParentUser] [varchar](300) NOT NULL,
	[ChildUser] [varchar](300) NOT NULL,
	[FileId] [varchar](300) NOT NULL,
	[Active] [bit] NULL,
	[AccessPermission] [varchar](30) NULL,
 CONSTRAINT [PK_MappingUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 03/18/2015 16:27:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [varchar](300) NOT NULL,
	[Name] [varchar](200) NULL,
	[Age] [int] NULL,
	[Gender] [varchar](50) NULL,
	[DOB] [varchar](50) NULL,
	[Marital] [varchar](50) NULL,
	[CreatedAt] [varchar](50) NULL,
	[ModifiedAt] [varchar](50) NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserType]    Script Date: 03/18/2015 16:27:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserType](
	[Id] [int] IDENTITY(10,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_UserType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserGroupType]    Script Date: 03/18/2015 16:27:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserGroupType](
	[Id] [int] IDENTITY(10,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_UserGroupType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserAuthentication]    Script Date: 03/18/2015 16:27:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserAuthentication](
	[Id] [int] IDENTITY(5000,1) NOT NULL,
	[UserId] [varchar](300) NULL,
	[UserName] [varchar](max) NULL,
	[Password] [varchar](max) NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_UserAuthentication] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MappingUserType]    Script Date: 03/18/2015 16:27:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MappingUserType](
	[Id] [int] IDENTITY(100,1) NOT NULL,
	[UserId] [varchar](300) NOT NULL,
	[UserTypeId] [int] NOT NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_MappingUserType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MappingUserGroup]    Script Date: 03/18/2015 16:27:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MappingUserGroup](
	[Id] [int] IDENTITY(100,1) NOT NULL,
	[UserId] [varchar](300) NOT NULL,
	[UserGroupId] [int] NOT NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_MappingUserGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MappingFileUser]    Script Date: 03/18/2015 16:27:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MappingFileUser](
	[Id] [int] IDENTITY(1000,1) NOT NULL,
	[UserId] [varchar](300) NULL,
	[FileId] [varchar](300) NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_MappingFileUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MappingFileKey]    Script Date: 03/18/2015 16:27:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MappingFileKey](
	[Id] [int] IDENTITY(100,1) NOT NULL,
	[FileId] [varchar](300) NULL,
	[KeyId] [int] NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_MappingFileKey] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MappingFileContent]    Script Date: 03/18/2015 16:27:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MappingFileContent](
	[Id] [int] IDENTITY(100,1) NOT NULL,
	[FileId] [varchar](300) NULL,
	[ContentId] [int] NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_MappingFileContent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MappingFileCheckSum]    Script Date: 03/18/2015 16:27:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MappingFileCheckSum](
	[Id] [int] IDENTITY(100,1) NOT NULL,
	[FileId] [varchar](300) NULL,
	[FileCheckSum] [varchar](max) NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_MappingFileCheckSum] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MappingFileBanar]    Script Date: 03/18/2015 16:27:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MappingFileBanar](
	[Id] [int] IDENTITY(100,1) NOT NULL,
	[FileId] [varchar](300) NULL,
	[BanarId] [int] NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_MappingFileBanar] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_MappingFileBanar_FileBanar]    Script Date: 03/18/2015 16:27:26 ******/
ALTER TABLE [dbo].[MappingFileBanar]  WITH CHECK ADD  CONSTRAINT [FK_MappingFileBanar_FileBanar] FOREIGN KEY([BanarId])
REFERENCES [dbo].[FileBanar] ([Id])
GO
ALTER TABLE [dbo].[MappingFileBanar] CHECK CONSTRAINT [FK_MappingFileBanar_FileBanar]
GO
/****** Object:  ForeignKey [FK_MappingFileBanar_FileMetadata]    Script Date: 03/18/2015 16:27:26 ******/
ALTER TABLE [dbo].[MappingFileBanar]  WITH CHECK ADD  CONSTRAINT [FK_MappingFileBanar_FileMetadata] FOREIGN KEY([FileId])
REFERENCES [dbo].[FileMetadata] ([Id])
GO
ALTER TABLE [dbo].[MappingFileBanar] CHECK CONSTRAINT [FK_MappingFileBanar_FileMetadata]
GO
/****** Object:  ForeignKey [FK_MappingFileCheckSum_FileMetadata]    Script Date: 03/18/2015 16:27:26 ******/
ALTER TABLE [dbo].[MappingFileCheckSum]  WITH CHECK ADD  CONSTRAINT [FK_MappingFileCheckSum_FileMetadata] FOREIGN KEY([FileId])
REFERENCES [dbo].[FileMetadata] ([Id])
GO
ALTER TABLE [dbo].[MappingFileCheckSum] CHECK CONSTRAINT [FK_MappingFileCheckSum_FileMetadata]
GO
/****** Object:  ForeignKey [FK_MappingFileContent_FileContent]    Script Date: 03/18/2015 16:27:26 ******/
ALTER TABLE [dbo].[MappingFileContent]  WITH CHECK ADD  CONSTRAINT [FK_MappingFileContent_FileContent] FOREIGN KEY([ContentId])
REFERENCES [dbo].[FileContent] ([Id])
GO
ALTER TABLE [dbo].[MappingFileContent] CHECK CONSTRAINT [FK_MappingFileContent_FileContent]
GO
/****** Object:  ForeignKey [FK_MappingFileContent_FileMetadata]    Script Date: 03/18/2015 16:27:26 ******/
ALTER TABLE [dbo].[MappingFileContent]  WITH CHECK ADD  CONSTRAINT [FK_MappingFileContent_FileMetadata] FOREIGN KEY([FileId])
REFERENCES [dbo].[FileMetadata] ([Id])
GO
ALTER TABLE [dbo].[MappingFileContent] CHECK CONSTRAINT [FK_MappingFileContent_FileMetadata]
GO
/****** Object:  ForeignKey [FK_MappingFileKey_FileKey]    Script Date: 03/18/2015 16:27:26 ******/
ALTER TABLE [dbo].[MappingFileKey]  WITH CHECK ADD  CONSTRAINT [FK_MappingFileKey_FileKey] FOREIGN KEY([KeyId])
REFERENCES [dbo].[FileKey] ([Id])
GO
ALTER TABLE [dbo].[MappingFileKey] CHECK CONSTRAINT [FK_MappingFileKey_FileKey]
GO
/****** Object:  ForeignKey [FK_MappingFileKey_FileMetadata]    Script Date: 03/18/2015 16:27:26 ******/
ALTER TABLE [dbo].[MappingFileKey]  WITH CHECK ADD  CONSTRAINT [FK_MappingFileKey_FileMetadata] FOREIGN KEY([FileId])
REFERENCES [dbo].[FileMetadata] ([Id])
GO
ALTER TABLE [dbo].[MappingFileKey] CHECK CONSTRAINT [FK_MappingFileKey_FileMetadata]
GO
/****** Object:  ForeignKey [FK_MappingFileUser_FileMetadata]    Script Date: 03/18/2015 16:27:26 ******/
ALTER TABLE [dbo].[MappingFileUser]  WITH CHECK ADD  CONSTRAINT [FK_MappingFileUser_FileMetadata] FOREIGN KEY([FileId])
REFERENCES [dbo].[FileMetadata] ([Id])
GO
ALTER TABLE [dbo].[MappingFileUser] CHECK CONSTRAINT [FK_MappingFileUser_FileMetadata]
GO
/****** Object:  ForeignKey [FK_MappingFileUser_User]    Script Date: 03/18/2015 16:27:26 ******/
ALTER TABLE [dbo].[MappingFileUser]  WITH CHECK ADD  CONSTRAINT [FK_MappingFileUser_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[MappingFileUser] CHECK CONSTRAINT [FK_MappingFileUser_User]
GO
/****** Object:  ForeignKey [FK_MappingUserGroup_User]    Script Date: 03/18/2015 16:27:26 ******/
ALTER TABLE [dbo].[MappingUserGroup]  WITH CHECK ADD  CONSTRAINT [FK_MappingUserGroup_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[MappingUserGroup] CHECK CONSTRAINT [FK_MappingUserGroup_User]
GO
/****** Object:  ForeignKey [FK_MappingUserGroup_UserGroupType]    Script Date: 03/18/2015 16:27:26 ******/
ALTER TABLE [dbo].[MappingUserGroup]  WITH CHECK ADD  CONSTRAINT [FK_MappingUserGroup_UserGroupType] FOREIGN KEY([UserGroupId])
REFERENCES [dbo].[UserGroupType] ([Id])
GO
ALTER TABLE [dbo].[MappingUserGroup] CHECK CONSTRAINT [FK_MappingUserGroup_UserGroupType]
GO
/****** Object:  ForeignKey [FK_MappingUserType_User]    Script Date: 03/18/2015 16:27:26 ******/
ALTER TABLE [dbo].[MappingUserType]  WITH CHECK ADD  CONSTRAINT [FK_MappingUserType_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[MappingUserType] CHECK CONSTRAINT [FK_MappingUserType_User]
GO
/****** Object:  ForeignKey [FK_MappingUserType_UserType]    Script Date: 03/18/2015 16:27:26 ******/
ALTER TABLE [dbo].[MappingUserType]  WITH CHECK ADD  CONSTRAINT [FK_MappingUserType_UserType] FOREIGN KEY([UserTypeId])
REFERENCES [dbo].[UserType] ([Id])
GO
ALTER TABLE [dbo].[MappingUserType] CHECK CONSTRAINT [FK_MappingUserType_UserType]
GO
/****** Object:  ForeignKey [FK_UserAuthentication_User]    Script Date: 03/18/2015 16:27:26 ******/
ALTER TABLE [dbo].[UserAuthentication]  WITH CHECK ADD  CONSTRAINT [FK_UserAuthentication_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[UserAuthentication] CHECK CONSTRAINT [FK_UserAuthentication_User]
GO
