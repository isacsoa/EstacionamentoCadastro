USE [Estacionamento_Cadastro]
GO

/****** Object:  Table [dbo].[Tab_Carro]    Script Date: 23/01/2020 22:27:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Tab_Carro](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Marca] [varchar](50) NULL,
	[Modelo] [varchar](50) NULL,
	[Placa] [varchar](7) NULL,
 CONSTRAINT [PK_Tab_Carro] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO