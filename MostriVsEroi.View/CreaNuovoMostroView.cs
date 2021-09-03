using MostriVsEroi.BusinessLayer;
using MostriVsEroi.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MostriVsEroi.View
{
    public static class CreaNuovoMostroView
    {
        internal static void CreaMostro(Utente utente, int idUtente)
        {
            string nome;
            do
            {
                Console.Write("Inserisci il nome del mostro: ");
                nome = Console.ReadLine();
                if (MostroServices.VerificaNome(nome))
                {
                    Console.WriteLine("\nEsiste già un mostro con questo nome");
                }
            } while (MostroServices.VerificaNome(nome) || nome == null);

            //Console.Write("\nInserisci la categoria: ");
            string categoria = SceltaCategoria();
            if (categoria != null)
            {
                int idCategoria = CategoriaServices.RecuperaIdCategoria(categoria);         
                //Console.Write("Inserisci l'arma: ");
                Arma arma = SceltaArma(utente, categoria);
                if (arma != null)
                {
                    int idArma = ArmaServices.RecuperaIdArmi(arma);
                    //Console.Write("\nInserisci il livello: ");
                    int puntiVita = SceltaLivello();
                    int livello = LivelloVitaService.RecuperaLivelloVita(puntiVita);
                    Mostro m = MostroSchermataServices.GetMostro(nome, categoria, livello, arma.Nome, arma.PuntiDanno,puntiVita);
                    int idLivello = LivelloVitaService.RecuperaIdLivelloVita(m);
                    MostroServices.AddMostro(m, idCategoria, idArma, idLivello);
                    Console.WriteLine("Mostro inserito con successo");
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

        private static int SceltaLivello()
        {
            Console.WriteLine("\n\nScegli il livello: ");
            Dictionary<int, int> livelli = LivelloVitaService.GetLivelli();
            
            int scelta = 0;
            if (livelli.Count > 0)
            {
                do
                {
                    int count = 1;
                    foreach (var livello in livelli)
                    {
                        Console.WriteLine($"\nPremi {count++} per Livello {livello.Key} con Punti Vita pari a {livello.Value}");

                        Console.WriteLine("-------------------------------------------------------------------------");
                    }

                } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1 || scelta > livelli.Count);
                
                return livelli[scelta];
            }
            else
            {
                Console.WriteLine("Non sono presenti armi");
                return 0;
            }
        
            
        }

        private static Arma SceltaArma(Utente u,string categoria)
        {
            Console.WriteLine("\n\nScegli l'arma: ");
            List<Arma> armi = ArmaServices.GetArmi(u,categoria);

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

        private static string SceltaCategoria()
        {
            Console.WriteLine("\n\nScegli la categoria: ");
            List<string> categorie = CategoriaServices.GetCategoriaMostri();

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



    }
}
