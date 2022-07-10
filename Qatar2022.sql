USE [Qatar2022]
GO
/****** Object:  Table [dbo].[Equipos]    Script Date: 10/7/2022 19:05:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipos](
	[idEquipo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Escudo] [varchar](200) NOT NULL,
	[Camiseta] [varchar](200) NOT NULL,
	[Continente] [varchar](50) NOT NULL,
	[CopasGanadas] [int] NOT NULL,
 CONSTRAINT [PK_Equipos] PRIMARY KEY CLUSTERED 
(
	[idEquipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Jugadores]    Script Date: 10/7/2022 19:05:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jugadores](
	[idJugador] [int] IDENTITY(1,1) NOT NULL,
	[IdEquipo] [int] NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[FechaNacimiento] [datetime] NOT NULL,
	[Foto] [varchar](200) NOT NULL,
	[EquipoActual] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Jugadores] PRIMARY KEY CLUSTERED 
(
	[idJugador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Equipos] ON 

INSERT [dbo].[Equipos] ([idEquipo], [Nombre], [Escudo], [Camiseta], [Continente], [CopasGanadas]) VALUES (1, N'Somalia', N'https://upload.wikimedia.org/wikipedia/commons/thumb/e/eb/Coat_of_arms_of_Somalia.svg/250px-Coat_of_arms_of_Somalia.svg.png', N'https://www.uksoccershop.com/images/1534950308-somalia-flag-airo-front.jpg', N'Africa', 0)
SET IDENTITY_INSERT [dbo].[Equipos] OFF
GO
ALTER TABLE [dbo].[Jugadores]  WITH CHECK ADD  CONSTRAINT [FK_Jugadores_Equipos] FOREIGN KEY([IdEquipo])
REFERENCES [dbo].[Equipos] ([idEquipo])
GO
ALTER TABLE [dbo].[Jugadores] CHECK CONSTRAINT [FK_Jugadores_Equipos]
GO
