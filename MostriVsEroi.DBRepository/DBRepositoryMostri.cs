using MostriVsEroi.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MostriVsEroi.DBRepository
{
    public class DBRepositoryMostri : IMostroRepository
    {
        const string connectionString = @"Data Source= (localdb)\mssqllocaldb; Initial Catalog = MostriVsEroi; Integrated Security=true;";

        public List<Mostro> FetchMostri()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;

                    command.CommandText = "select * from dbo.MostriConCaratteristiche";
                    
                    SqlDataReader reader = command.ExecuteReader();
                    List<Mostro> mostri = new List<Mostro>();

                    while (reader.Read())
                    {
                        var nome = (string)reader["Nome"];
                        var categoria = (string)reader["Categoria"];
                        var nomeArma = (string)reader["NomeArma"];
                        var puntiDanno = (int)reader["PuntiDanno"];
                        var livello = (int)reader["Livello"];
                        var puntiVita = (int)reader["PuntiVita"];
                        

                        Mostro m = new Mostro(nome, categoria, new Arma(nomeArma, puntiDanno),livello, puntiVita);

                        mostri.Add(m);
                    }

                    return mostri;

                    connection.Close();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }

        public void AddMostro(Mostro m, int idCategoria, int idArma, int idLivello)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;

                    command.CommandText = "insert into dbo.Mostri values (@Nome,@IdArma,@IdCategoria,@IdLivelloVita)";
                    command.Parameters.AddWithValue("@Nome", m.Nome);
                    command.Parameters.AddWithValue("@IdArma", idArma);
                    command.Parameters.AddWithValue("@IdCategoria", idCategoria);
                    command.Parameters.AddWithValue("@IdLivelloVita", idLivello);
                    

                    command.ExecuteNonQuery();

                    connection.Close();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        public bool VerificaNome(string nome)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();                                          
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "select * from dbo.Mostri where @Nome=Nome";
                    command.Parameters.AddWithValue("@Nome", nome);

                    SqlDataReader reader = command.ExecuteReader();

                    return reader.HasRows;

                    connection.Close();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }



    }
}
