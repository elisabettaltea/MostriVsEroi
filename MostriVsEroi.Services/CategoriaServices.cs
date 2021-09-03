using MostriVsEroi.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Text;
using MostriVsEroi.DBRepository;

namespace MostriVsEroi.Services
{
    public static class CategoriaServices
    {
        static DBRepositoryCategorie categoriaRepository = new DBRepositoryCategorie();

        public static List<string> GetCategoriaEroi(Utente utente)
        {
            return categoriaRepository.FetchCategorieEroi();
        }

        public static int RecuperaIdCategoria(string categoria)
        {
            return categoriaRepository.RecuperaIdCategoria(categoria);
        }

        public static List<string> GetCategoriaMostri()
        {
            return categoriaRepository.FetchCategorieMostri();
        }
    }



}