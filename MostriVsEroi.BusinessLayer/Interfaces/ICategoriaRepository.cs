using System;
using System.Collections.Generic;
using System.Text;

namespace MostriVsEroi.BusinessLayer
{
    public interface ICategoriaRepository
    {
        public List<string> FetchCategorieEroi();
        public List<string> FetchCategorieMostri();
        public int RecuperaIdCategoria(string categoria);
    }



}
