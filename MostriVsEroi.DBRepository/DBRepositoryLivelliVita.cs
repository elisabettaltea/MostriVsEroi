using MostriVsEroi.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MostriVsEroi.DBRepository
{
    public class DBRepositoryLivelliVita
    {
        const string connectionString = @"Data Source= (localdb)\mssqllocaldb; Initial Catalog = MostriVsEroi; Integrated Security=true;";

        public int RecuperaIdLivelliVita(Eroe e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();                                         
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;

                command.CommandText = "select IdLivelloVita from dbo.LivelliVita where @Livello=Livello";
                command.Parameters.AddWithValue("@Livello", e.Livello);
                int id = (int)command.ExecuteScalar();

                return id;

                connection.Close();
            }
        }

        public int RecuperaIdLivelliVita(Mostro m)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();                                         
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;

                command.CommandText = "select IdLivelloVita from dbo.LivelliVita where @Livello=Livello";
                command.Parameters.AddWithValue("@Livello", m.Livello);
                int id = (int)command.ExecuteScalar();

                return id;

                connection.Close();
            }
        }

        public int RecuperaLivelliVita(int puntiVita)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();                                         
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;

                command.CommandText = "select Livello from dbo.LivelliVita where @PuntiVita=PuntiVita";
                command.Parameters.AddWithValue("@PuntiVita", puntiVita);
                int id = (int)command.ExecuteScalar();

                return id;

                connection.Close();
            }
        }

        public Dictionary<int, int> GetLivelli()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();                                         
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;

                    command.CommandText = "select * from dbo.LivelliVita";
                    SqlDataReader reader = command.ExecuteReader();

                    Dictionary<int, int> livelli = new Dictionary<int, int>();

                    while (reader.Read())
                    {
                        var livello = (int)reader["Livello"];
                        var puntiVita = (int)reader["PuntiVita"];

                        livelli.Add(livello, puntiVita);
                    }

                    return livelli;
                   
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
