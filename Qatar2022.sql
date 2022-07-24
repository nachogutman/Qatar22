USE [Qatar2022]
GO
/****** Object:  Table [dbo].[Equipos]    Script Date: 24/7/2022 17:47:16 ******/
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
	[Video] [varchar](50) NULL,
 CONSTRAINT [PK_Equipos] PRIMARY KEY CLUSTERED 
(
	[IdEquipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Jugadores]    Script Date: 24/7/2022 17:47:16 ******/
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

INSERT [dbo].[Equipos] ([IdEquipo], [Nombre], [Escudo], [Camiseta], [Continente], [CopasGanadas], [Video]) VALUES (10, N'Argentina', N'/escudoArgentina.png', N'https://www.camisetasclubes.com/shop/images/A85613.png', N'America', 2, N'https://www.youtube.com/embed/7mEH2NtiT-Y')
INSERT [dbo].[Equipos] ([IdEquipo], [Nombre], [Escudo], [Camiseta], [Continente], [CopasGanadas], [Video]) VALUES (15, N'Eslovaquia', N'/escudoEslovaquia.png', N'https://cf.camisetasfutbol.com.cn/upload/ttmall/img/20210407/73356b1284d4a58fcd95495dc517140f.png', N'Europa', 0, N'https://www.youtube.com/embed/G1ZliMZg_hY')
INSERT [dbo].[Equipos] ([IdEquipo], [Nombre], [Escudo], [Camiseta], [Continente], [CopasGanadas], [Video]) VALUES (16, N'Brasil', N'/brasil.png', N'/camisetaBrasil.png', N'America', 5, N'https://www.youtube.com/embed/9fatir172OY')
INSERT [dbo].[Equipos] ([IdEquipo], [Nombre], [Escudo], [Camiseta], [Continente], [CopasGanadas], [Video]) VALUES (17, N'Alemania', N'/alemania.png', N'/camisetaAlemania.png', N'Europa', 4, N'https://www.youtube.com/embed/dSPteGTMEFY')
SET IDENTITY_INSERT [dbo].[Equipos] OFF
GO
SET IDENTITY_INSERT [dbo].[Jugadores] ON 

INSERT [dbo].[Jugadores] ([IdJugador], [IdEquipo], [Nombre], [FechaNacimiento], [Foto], [EquipoActual], [NumCamiseta]) VALUES (1, 10, N'Lionel Messi ', CAST(N'1987-06-24T00:00:00.000' AS DateTime), N'/messi.jpg', N'París Saint-Germain Football Club', 10)
INSERT [dbo].[Jugadores] ([IdJugador], [IdEquipo], [Nombre], [FechaNacimiento], [Foto], [EquipoActual], [NumCamiseta]) VALUES (2, 15, N'Marek Hamšík', CAST(N'1987-07-27T00:00:00.000' AS DateTime), N'/hamsik.jpg', N'Trabzonspor', 17)
INSERT [dbo].[Jugadores] ([IdJugador], [IdEquipo], [Nombre], [FechaNacimiento], [Foto], [EquipoActual], [NumCamiseta]) VALUES (6, 10, N'Emiliano Martínez', CAST(N'1992-09-02T00:00:00.000' AS DateTime), N'/dibu.jpg', N'Aston Villa Football Club', 23)
INSERT [dbo].[Jugadores] ([IdJugador], [IdEquipo], [Nombre], [FechaNacimiento], [Foto], [EquipoActual], [NumCamiseta]) VALUES (7, 10, N'Ángel Di María', CAST(N'1988-02-14T00:00:00.000' AS DateTime), N'/dimaria.jpg', N'Juventus de Turín', 11)
INSERT [dbo].[Jugadores] ([IdJugador], [IdEquipo], [Nombre], [FechaNacimiento], [Foto], [EquipoActual], [NumCamiseta]) VALUES (8, 10, N'Nicolás Otamendi', CAST(N'1988-02-12T00:00:00.000' AS DateTime), N'/otamendi.jpg', N'Sport Lisboa e Benfica', 19)
INSERT [dbo].[Jugadores] ([IdJugador], [IdEquipo], [Nombre], [FechaNacimiento], [Foto], [EquipoActual], [NumCamiseta]) VALUES (9, 15, N'Marek Rodak', CAST(N'1996-12-13T00:00:00.000' AS DateTime), N'/marekrodak.jpg', N'Fulham Football Club', 23)
INSERT [dbo].[Jugadores] ([IdJugador], [IdEquipo], [Nombre], [FechaNacimiento], [Foto], [EquipoActual], [NumCamiseta]) VALUES (10, 15, N'Róbert Boženík', CAST(N'1999-11-18T00:00:00.000' AS DateTime), N'/robertbozenik.jpg', N'Boavista Futebol Clube', 9)
INSERT [dbo].[Jugadores] ([IdJugador], [IdEquipo], [Nombre], [FechaNacimiento], [Foto], [EquipoActual], [NumCamiseta]) VALUES (13, 15, N'Tomas Suslov', CAST(N'2002-06-07T00:00:00.000' AS DateTime), N'/tomasuslov.jpg', N'FC Groningen', 10)
INSERT [dbo].[Jugadores] ([IdJugador], [IdEquipo], [Nombre], [FechaNacimiento], [Foto], [EquipoActual], [NumCamiseta]) VALUES (15, 16, N'Neymar da Silva Santos Jr.', CAST(N'1992-02-05T00:00:00.000' AS DateTime), N'/neymar.webp', N'París Saint-Germain FC', 10)
INSERT [dbo].[Jugadores] ([IdJugador], [IdEquipo], [Nombre], [FechaNacimiento], [Foto], [EquipoActual], [NumCamiseta]) VALUES (16, 16, N'Daniel Alves da Silva', CAST(N'1983-05-06T00:00:00.000' AS DateTime), N'/danialves.jpg', N'Pumas UNAM', 13)
INSERT [dbo].[Jugadores] ([IdJugador], [IdEquipo], [Nombre], [FechaNacimiento], [Foto], [EquipoActual], [NumCamiseta]) VALUES (17, 16, N' Vinicius  de Oliveira Jr.', CAST(N'2000-07-12T00:00:00.000' AS DateTime), N'/vinicius.jpg', N'Real Madrid CF', 20)
INSERT [dbo].[Jugadores] ([IdJugador], [IdEquipo], [Nombre], [FechaNacimiento], [Foto], [EquipoActual], [NumCamiseta]) VALUES (18, 17, N'Manuel Neuer', CAST(N'1986-03-27T00:00:00.000' AS DateTime), N'/neuer.jpg', N'Bayern Múnich', 1)
INSERT [dbo].[Jugadores] ([IdJugador], [IdEquipo], [Nombre], [FechaNacimiento], [Foto], [EquipoActual], [NumCamiseta]) VALUES (19, 17, N'Thomas Müller', CAST(N'1989-09-13T00:00:00.000' AS DateTime), N'/muller.jpg', N'Bayern Múnich', 13)
INSERT [dbo].[Jugadores] ([IdJugador], [IdEquipo], [Nombre], [FechaNacimiento], [Foto], [EquipoActual], [NumCamiseta]) VALUES (20, 17, N'Ilkay Gündogan', CAST(N'1990-10-24T00:00:00.000' AS DateTime), N'/gundogan.jpg', N'Manchester City', 21)
SET IDENTITY_INSERT [dbo].[Jugadores] OFF
GO
