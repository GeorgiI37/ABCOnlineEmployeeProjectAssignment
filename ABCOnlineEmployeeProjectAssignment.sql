USE [ABCEmployeeDB]
GO
/****** Object:  Table [dbo].[EmployeeProjects]    Script Date: 4/22/2022 2:17:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeProjects](
	[EmployeeNumber] [int] NOT NULL,
	[ProjectCode] [nvarchar](6) NOT NULL,
	[Id] [int] NOT NULL,
 CONSTRAINT [PK_EmployeeProjects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employees]    Script Date: 4/22/2022 2:17:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeNumber] [int] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Managers]    Script Date: 4/22/2022 2:17:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Managers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Managers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Projects]    Script Date: 4/22/2022 2:17:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[ProjectCode] [nvarchar](6) NOT NULL,
	[ProjectTitle] [nvarchar](100) NOT NULL,
	[DueDate] [date] NOT NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[ProjectCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[EmployeeProjects]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeProjects_Employees] FOREIGN KEY([EmployeeNumber])
REFERENCES [dbo].[Employees] ([EmployeeNumber])
GO
ALTER TABLE [dbo].[EmployeeProjects] CHECK CONSTRAINT [FK_EmployeeProjects_Employees]
GO
ALTER TABLE [dbo].[EmployeeProjects]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeProjects_Projects] FOREIGN KEY([ProjectCode])
REFERENCES [dbo].[Projects] ([ProjectCode])
GO
ALTER TABLE [dbo].[EmployeeProjects] CHECK CONSTRAINT [FK_EmployeeProjects_Projects]
GO
