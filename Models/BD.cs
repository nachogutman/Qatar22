using System;
using System.Data;
using System.Net;
using System.Dynamic;
using Microsoft.VisualBasic.CompilerServices;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;

namespace Qatar22.Models{
    
    public static class BD{        

        private static string server = Dns.GetHostName();
        private static string _connectionString = @$"Server={server};DataBase=Qatar2022;Trusted_Connection=True;";        

        public static void AgregarJugador(Jugador jug){

            string SQL = "INSERT INTO Jugadores(IdEquipo, Nombre, FechaNacimiento, Foto, EquipoActual, NumCamiseta) VALUES(@pIdEquipo, @pNombre, @pFechaNacimiento, @pFoto, @pEquipoActual, @pNumCamiseta)";
            using(SqlConnection db = new SqlConnection(_connectionString)){
                db.Execute(SQL, new{pIdEquipo = jug.IdEquipo, pNombre = jug.Nombre,pFechaNacimiento = jug.FechaNacimiento, pFoto = jug.Foto, pEquipoActual = jug.EquipoActual, pNumCamiseta = jug.NumCamiseta});
            }

        }

        public static void AgregarEquipo(Equipo equi){

            string SQL = "INSERT INTO Equipos(Nombre, Escudo, Camiseta, Continente, CopasGanadas) VALUES(@pNombre, @pEscudo, @pCamiseta, @pContinente, @pCopasGanadas)";
            using(SqlConnection db = new SqlConnection(_connectionString)){
                db.Execute(SQL, new{pNombre = equi.Nombre, pEscudo = equi.Escudo, pCamiseta = equi.Camiseta, pContinente = equi.Continente, pCopasGanadas = equi.CopasGanadas});
            }

        }

        public static void EliminarJugador(int IdJugador){
                       
            Jugador miJugador = VerInfoJugador(IdJugador);     
            File.Delete(Directory.GetCurrentDirectory() + miJugador.Foto);
            string SQL = "DELETE FROM Jugadores WHERE IdJugador = @pIdJugador";
            using(SqlConnection db = new SqlConnection(_connectionString)){
                db.Execute(SQL, new{pIdJugador = IdJugador});
            }
        }

        public static Equipo VerInfoEquipo(int IdEquipo){
            Equipo miEquipo;
            string SQL = "SELECT * FROM Equipos WHERE IdEquipo = @pIdEquipo";
            using(SqlConnection db = new SqlConnection(_connectionString)){
                miEquipo = db.QueryFirstOrDefault<Equipo>(SQL, new{pIdEquipo = IdEquipo});
            }
            return miEquipo;
        }

        public static Jugador VerInfoJugador(int IdJugador){
            Jugador miJugador;
            string SQL = "SELECT * FROM Jugadores WHERE IdJugador = @pIdJugador";
            using(SqlConnection db = new SqlConnection(_connectionString)){
                miJugador = db.QueryFirstOrDefault<Jugador>(SQL, new{pIdJugador = IdJugador});
            }
            return miJugador;
        }

        public static List<Equipo> ListarEquipos(){
            List<Equipo> listaEquipos = new List<Equipo>();
            string SQL = "SELECT * FROM Equipos";
            using(SqlConnection db = new SqlConnection(_connectionString)){
                listaEquipos = db.Query<Equipo>(SQL).ToList();
            }
            return listaEquipos;
        }

        public static List<Jugador> ListarJugadores(int IdEquipo){
            List<Jugador> listaJugadores = new List<Jugador>();
            string SQL = "SELECT * FROM Jugadores WHERE IdEquipo = @pIdEquipo";
            using(SqlConnection db = new SqlConnection(_connectionString)){
                listaJugadores = db.Query<Jugador>(SQL, new{pIdEquipo = IdEquipo}).ToList();
            }
            return listaJugadores;
        }



    }

}

