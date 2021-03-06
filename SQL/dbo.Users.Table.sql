USE [MVCDb]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 6/27/2020 5:37:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[UserPassword] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [UserName], [UserPassword]) VALUES (1, N'Admin', N'e10adc3949ba59abbe56e057f20f883e')
INSERT [dbo].[Users] ([Id], [UserName], [UserPassword]) VALUES (2, N'User', N'e10adc3949ba59abbe56e057f20f883e')
INSERT [dbo].[Users] ([Id], [UserName], [UserPassword]) VALUES (3, N'Customer', N'e10adc3949ba59abbe56e057f20f883e')
SET IDENTITY_INSERT [dbo].[Users] OFF
