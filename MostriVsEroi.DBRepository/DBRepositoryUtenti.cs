using MostriVsEroi.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MostriVsEroi.DBRepository
{
    public class DBRepositoryUtenti : IUtenteRepository
    {
        const string connectionString = @"Data Source= (localdb)\mssqllocaldb; Initial Catalog = MostriVsEroi; Integrated Security=true;";

        public List<Utente> FetchUtenti()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;

                    command.CommandText = "select * from dbo.Utenti";
                    SqlDataReader reader = command.ExecuteReader();

                    List<Utente> utenti = new List<Utente>();

                    while (reader.Read())
                    {
                        var username = (string)reader["Username"];
                        var password = (string)reader["Password"];
                        var isAdmin = (bool)reader["IsAdmin"];

                        Utente u = new Utente(username, password);
                        utenti.Add(u);
                    }

                    return utenti;

                    connection.Close();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }

        public void UpdateUtente(Utente utente, int idUtente)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();                                         
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;

                    command.CommandText = "update dbo.Utenti set IsAdmin=@IsAdmin where IdUtente=@IdUtente";
                    command.Parameters.AddWithValue("@IsAdmin", utente.IsAdmin);
                    command.Parameters.AddWithValue("@IdUtente", idUtente);

                    SqlDataReader reader = command.ExecuteReader();

                    connection.Close();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public Utente GetUser(Utente utente)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "select *from dbo.Utenti where Username=@Username and Password=@Password";
                    command.Parameters.AddWithValue("@Username", utente.Username);
                    command.Parameters.AddWithValue("@Password", utente.Password);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        utente.IsAuthenticated = true;
                        while (reader.Read())
                        {
                            var isAdmin = (bool)reader["IsAdmin"];

                            utente.IsAdmin = isAdmin;
                        }
                    }
                    else
                    {
                        utente.IsAuthenticated = false;
                    }

                    return utente;

                    connection.Close();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }

        public void AddUtente(Utente utente)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;

                    command.CommandText = "insert into dbo.Utenti values (@Username, @Password, @IsAdmin)";
                    command.Parameters.AddWithValue("@Username", utente.Username);
                    command.Parameters.AddWithValue("@Password", utente.Password);
                    command.Parameters.AddWithValue("@IsAdmin", false);
                    command.ExecuteNonQuery();

                    connection.Close();
                }
                catch(SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }

        public int RecuperaIdUtente(string user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();                                          
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;

                    command.CommandText = "select IdUtente from dbo.Utenti where @Username=Username";
                    command.Parameters.AddWithValue("@Username", user);
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
