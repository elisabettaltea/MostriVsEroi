using MostriVsEroi.DBRepository;
using MostriVsEroi.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace MostriVsEroi.Services
{
    public static class ArmaServices
    {
        static DBRepositoryArmi armaRepository = new DBRepositoryArmi();

        public static List<Arma> GetArmi(Utente utente, string categoria)
        {
            return armaRepository.FetchArmi(categoria);
        }

        public static int RecuperaIdArmi(Arma arma)
        {
            return armaRepository.RecuperaIdArma(arma);
        }
    }



}
