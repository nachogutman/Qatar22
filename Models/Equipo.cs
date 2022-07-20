using System.Dynamic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;

namespace Qatar22.Models{
    public class Equipo{

        private int _idEquipo;
        private string _nombre;
        private string _escudo;
        private string _camiseta;
        private string _continente;
        private int _copasGanadas;
        private string _video;

        public Equipo(string pnombre, string pescudo, string pcamiseta, string pcontinente, int pcopasGanadas, string pvideo){
            
            _nombre = pnombre;
            _escudo = pescudo;
            _camiseta = pcamiseta;
            _continente = pcontinente;
            _copasGanadas = pcopasGanadas;
            _video = pvideo;

        }

        public Equipo(){
            _idEquipo = 1;
            _nombre = "";
            _escudo= "";
            _camiseta = "";
            _continente = "";
            _copasGanadas = 0;
            _video = "";

        }

        public int IdEquipo{
            get{return _idEquipo;}
            set{_idEquipo = value;}
        }

        public string Nombre{
            get{return _nombre;}
            set{_nombre = value;}
        }

        public string Escudo{
            get{return _escudo;}
            set{_escudo = value;}
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

        public string Video{
            get{return _video;}
            set{_video = value;}
        }

    }
}