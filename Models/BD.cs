using System.Data;
using System;
using System.Dynamic;
using Microsoft.VisualBasic.CompilerServices;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;

namespace Qatar22.Models{
    public static class BD{

        private static string _connectionString = @"Server=A-AMI-214;DataBase=Qatar2022;Trusted_Connection=True;";

        public static void AgregarJugador(Jugador jug){

            string SQL = "INSERT INTO Jugadores(IdEquipo, Nombre, FechaNacimiento, Foto, EquipoActual) VALUES(@pIdEquipo, @pNombre, @pFechaNacimiento, @pFoto, @pEquipoActual)";
            using(SqlConnection db = new SqlConnection(_connectionString)){
                db.Execute(SQL, new{pIdEquipo = jug.IdEquipo, pNombre = jug.Nombre,pFechaNacimiento = jug.FechaNacimiento, pFoto = jug.Foto, pEquipoActual = jug.EquipoActual});
            }

        }

        public static void EliminarJugador(int IdJugador){

            string SQL = "DELETE FROM Jugadores WHERE IdJugador = @pIdJugador";
            using(SqlConnection db = new SqlConnection(_connectionString)){
                db.Execute(SQL, new{pIdJugador = IdJugador});
            }

        }

        public static Equipo VerInfoEquipo(int IdEquipo){
            Equipo miEquipo = null;
            string SQL = "SELECT * FROM Equipos WHERE IdEquipo = @pIdEquipo";
            using(SqlConnection db = new SqlConnection(_connectionString)){
                miEquipo = db.QueryFirstOrDefault<Equipo>(SQL, new{pIdEquipo = IdEquipo});
            }
            return miEquipo;
        }

        public static Jugador VerInfoJugador(int IdJugador){
            Jugador miJugador = null;
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

        public static List<Jugador> ListarJugadores(){
            List<Jugador> listaJugadores = new List<Jugador>();
            string SQL = "SELECT * FROM Jugadores";
            using(SqlConnection db = new SqlConnection(_connectionString)){
                listaJugadores = db.Query<Jugador>(SQL).ToList();
            }
            return listaJugadores;
        }



    }

}

