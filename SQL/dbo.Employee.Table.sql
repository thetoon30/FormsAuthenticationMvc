USE [MVCDb]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 6/27/2020 5:37:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Gender] [char](10) NULL,
	[Age] [int] NULL,
	[Position] [nvarchar](50) NULL,
	[Office] [nvarchar](50) NULL,
	[HireDate] [datetime] NULL,
	[Salary] [decimal](18, 0) NULL,
	[DepartmentId] [int] NULL,
 CONSTRAINT [PK__Employee__3214EC07E5F1AB7E] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([Id], [Name], [Gender], [Age], [Position], [Office], [HireDate], [Salary], [DepartmentId]) VALUES (1, N'Anurag', NULL, NULL, N'Software Engineer', NULL, NULL, CAST(10000 AS Decimal(18, 0)), NULL)
INSERT [dbo].[Employee] ([Id], [Name], [Gender], [Age], [Position], [Office], [HireDate], [Salary], [DepartmentId]) VALUES (2, N'Preety', NULL, NULL, N'Tester', NULL, NULL, CAST(20000 AS Decimal(18, 0)), NULL)
INSERT [dbo].[Employee] ([Id], [Name], [Gender], [Age], [Position], [Office], [HireDate], [Salary], [DepartmentId]) VALUES (3, N'Priyanka', NULL, NULL, N'Software Engineer', NULL, NULL, CAST(20000 AS Decimal(18, 0)), NULL)
SET IDENTITY_INSERT [dbo].[Employee] OFF
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK__Employee__Depart__15502E78] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK__Employee__Depart__15502E78]
GO
