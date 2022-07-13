USE [Qatar2022]
GO
/****** Object:  Table [dbo].[Equipos]    Script Date: 13/7/2022 11:51:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipos](
	[IdEquipo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Escudo] [varchar](200) NOT NULL,
	[Camiseta] [varchar](200) NOT NULL,
	[Continente] [varchar](50) NOT NULL,
	[CopasGanadas] [int] NOT NULL,
 CONSTRAINT [PK_Equipos] PRIMARY KEY CLUSTERED 
(
	[IdEquipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Jugadores]    Script Date: 13/7/2022 11:51:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jugadores](
	[IdJugador] [int] IDENTITY(1,1) NOT NULL,
	[IdEquipo] [int] NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[FechaNacimiento] [datetime] NOT NULL,
	[Foto] [varchar](200) NOT NULL,
	[EquipoActual] [varchar](50) NOT NULL,
	[NumCamiseta] [int] NOT NULL,
 CONSTRAINT [PK_Jugadores] PRIMARY KEY CLUSTERED 
(
	[IdJugador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Equipos] ON 

INSERT [dbo].[Equipos] ([IdEquipo], [Nombre], [Escudo], [Camiseta], [Continente], [CopasGanadas]) VALUES (1, N'Somalia', N'https://upload.wikimedia.org/wikipedia/commons/thumb/e/eb/Coat_of_arms_of_Somalia.svg/250px-Coat_of_arms_of_Somalia.svg.png', N'https://www.uksoccershop.com/images/1534950308-somalia-flag-airo-front.jpg', N'Africa', 0)
INSERT [dbo].[Equipos] ([IdEquipo], [Nombre], [Escudo], [Camiseta], [Continente], [CopasGanadas]) VALUES (10, N'Argentina', N'https://upload.wikimedia.org/wikipedia/commons/thumb/f/ff/Coat_of_arms_of_Argentina.svg/150px-Coat_of_arms_of_Argentina.svg.png', N'https://tn.com.ar/resizer/44marJSXlT5N-IOgnOI5Wm7jxf8=/1440x0/smart/cloudfront-us-east-1.images.arcpublishing.com/artear/JF5RNX6W6VCANMD4WLRCRUAGLM.jfif', N'America', 2)
INSERT [dbo].[Equipos] ([IdEquipo], [Nombre], [Escudo], [Camiseta], [Continente], [CopasGanadas]) VALUES (15, N'Eslovaquia', N'https://upload.wikimedia.org/wikipedia/commons/thumb/d/d2/Coat_of_arms_of_Slovakia.svg/180px-Coat_of_arms_of_Slovakia.svg.png', N'https://todosobrecamisetas.com/wp-content/uploads/slovakia-2020-21-nike-kits-1.jpg', N'Europa', 0)
SET IDENTITY_INSERT [dbo].[Equipos] OFF
GO
