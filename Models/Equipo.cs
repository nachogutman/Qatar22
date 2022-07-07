using System.Dynamic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;

namespace Qatar22.Models{
    public class Equipo{

        private int _idEquipo;
        private string _nombre;
        private string _camiseta;
        private string _continente;
        private int _copasGanadas;

        public Equipo(int pequipo, string pnombre, string pcamiseta, string pcontinente, int pcopasGanadas){

            _idEquipo = pequipo;
            _nombre = pnombre;
            _camiseta = pcamiseta;
            _continente = pcontinente;
            _copasGanadas = pcopasGanadas;

        }

        public Equipo(){

            _idEquipo = 0;
            _nombre = "";
            _camiseta = "";
            _continente = "";
            _copasGanadas = 0;

        }

        public int IdEquipo{
            get{return _idEquipo;}
            set{_idEquipo = value;}
        }

        public string Nombre{
            get{return _nombre;}
            set{_nombre = value;}
        }

        public string Camiseta{
            
            get{return _camiseta;}
            set{_camiseta = value;}
        
        }

        public string Continente{
            get{return _continente;}
            set{_continente = value;}
        }   

        public int CopasGanadas{
            get{return _copasGanadas;}
            set{_copasGanadas = value;}
        }

    }
}