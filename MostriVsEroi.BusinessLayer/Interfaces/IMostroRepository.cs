using System;
using System.Collections.Generic;
using System.Text;

namespace MostriVsEroi.BusinessLayer
{
    public interface IMostroRepository
    {
        public List<Mostro> FetchMostri();
        public void AddMostro(Mostro m, int idCategoria, int idArma, int idLivello);
        public bool VerificaNome(string nome);
    }



}