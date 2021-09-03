using MostriVsEroi.BusinessLayer;
using System;

namespace MostriVsEroi.View
{
    public static class Menu
    {
        public static void MainMenu()
        {
            bool continua = true;

            do
            {
                Console.WriteLine("--- Mostri vs Eroi ---");
                Console.WriteLine();
                Console.WriteLine("Premi 1 per Accedere");
                Console.WriteLine("Premi 2 per Registrarti");
                Console.WriteLine("Premi 0 per Uscire");

                string scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        AccediView.Accedi();
                        break;
                    case "2":
                        RegistratiView.Registrati();
                        break;
                    case "0":
                        Console.WriteLine("Alla prossima partita");
                        continua = false;
                        break;
                    default:
                        Console.WriteLine("Scelta non valida, riprova:");
                        break;
                }
            } while (continua);
        }

        public static void MenuNonAdmin(Utente utente, int idUtente)
        {
            bool continua = true;

            do
            {
                Console.WriteLine($"\nCosa vuoi fare {utente.Username}?");
                Console.WriteLine();
                Console.WriteLine("Premi 1 per Giocare");
                Console.WriteLine("Premi 2 per Creare un nuovo eroe");
                Console.WriteLine("Premi 3 per Eliminare un eroe");
                Console.WriteLine("Premi 0 per Uscire");

                string scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        GiocaView.Gioca(utente,idUtente);
                        break;
                    case "2":
                        CreaNuovoEroeView.CreaNuovoEroe(utente,idUtente);
                        break;
                    case "3":
                        EliminaEroeView.EliminaEroe(utente,idUtente);
                        break;
                    case "0":
                        continua = false;
                        break;
                    default:
                        Console.WriteLine("Scelta non valida, riprova:");
                        break;
                }
            } while (continua);
        }

        public static void MenuAdmin(Utente utente, int idUtente)
        {
            bool continua = true;

            do
            {
                Console.WriteLine($"\nCosa vuoi fare {utente.Username}?");
                Console.WriteLine();
                Console.WriteLine("Premi 1 per Giocare");
                Console.WriteLine("Premi 2 per Creare un nuovo eroe");
                Console.WriteLine("Premi 3 per Eliminare un eroe");
                Console.WriteLine("Premi 4 per Creare un mostro");
                Console.WriteLine("Premi 5 per Visualizzare la classifica globale");
                Console.WriteLine("Premi 0 per Uscire");

                string scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        GiocaView.Gioca(utente, idUtente);
                        break;
                    case "2":
                        CreaNuovoEroeView.CreaNuovoEroe(utente, idUtente);
                        break;
                    case "3":
                        EliminaEroeView.EliminaEroe(utente, idUtente);
                        break;
                    case "4":
                        CreaNuovoMostroView.CreaMostro(utente, idUtente);
                        break;
                    case "5":
                        ClassificaGlobaleView.Classifica();
                        break;
                    case "0":
                        continua = false;
                        break;
                    default:
                        Console.WriteLine("Scelta non valida, riprova:");
                        break;
                }
            } while (continua);
        }



    }
}
