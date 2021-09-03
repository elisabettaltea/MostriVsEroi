using MostriVsEroi.BusinessLayer;
using MostriVsEroi.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MostriVsEroi.View
{
    public class EliminaEroeView
    {

        internal static void EliminaEroe(Utente utente, int idUtente)
        {
            Eroe e = ScegliEroeDaEliminare(utente, idUtente);

            if (e != null)
            {
                int idEroe = EroeServices.RecuperaIdEroe(e, utente, idUtente);
                if (e != null)
                {
                    EroeServices.RemoveEroe(utente, e, idEroe);

                    Console.WriteLine("Eroe eliminato con successo");
                }
            }           
        }

        //internal static void EliminaEroe(Utente utente, int idUtente)
        //{
        //    Eroe e = ScegliEroeDaEliminare(utente,idUtente);
        //    int idEroe = EroeServices.RecuperaIdEroe(e,utente,idUtente);
        //    if (e != null)
        //    {
        //        EroeServices.RemoveEroe(utente, e, idEroe);

        //        Console.WriteLine("Eroe eliminato con successo");

        //        utente = ControlloUtenteAdmin(utente, idUtente);
        //    }
        //}

        //private static Utente ControlloUtenteAdmin(Utente utente, int idUtente)
        //{
        //    List<Eroe> eroi = EroeServices.GetEroi(utente, idUtente);

        //    bool IsStillAdmin = false;
        //    if (utente.IsAdmin)
        //    {
        //        foreach (var eroe in eroi)
        //        {
        //            if (eroe.Livello == 3)
        //            {
        //                IsStillAdmin = true;
        //            }
        //        }

        //        if (!IsStillAdmin)
        //            utente.IsAdmin = false;
        //    }

        //    return utente;
        //}

        public static Eroe ScegliEroeDaEliminare(Utente utente, int idUtente)
        {
            List<Eroe> eroi = EroeServices.GetEroi(utente, idUtente);

            int scelta;
            if (eroi.Count > 0)
            {
                Console.WriteLine("Quale eroe vuoi eliminare?");

                do
                {
                    int count = 1;
                    foreach (var eroe in eroi)
                    {
                        Console.WriteLine($"\nPremi {count} per eliminare l'eroe {eroe.Nome}, di tipo {eroe.Categoria} di livello {eroe.Livello} " +
                            $"e punti vita {eroe.PuntiVita} con arma {eroe.Arma.Nome} che ha {eroe.Arma.PuntiDanno} punti danno");

                        Console.WriteLine("\n------------------------------------------------------------");
                        count++;
                    }
                } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1 || scelta > eroi.Count);

                return eroi[--scelta];
            }
            else
            {
                Console.WriteLine("Non possiedi eroi");
                return null;
            }
        }



    }
}
