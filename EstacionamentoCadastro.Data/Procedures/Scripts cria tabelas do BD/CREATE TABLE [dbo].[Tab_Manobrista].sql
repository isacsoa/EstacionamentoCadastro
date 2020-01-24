USE [Estacionamento_Cadastro]
GO

/****** Object:  Table [dbo].[Tab_Manobrista]    Script Date: 23/01/2020 22:30:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Tab_Manobrista](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[NomeManobrista] [varchar](100) NULL,
	[CPF] [varchar](11) NULL,
	[DataNascimento] [date] NULL,
 CONSTRAINT [PK_Tab_Manobrista] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO