using System;
using System.Collections.Generic;
using System.Text;

namespace MostriVsEroi.BusinessLayer
{
    public class Arma
    {
        public string Nome { get; set; }
        public int PuntiDanno { get; set; }

        public Arma(string nome, int punti)
        {
            Nome = nome;
            PuntiDanno = punti;
        }



    }
}
