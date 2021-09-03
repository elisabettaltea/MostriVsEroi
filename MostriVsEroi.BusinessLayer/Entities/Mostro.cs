using System;
using System.Collections.Generic;
using System.Text;

namespace MostriVsEroi.BusinessLayer
{
    public class Mostro

    {
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public Arma Arma { get; set; }
        public int Livello { get; set; }
        public int PuntiVita { get; set; }

        public Mostro(string nome, string categoria, Arma arma, int livello, int puntiVita)
        {
            Nome = nome;
            Categoria = categoria;
            Arma = arma;
            Livello = livello;
            PuntiVita = puntiVita;
        }



    }
}
