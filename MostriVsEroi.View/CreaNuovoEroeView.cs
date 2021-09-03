using MostriVsEroi.BusinessLayer;
using MostriVsEroi.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MostriVsEroi.View
{
    public static class CreaNuovoEroeView
    {
        internal static void CreaNuovoEroe(Utente utente, int idUtente)
        {
            string nome;
            do
            {
                Console.Write("\nInserisci il nome dell'eroe: ");
                nome = Console.ReadLine();
                if(EroeServices.VerificaNome(nome))
                {
                    Console.WriteLine("\nEsiste già un eroe con questo nome");
                }

            } while (EroeServices.VerificaNome(nome) || nome==null);

            Console.Write("\nInserisci la categoria: ");
            string categoria = SceltaCategoria(utente);
           
            if (categoria != null)
            {
                int idCategoria = CategoriaServices.RecuperaIdCategoria(categoria);    
                Console.Write("Inserisci l'arma: ");
                Arma arma = SceltaArma(utente,categoria);

                if (arma != null)
                {
                    int idArma = ArmaServices.RecuperaIdArmi(arma);
                    Eroe e = EroeSchermataServices.GetEroe(nome, categoria, 1, arma.Nome, arma.PuntiDanno);
                    int idLivello = LivelloVitaService.RecuperaIdLivelloVita(e);
                    EroeServices.AddEroe(utente, idUtente, e, idCategoria, idArma, idLivello);
                    Console.WriteLine("Eroe inserito con successo");
                }
                else
                {
                    Console.WriteLine("Inserisci una nuova arma!");
                }
            }
            else
            {
                Console.WriteLine("Inserisci una categoria!");
            }
        }

        public static string SceltaCategoria(Utente utente)
        {
            //Console.WriteLine("\n\nScegli una delle seguenti categorie: ");
            List<string> categorie = CategoriaServices.GetCategoriaEroi(utente);
            
            int scelta = 0;
            if (categorie.Count > 0)
            {
                
                do
                {
                    int count = 1;
                    foreach (var item in categorie)
                    {
                        Console.WriteLine($"\nPremi {count} per {item}");

                        Console.WriteLine("-------------------------------");
                        count++;
                    }
                } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1 || scelta > categorie.Count);

                return categorie[--scelta];
            }
            else
            {
                Console.WriteLine("Non sono presenti categorie");
                return null;
            }
        }

        public static Arma SceltaArma(Utente utente, string categoria)
        {
            //Console.WriteLine("\n\nScegli una delle seguenti armi: ");
            List<Arma> armi = ArmaServices.GetArmi(utente,categoria);
            
            int scelta = 0;
            if (armi.Count > 0)
            {
                do
                {
                    int count = 1;
                    foreach (var item in armi)
                    {
                        Console.WriteLine($"\nPremi {count++} per {item.Nome} con Punti Danno pari a {item.PuntiDanno}");

                        Console.WriteLine("-------------------------------------------------------------------------");
                    }

                } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1 || scelta > armi.Count);

                return armi[--scelta];
            }
            else
            {
                Console.WriteLine("Non sono presenti armi");
                return null;
            }
        }



    }
}
