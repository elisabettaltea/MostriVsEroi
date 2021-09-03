using System;
using System.Collections.Generic;
using System.Text;

namespace MostriVsEroi.BusinessLayer
{
    public interface IEroeRepository
    {
        public List<Eroe> FetchEroi(Utente utente, int idUtente);
        public void AddEroi(Utente u, int idUtente, Eroe e, int idCategoria, int idArma, int idLivello);
        public void RemoveEroe(Eroe e, Utente u, int idEroe);
        public void UpdatePunteggio(Eroe e, int idEroe, int idLivello);
        public bool VerificaNome(string nome);
        public int RecuperaIdEroe(Utente u, Eroe e, int idUtente);
        public Dictionary<Eroe, string> ClassificaGlobale();
    }



}

