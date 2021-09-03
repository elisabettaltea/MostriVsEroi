using MostriVsEroi.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MostriVsEroi.DBRepository
{
    public class DBRepositoryArmi : IArmaRepository
    {
        const string connectionString = @"Data Source= (localdb)\mssqllocaldb; Initial Catalog = MostriVsEroi; Integrated Security=true;";
        public List<Arma> FetchArmi(string categoria)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "select NomeArma, PuntiDanno from dbo.ArmiConCategorieEroiEMostri where Categoria=@Categoria";
                    command.Parameters.AddWithValue("@Categoria", categoria);
                    SqlDataReader reader = command.ExecuteReader();
                    List<Arma> armi = new List<Arma>();
                    while (reader.Read())
                    {
                        var nome = (string)reader["NomeArma"];
                        var puntiDanno = (int)reader["PuntiDanno"];

                        Arma a = new Arma(nome, puntiDanno);
                        armi.Add(a);
                    }
                    return armi;
                    connection.Close();
                }
                catch(SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }               
            }
        }

        public int RecuperaIdArma(Arma arma)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();                                         
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "select IdArma from dbo.Armi where @Nome=Nome";
                    command.Parameters.AddWithValue("@Nome", arma.Nome);
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
