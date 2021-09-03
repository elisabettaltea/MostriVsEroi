using MostriVsEroi.DBRepository;
using MostriVsEroi.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace MostriVsEroi.Services
{
    public static class MostroServices
    {
        static DBRepositoryMostri mostroRepository = new DBRepositoryMostri();

        public static List<Mostro> GetMostri(Utente utente)
        {
            return mostroRepository.FetchMostri();
        }

        public static bool VerificaNome(string nome)
        {
            return mostroRepository.VerificaNome(nome);
        }

        public static void AddMostro(Mostro m, int idCategoria, int idArma, int idLivello)
        {
            mostroRepository.AddMostro(m, idCategoria, idArma, idLivello);
        }
    }

    public class MostroSchermataServices
    {
        public static Mostro GetMostro(string nome, string categoria, int livello, string nomeArma, int puntiDanno, int puntiVita)
        {
            return new Mostro(nome, categoria, new Arma(nomeArma, puntiDanno), livello, puntiVita);
        }
    }



}
