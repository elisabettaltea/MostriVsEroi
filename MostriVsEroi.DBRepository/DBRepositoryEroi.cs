using MostriVsEroi.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MostriVsEroi.DBRepository
{
    public class DBRepositoryEroi : IEroeRepository
    {
        const string connectionString = @"Data Source= (localdb)\mssqllocaldb; Initial Catalog = MostriVsEroi; Integrated Security=true;";

        public void AddEroi(Utente u, int idUtente, Eroe e, int idCategoria, int idArma, int idLivello)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;

                    command.CommandText = "insert into dbo.Eroi values (@Nome,@IdArma,@IdCategoria,@IdLivelloVita,@IdUtente,@PunteggioAccumulato)";
                    command.Parameters.AddWithValue("@Nome", e.Nome);
                    command.Parameters.AddWithValue("@IdArma", idArma);
                    command.Parameters.AddWithValue("@IdCategoria", idCategoria);
                    command.Parameters.AddWithValue("@IdLivelloVita", idLivello);
                    command.Parameters.AddWithValue("@IdUtente", idUtente);
                    command.Parameters.AddWithValue("@PunteggioAccumulato", 0);

                    command.ExecuteNonQuery();

                    connection.Close();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void UpdatePunteggio(Eroe e, int idEroe, int idLivello)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();                                         
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "update dbo.Eroi set PunteggioAccumulato=@PunteggioAccumulato, IdLivelloVita=@IdLivelloVita where IdEroe=@IdEroe";

                    if (e.PuntiAccumulati < 0)
                        command.Parameters.AddWithValue("@PunteggioAccumulato", 0);
                    else
                        command.Parameters.AddWithValue("@PunteggioAccumulato", e.PuntiAccumulati);

                    command.Parameters.AddWithValue("@IdLivelloVita", idLivello);
                    command.Parameters.AddWithValue("@IdEroe", idEroe);
                    SqlDataReader reader = command.ExecuteReader();
                 
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
                    command.CommandText = "select * from dbo.Eroi where @Nome=Nome";
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

        public List<Eroe> FetchEroi(Utente utente, int idUtente)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;

                    command.CommandText = "select * from dbo.UtenteConEroi where IdUtente=@IdUtente";
                    command.Parameters.AddWithValue("@IdUtente", idUtente);
                    SqlDataReader reader = command.ExecuteReader();
                    List<Eroe> eroi = new List<Eroe>();
                    while (reader.Read())
                    {
                        var nome = (string)reader["NomeEroe"];
                        var categoria = (string)reader["Categoria"];
                        var nomeArma = (string)reader["NomeArma"];
                        var puntiDanno = (int)reader["PuntiDanno"];
                        var livello = (int)reader["Livello"];
                        var puntiVita = (int)reader["PuntiVita"];
                        var puntiAccumulati = (int)reader["PunteggioAccumulato"];

                        Eroe e = new Eroe(nome, categoria, livello, new Arma(nomeArma, puntiDanno), puntiVita, puntiAccumulati);

                        eroi.Add(e);
                    }
                    return eroi;
                    connection.Close();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }

        public void RemoveEroe(Eroe e, Utente u, int idEroe)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();                                          
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "delete from dbo.Eroi where @IdEroe=IdEroe";
                    command.Parameters.AddWithValue("@IdEroe", idEroe);
                    command.ExecuteNonQuery();
                    
                    connection.Close();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);                   
                }
            }
        }

        public int RecuperaIdEroe(Utente u, Eroe e, int idUtente)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();                                          
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "select IdEroe from dbo.Eroi where @Nome=Nome and IdUtente=@IdUtente";
                    command.Parameters.AddWithValue("@Nome", e.Nome);
                    command.Parameters.AddWithValue("@IdUtente", idUtente);
                    int id = (int)command.ExecuteScalar();
                    return id;
                    connection.Close();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }

        public Dictionary<Eroe, string> ClassificaGlobale()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Dictionary<Eroe, string> eroi = new Dictionary<Eroe, string>();
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;

                    command.CommandText = "select * from dbo.UtenteConEroiClassifica";

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var user = (string)reader["Username"];
                        var nome = (string)reader["NomeEroe"];
                        var categoria = (string)reader["Categoria"];
                        var livello = (int)reader["Livello"];
                        var puntiVita = (int)reader["PuntiVita"];
                        var puntiAccumulati = (int)reader["PunteggioAccumulato"];

                        Eroe e = new Eroe(nome, categoria, livello, puntiVita, puntiAccumulati);

                        eroi.Add(e, user);
                    }
                    return eroi;
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
