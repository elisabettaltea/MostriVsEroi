using MostriVsEroi.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Text;
using MostriVsEroi.DBRepository;

namespace MostriVsEroi.Services
{
    public static class EroeServices
    {
        static DBRepositoryEroi eroeRepository = new DBRepositoryEroi();

        public static List<Eroe> GetEroi(Utente utente, int idUtente)
        {
            return eroeRepository.FetchEroi(utente, idUtente);
        }

        public static bool VerificaNome(string nome)
        {
            return eroeRepository.VerificaNome(nome);
        }

        public static void AddEroe(Utente utente, int idUtente, Eroe e, int idCategoria, int idArma, int idLivello)
        {
            eroeRepository.AddEroi(utente, idUtente, e, idCategoria, idArma, idLivello);
        }

        public static void RemoveEroe(Utente utente, Eroe e, int idEroe)
        {
            eroeRepository.RemoveEroe(e, utente, idEroe);
        }

        public static int RecuperaIdEroe(Eroe e, Utente u, int idUtente)
        {
            return eroeRepository.RecuperaIdEroe(u, e, idUtente);
        }

        public static void UpdatePunteggio(Eroe e, int idEroe, int idLivello)
        {
            eroeRepository.UpdatePunteggio(e, idEroe, idLivello);
        }

        public static Dictionary<Eroe, string> RecuperaClassifica()
        {
            return eroeRepository.ClassificaGlobale();
        }
    }

    public static class EroeSchermataServices
    {
        public static Eroe GetEroe(string nome, string categoria, int livello, string nomeArma, int puntiDanno)
        {
            return new Eroe(nome, categoria, 1, new Arma(nomeArma, puntiDanno), 20, 0);
        }
    }



}
