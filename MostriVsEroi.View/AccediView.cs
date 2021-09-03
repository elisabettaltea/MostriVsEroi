using MostriVsEroi.BusinessLayer;
using MostriVsEroi.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MostriVsEroi.View
{
    static class AccediView
    {
        public static void Accedi()
        {
            Utente utente = RichiestaDatiView.InserisciUsernamePassword();
            utente = UtenteServices.VerifyAuthentication(utente);
            if (utente.IsAuthenticated && utente.IsAdmin)
            {
                int idUtente = UtenteServices.RecuperaIdUtente(utente);
                Menu.MenuAdmin(utente, idUtente);
            }
            else if (utente.IsAuthenticated && !utente.IsAdmin)
            {
                int idUtente = UtenteServices.RecuperaIdUtente(utente);
                Menu.MenuNonAdmin(utente, idUtente);
            }
            else
            {
                Console.WriteLine("\nNon risulti registrato");
                Console.WriteLine();
            }
        }



    }
}
