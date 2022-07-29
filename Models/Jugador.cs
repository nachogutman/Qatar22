using System;
using System.Dynamic;
using Microsoft.VisualBasic.CompilerServices;
using System.Collections.Generic;

namespace Qatar22.Models{

    public class Jugador{

        private int _idJugador;        
        private int _idEquipo;
        private string _nombre;
        private DateTime _fechaNacimiento;
        private string _foto;
        private string _equipoActual;

        private int _numCamiseta;

        public Jugador(int pidEquipo, string pnombre, DateTime pfechaNacimiento, string pfoto, string pequipoActual, int pnumCamiseta){
            
            _idEquipo = pidEquipo;
            _nombre = pnombre;
            _fechaNacimiento = pfechaNacimiento;
            _foto = pfoto;
            _equipoActual = pequipoActual;
            _numCamiseta = pnumCamiseta;
        }

        public Jugador(){
            _idEquipo = 0;
            _nombre = "";
            _fechaNacimiento = new DateTime(1, 1, 1);
            _foto = "";
            _equipoActual = "";
            _numCamiseta = 99;
        }


        public int NumCamiseta{
            get{return _numCamiseta;}
            set{_numCamiseta = value;}
        }
        public int IdJugador{
            get {return _idJugador;}
            set{_idJugador = value;}
        }

        public int IdEquipo{
            get {return _idEquipo;}
            set{_idEquipo = value;}
        }

        public string Nombre{
            get {return _nombre;}
            set{_nombre = value;}
        }

        public DateTime FechaNacimiento{
            get {return _fechaNacimiento;}
            set{_fechaNacimiento = value;}
        }

        public string Foto{
            get {return _foto;}
            set{_foto = value;}
        }

        public string EquipoActual{
            get {return _equipoActual;}
            set{_equipoActual = value;}
        }
    }
}