USE [Ecoli]
GO
/****** Object:  Table [dbo].[ProteinInfoes]    Script Date: 31-Dec-20 2:43:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProteinInfoes](
	[ID] [nvarchar](255) NOT NULL,
	[ProteinDescription] [nvarchar](max) NOT NULL,
	[MW] [float] NOT NULL,
	[Seq] [nvarchar](max) NOT NULL,
	[Insilico] [nvarchar](max) NOT NULL,
	[InsilicoR] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.ProteinInfoes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
