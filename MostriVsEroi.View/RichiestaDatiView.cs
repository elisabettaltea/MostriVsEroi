using MostriVsEroi.BusinessLayer;
using MostriVsEroi.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MostriVsEroi.View
{
    static class RichiestaDatiView
    {
        internal static Utente InserisciUsernamePassword()
        {
            string username;
            do
            {
                Console.Write("\nInserisci il tuo username: ");
                username = Console.ReadLine();
                if(username == null || username == " " || username == "")
                {
                    Console.WriteLine("\nUsername non valido");
                }

            } while (username == null || username == " " || username == "");

            string password;
            do
            {
                Console.Write("Inserisci la tua password: ");
                password = Console.ReadLine();
                if(password == null || password == " " || password == "")
                {
                    Console.WriteLine("\nPassword non valida");
                }

            } while (password == null || password == " " || password == "");
                

            return UtenteSchermataServices.GetUtente(username, password);
        }

       

    }
}
