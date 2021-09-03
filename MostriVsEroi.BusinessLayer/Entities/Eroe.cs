using System;
using System.Collections.Generic;
using System.Text;

namespace MostriVsEroi.BusinessLayer
{
    public class Eroe
    {
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public int Livello { get; set; }
        public int PuntiVita { get; set; }
        public int PuntiAccumulati { get; set; }
        public Arma Arma { get; set; }

        public Eroe()
        {

        }

        public Eroe(string nome, string categoria, int livello, int puntiVita, int puntiAccumulati)
        {
            Nome = nome;
            Categoria = categoria;
            Livello = livello;
            PuntiVita = puntiVita;
            PuntiAccumulati = puntiAccumulati;
        }

        public Eroe(string nome, string categoria, int livello, Arma arma, int puntiVita, int puntiAccumulati)
        {
            Nome = nome;
            Categoria = categoria;
            Livello = livello;
            PuntiVita = puntiVita;
            PuntiAccumulati = puntiAccumulati;
            Arma = arma;
        }



    }
}
