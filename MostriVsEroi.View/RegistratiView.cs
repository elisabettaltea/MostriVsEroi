using MostriVsEroi.BusinessLayer;
using MostriVsEroi.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MostriVsEroi.View
{
    class RegistratiView
    {
        internal static void Registrati()
        {
            Console.WriteLine("\nBenvenuto!");
            Utente utente = RichiestaDatiView.InserisciUsernamePassword();
            string user = utente.Username;
            List<Utente> utenti = UtenteServices.FetchUtenti();

            bool esiste = false;
            foreach(var item in utenti)
            {
                if (item.Username == user)
                {
                    esiste = true;
                    break;
                }   
            }

            if (esiste)
            {
                Console.WriteLine("\nUsername già presente.....Riprova\n");
            }
            else
            {
                UtenteServices.AddUtente(utente);
                int idUtente=UtenteServices.RecuperaIdUtente(utente);
                Console.WriteLine("\nRegistrazione avvenuta con successo");

                Menu.MenuNonAdmin(utente,idUtente);
            }
        }



    }
}
