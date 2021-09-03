using MostriVsEroi.DBRepository;
using MostriVsEroi.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace MostriVsEroi.Services
{
    public class LivelloVitaService
    {
        static DBRepositoryLivelliVita livelloVitaRepository = new DBRepositoryLivelliVita();

        public static int RecuperaIdLivelloVita(Eroe e)
        {
            return livelloVitaRepository.RecuperaIdLivelliVita(e);
        }

        public static int RecuperaIdLivelloVita(Mostro m)
        {
            return livelloVitaRepository.RecuperaIdLivelliVita(m);
        }

        public static int RecuperaLivelloVita(int puntiVita)
        {
            return livelloVitaRepository.RecuperaLivelliVita(puntiVita);
        }

        public static Dictionary<int, int> GetLivelli()
        {
            return livelloVitaRepository.GetLivelli();
        }
    }



}
