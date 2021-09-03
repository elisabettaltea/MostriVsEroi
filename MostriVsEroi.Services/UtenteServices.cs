using MostriVsEroi.DBRepository;
using MostriVsEroi.BusinessLayer;
using System;
using System.Collections.Generic;

namespace MostriVsEroi.Services
{
    public static class UtenteServices
    {
        static DBRepositoryUtenti utenteRepository = new DBRepositoryUtenti();
        public static Utente VerifyAuthentication(Utente utente)
        {
            return utenteRepository.GetUser(utente);
        }

        public static List<Utente> FetchUtenti()
        {
            return utenteRepository.FetchUtenti();
        }

        public static void AddUtente(Utente utente)
        {
            utenteRepository.AddUtente(utente);
        }

        public static int RecuperaIdUtente(Utente u)
        {
            return utenteRepository.RecuperaIdUtente(u.Username);
        }

        public static void UpdateUtente(Utente utente, int idUtente)
        {
            utenteRepository.UpdateUtente(utente, idUtente);
        }
    }

    public static class UtenteSchermataServices
    {
        public static Utente GetUtente(string username, string password)
        {
            return new Utente(username, password);
        }
    }



}
