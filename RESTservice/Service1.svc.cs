using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RESTservice
{
    public class Service1 : IService1
    {
        private const string ConnectionString = "Server=tcp:1server1.database.windows.net,1433;Initial Catalog=sqldatabase;Persist Security Info=False;User ID=Rednc6;Password=Dxmpizon21;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public IList<Character> GetCharacters()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand getAllElements = new SqlCommand("SELECT * FROM [dbo].[Characters]", connection);
            SqlDataReader reader = getAllElements.ExecuteReader();

            List<Character> tmpCharacterListe = new List<Character>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var tmpCharacter = new Character
                    {
                        ID = reader.GetInt32(0),
                        Name = reader.IsDBNull(1) ? "Unknown" : reader.GetString(1),
                        Natur = reader.IsDBNull(2) ? "Unknown" : reader.GetString(2),
                        Tradition = reader.IsDBNull(3) ? "Unknown" : reader.GetString(3),
                        Player = reader.IsDBNull(4) ? "Unknown" : reader.GetString(4),
                        Essence = reader.IsDBNull(5) ? "Unknown" : reader.GetString(5),
                        Concept = reader.IsDBNull(6) ? "Unknown" : reader.GetString(6),
                        Chronicle = reader.IsDBNull(7) ? "Unknown" : reader.GetString(7),
                        Demeanor = reader.IsDBNull(8) ? "Unknown" : reader.GetString(8),
                        Cabal = reader.IsDBNull(9) ? "Unknown" : reader.GetString(9),
                        Strenght = reader.GetByte(10),
                        Dexterity = reader.GetByte(11),
                        Stamina = reader.GetByte(12)
                    };


                    tmpCharacterListe.Add(tmpCharacter);
                }
            }
            connection.Close();
            return tmpCharacterListe;
        }
        
        public void PostCharacter(Character obj)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlCommand insertCmd = new SqlCommand("insert into [dbo].[Characters](Name, Natur, Tradition, Player, Essence, Concept, Chronicle, Demeanor, Cabal, " +
                "Strenght, Dexterity, Stamina) values (@Name, @Natur, @Tradition, @Player, @Essence, @Concept, @Chronicle, @Demeanor, @Cabal, @Strenght, @Dexterity, @Stamina)", connection);
            insertCmd.Parameters.AddWithValue("@Name", obj.Name);
            insertCmd.Parameters.AddWithValue("@Natur", obj.Natur);
            insertCmd.Parameters.AddWithValue("@Tradition", obj.Tradition);
            insertCmd.Parameters.AddWithValue("@Player", obj.Player);
            insertCmd.Parameters.AddWithValue("@Essence", obj.Essence);
            insertCmd.Parameters.AddWithValue("@Concept", obj.Concept);
            insertCmd.Parameters.AddWithValue("@Chronicle", obj.Chronicle);
            insertCmd.Parameters.AddWithValue("@Demeanor", obj.Demeanor);
            insertCmd.Parameters.AddWithValue("@Cabal", obj.Cabal);

            insertCmd.Parameters.AddWithValue("@Strenght", obj.Strenght);
            insertCmd.Parameters.AddWithValue("@Dexterity", obj.Dexterity);
            insertCmd.Parameters.AddWithValue("@Stamina", obj.Stamina);

            if (insertCmd.ExecuteNonQuery() != 0) { 

                connection.Close();
            }

            connection.Close();
        }

        public IList<Data> GetData()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand getAllElements = new SqlCommand("SELECT * FROM [dbo].[Data]", connection);
            SqlDataReader reader = getAllElements.ExecuteReader();

            List<Data> tmpDataListe = new List<Data>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var tmpData = new Data
                    {
                        ID = reader.GetInt32(0),
                        Action = reader.IsDBNull(1) ? "Unknown" : reader.GetString(1),
                        Type = reader.IsDBNull(2) ? "Unknown" : reader.GetString(2),
                        Value = reader.IsDBNull(3) ? 0 : reader.GetDouble(3),
                        Count = reader.IsDBNull(4) ? 1 : reader.GetInt32(4)
                    };


                    tmpDataListe.Add(tmpData);
                }
            }
            connection.Close();
            return tmpDataListe;

        }

        // Data functions
        public void PostData(Data obj)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlCommand insertCmd = new SqlCommand("insert into [dbo].[Data](Action, Type, Value, Count) " +
                                                  "values (@Action, @Type, @Value, @Count)", connection);
            insertCmd.Parameters.AddWithValue("@Action", obj.Action);
            insertCmd.Parameters.AddWithValue("@Type", obj.Type);
            insertCmd.Parameters.AddWithValue("@Value", obj.Value);
            insertCmd.Parameters.AddWithValue("@Count", obj.Count);

            if (insertCmd.ExecuteNonQuery() != 0)
            {
                connection.Close();
            }

            connection.Close();
        }

    }
}
