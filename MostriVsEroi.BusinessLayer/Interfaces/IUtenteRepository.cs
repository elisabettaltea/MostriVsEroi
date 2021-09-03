using System;
using System.Collections.Generic;
using System.Text;

namespace MostriVsEroi.BusinessLayer
{
    public interface IUtenteRepository
    {
        public Utente GetUser(Utente utente);
        public List<Utente> FetchUtenti();
        public void AddUtente(Utente utente);
        public void UpdateUtente(Utente utente, int idUtente);
        public int RecuperaIdUtente(string user);
    }



}
