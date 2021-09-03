using MostriVsEroi.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MostriVsEroi.DBRepository
{
    public class DBRepositoryCategorie : ICategoriaRepository
    {
        const string connectionString = @"Data Source= (localdb)\mssqllocaldb; Initial Catalog = MostriVsEroi; Integrated Security=true;";
        public List<string> FetchCategorieEroi()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "select Nome from dbo.Categorie where @Tipo=Tipo";
                    command.Parameters.AddWithValue("@Tipo", "Eroe");
                    SqlDataReader reader = command.ExecuteReader();
                    List<string> categorie = new List<string>();
                    while (reader.Read())
                    {
                        var nome = (string)reader["Nome"];

                        categorie.Add(nome);
                    }
                    return categorie;
                    connection.Close();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }            
        }

        public List<string> FetchCategorieMostri()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "select Nome from dbo.Categorie where @Tipo=Tipo";
                    command.Parameters.AddWithValue("@Tipo", "Mostro");
                    SqlDataReader reader = command.ExecuteReader();
                    List<string> categorie = new List<string>();
                    while (reader.Read())
                    {
                        var nome = (string)reader["Nome"];

                        categorie.Add(nome);
                    }
                    return categorie;
                    connection.Close();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }

        public int RecuperaIdCategoria(string categoria)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();                                         
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "select IdCategoria from dbo.Categorie where @Nome=Nome";
                    command.Parameters.AddWithValue("@Nome", categoria);
                    int id = (int)command.ExecuteScalar();
                    return id;
                    connection.Close();
                }
                catch(SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }                
            }
        }



    }
}
