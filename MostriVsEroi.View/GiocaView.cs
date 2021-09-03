using MostriVsEroi.Services;
using MostriVsEroi.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace MostriVsEroi.View
{
    class GiocaView
    {
        public static void Gioca(Utente utente, int idUtente)
        {
            Eroe e = SceltaEroe(utente,idUtente);

            if (e != null)
            {
                Console.WriteLine("Eroe selezionato con successo");
                int idEroe = EroeServices.RecuperaIdEroe(e, utente, idUtente);          
                Mostro m = SceltaMostro(utente, e);
                Console.WriteLine($"\nIl mostro che dovrai sfidare è: {m.Nome} \nLivello: {m.Livello} " +
                    $"\nPunti vita: {m.PuntiVita} \nCategoria: {m.Categoria} \nArma: {m.Arma.Nome} con punti danno pari a {m.Arma.PuntiDanno}");
                int puntiVitaMostro = m.PuntiVita;
                int puntiVitaEroe = e.PuntiVita;
                Partita(utente, e, m, puntiVitaMostro, puntiVitaEroe, idUtente, idEroe);            
                
                string scelta;

                Console.WriteLine("\nVuoi giocare ancora? \nPremi Y per continuare a giocare");
                scelta = Console.ReadLine();

                if (scelta == "Y" || scelta == "y")
                {
                    Gioca(utente, idUtente);
                }
                //else
                //{
                //    utente = ControlloUtenteAdmin(utente, idUtente);
                //    if (!utente.IsAdmin)
                //    {
                //        Menu.MenuNonAdmin(utente, idUtente);
                //    }
                //    else
                //    {
                //        Menu.MenuAdmin(utente, idUtente);
                //    }
                //}
            }
            else
            {
                Console.WriteLine("Non hai eroi...creane uno nuovo!");
            }
        }

        public static Eroe SceltaEroe(Utente utente, int idUtente)
        {
            List<Eroe> eroi = EroeServices.GetEroi(utente, idUtente);

            int scelta;
            if (eroi.Count > 0)
            {
                Console.WriteLine("Con quale eroe vuoi giocare?");
                do
                {
                    int count = 1;
                    foreach (var eroe in eroi)
                    {
                        Console.WriteLine($"\nPremi {count} per scegliere l'eroe {eroe.Nome}, di tipo {eroe.Categoria} di livello {eroe.Livello} " +
                            $"e punti vita {eroe.PuntiVita} con arma {eroe.Arma.Nome} che ha {eroe.Arma.PuntiDanno} punti danno");

                        Console.WriteLine("\n--------------------------------------------------");
                        count++;
                    }
                } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1 || scelta > eroi.Count);

                return eroi[--scelta];
            }
            else
            {
                return null;
            }
        }

        private static Mostro SceltaMostro(Utente utente, Eroe eroe)
        {
            List<Mostro> mostri = MostroServices.GetMostri(utente);
            Random r = new Random();
            int scelta = r.Next(0, mostri.Count);

            if (mostri[scelta].Livello <= eroe.Livello)
            {
                return mostri[scelta];
            }
            else
            {
                return SceltaMostro(utente, eroe);
            }
        }

        public static void Partita(Utente utente, Eroe eroe, Mostro mostro, int puntiVitaMostro, int puntiVitaEroe, int idUtente, int idEroe)
        {
            int scelta;

            Console.WriteLine("\nPremi 1 per attaccare");
            Console.WriteLine("Premi 0 se vuoi fuggire");

            do
            {
                Console.Write("\nFai la tua scelta: ");

            } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta > 1 || scelta < 0);

            switch (scelta)
            {
                case 1:
                    Attacco(utente, eroe, mostro, puntiVitaMostro, puntiVitaEroe, idUtente, idEroe);
                    break;
                case 0:
                    Fuga(utente, eroe, mostro, puntiVitaMostro, puntiVitaEroe, idUtente, idEroe);
                    break;
                default:
                    Console.WriteLine("Scelta non valida");
                    break;
            }
        }

        private static void Attacco(Utente utente, Eroe eroe, Mostro mostro, int puntiVitaMostro, int puntiVitaEroe, int idUtente, int idEroe)
        {
            Console.WriteLine($"\n{eroe.Nome} Attacca {mostro.Nome}");

            int nuoviPuntiVitaMostro = puntiVitaMostro - eroe.Arma.PuntiDanno;
            if (nuoviPuntiVitaMostro <= 0)
            {
                Console.WriteLine("Hai vinto!!!");
                ControlliPartita(eroe, mostro, utente, idUtente, idEroe);
            }
            else
            {
                Console.WriteLine($"{mostro.Nome} dopo l'attacco ha ancora {nuoviPuntiVitaMostro} punti vita");
                Console.WriteLine($"\n{mostro.Nome} Attacca {eroe.Nome}");
                int nuoviPuntiVitaEroe = puntiVitaEroe - mostro.Arma.PuntiDanno;
                //Console.WriteLine($"{eroe.Nome} dopo l'attacco di {mostro.Nome} ha ancora {nuoviPuntiVitaEroe} punti vita");

                if (nuoviPuntiVitaEroe <= 0)
                {
                    Console.WriteLine($"{eroe.Nome} dopo l'attacco di {mostro.Nome} ha 0 punti vita");
                    Console.WriteLine("\nHai perso!!");
                }
                else
                {
                    Console.WriteLine($"{eroe.Nome} dopo l'attacco di {mostro.Nome} ha ancora {nuoviPuntiVitaEroe} punti vita");
                    puntiVitaMostro = nuoviPuntiVitaMostro;
                    puntiVitaEroe = nuoviPuntiVitaEroe;
                    Partita(utente, eroe, mostro, puntiVitaMostro, puntiVitaEroe, idUtente, idEroe);
                }
            }
        }

        private static void ControlliPartita(Eroe e, Mostro m, Utente utente, int idUtente, int idEroe)
        {
            e = CalcoloPunteggio(m.Livello, e);
            Console.WriteLine($"{e.Nome} ha accumulato {e.PuntiAccumulati} punti");
            int idLivelloEroe = LivelloVitaService.RecuperaIdLivelloVita(e);
            EroeServices.UpdatePunteggio(e, idEroe, idLivelloEroe);

            ControlloPunteggio(utente, idUtente);

            utente = ControlloUtenteAdmin(utente, idUtente);
            UtenteServices.UpdateUtente(utente, idUtente);
        }

        private static Eroe CalcoloPunteggio(int livelloMostro, Eroe e)
        {
            e.PuntiAccumulati += livelloMostro * 10;

            return e;
        }

        private static void ControlloPunteggio(Utente utente, int idUtente)
        {
            List<Eroe> eroi = EroeServices.GetEroi(utente, idUtente);

            foreach (var eroe in eroi)
            {
                if (eroe.PuntiAccumulati > 29 && eroe.Livello == 1)
                {
                    AumentoLivello(eroe, utente, idUtente);
                }
                if (eroe.PuntiAccumulati > 59 && eroe.Livello == 2)
                {
                    AumentoLivello(eroe, utente, idUtente);
                }
                if (eroe.PuntiAccumulati > 89 && eroe.Livello == 3)
                {
                    AumentoLivello(eroe, utente, idUtente);
                }
                if (eroe.PuntiAccumulati > 119 & eroe.Livello == 4)
                {
                    AumentoLivello(eroe, utente, idUtente);
                }
            }
        }

        private static void AumentoLivello(Eroe e, Utente utente, int idUtente)
        {
            e.Livello += 1;
            int idEroe = EroeServices.RecuperaIdEroe(e, utente, idUtente);
            int idLivello = LivelloVitaService.RecuperaIdLivelloVita(e);
            e.PuntiAccumulati = 0;
            EroeServices.UpdatePunteggio(e, idEroe, idLivello);
        }

        private static Utente ControlloUtenteAdmin(Utente utente, int idUtente)
        {
            List<Eroe> eroi = EroeServices.GetEroi(utente, idUtente);

            if(!utente.IsAdmin)
            {
                foreach (var eroe in eroi)
                {
                    if (eroe.Livello == 3)
                    {
                        utente.IsAdmin = true;
                        Console.WriteLine("\nComplimenti, sei diventato admin! Esci e riaccedi per visualizzare il menu admin");
                        break;
                    }
                }
            }

            return utente;
        }

        //private static Utente ControlloUtenteAdmin(Utente utente, int idUtente)
        //{
        //    List<Eroe> eroi = EroeServices.GetEroi(utente, idUtente);

        //    foreach (var eroe in eroi)
        //    {
        //        if (eroe.Livello == 3)
        //        {
        //            utente.IsAdmin = true;
        //            Console.WriteLine("\nComplimenti, sei diventato admin!");
        //            break;
        //        }
        //    }

        //    return utente;
        //}

        private static void Fuga(Utente utente, Eroe eroe, Mostro mostro, int puntiVitaMostro, int puntiVitaEroe, int idUtente, int idEroe)
        {
            bool[] verificaFuga = { true, false };
            Random r = new Random();
            int selezione = r.Next(0, verificaFuga.Length);

            if (verificaFuga[selezione])
            {
                Console.WriteLine("\nSei riuscito a fuggire");
                eroe = CalcoloPunteggioFuga(mostro, eroe);
                Console.WriteLine($"I tuoi punti ora sono pari a {eroe.PuntiAccumulati}");
                int idLivelloEroe = LivelloVitaService.RecuperaIdLivelloVita(eroe);
                EroeServices.UpdatePunteggio(eroe, idEroe, idLivelloEroe);
            }
            else
            {
                Console.WriteLine($"\n{mostro.Nome} Attacca {eroe.Nome}");
                int nuoviPuntiVitaEroe = puntiVitaEroe - mostro.Arma.PuntiDanno;
                //Console.WriteLine($"{eroe.Nome} dopo l'attacco di {mostro.Nome} ha ancora {nuoviPuntiVitaEroe} punti vita");

                if (nuoviPuntiVitaEroe <= 0)
                {
                    Console.WriteLine($"{eroe.Nome} dopo l'attacco di {mostro.Nome} ha 0 punti vita");
                    Console.WriteLine("\nHai perso!!");
                }
                else
                {
                    Console.WriteLine($"{eroe.Nome} dopo l'attacco di {mostro.Nome} ha ancora {nuoviPuntiVitaEroe} punti vita");
                    puntiVitaEroe = nuoviPuntiVitaEroe;
                    Partita(utente, eroe, mostro, puntiVitaMostro, puntiVitaEroe, idUtente, idEroe);
                }
            }
        }

        private static Eroe CalcoloPunteggioFuga(Mostro m, Eroe e)
        {
            e.PuntiAccumulati -= m.Livello * 5;

            return e;
        }



    }
}

