using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adonet_db_videogame
{
    public class VideogameManager
    {
        // Stringa di connessione
        private static string connectionString = "Data Source=localhost;Initial Catalog=videogames; Integrated Security=True";

        // Metodo per inserire un nuovo videogioco
        public static bool InsertVideogame(Videogame videogameAdd)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO videogames (name, overview, release_date, software_house_id) VALUES (@Name, @Overview, @ReleaseDate, @SoftwareHouseId);";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.Add(new SqlParameter("@Name", videogameAdd.Name));
                    cmd.Parameters.Add(new SqlParameter("@Overview", videogameAdd.Overview));
                    cmd.Parameters.Add(new SqlParameter("@ReleaseDate", videogameAdd.ReleaseDate));
                    cmd.Parameters.Add(new SqlParameter("@SoftwareHouseId", videogameAdd.SoftwareHouseId));

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return false;
            }
        }

        // Metodo per ricercare un videogioco per id

        public static Videogame SearchById(long id)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT id, name, overview, release_date, software_house_id FROM videogames WHERE id = @Id";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.Add(new SqlParameter("@Id", id));

                    using (SqlDataReader data = cmd.ExecuteReader())

                    while (data.Read())
                    {
                            Videogame videogame = new Videogame(data.GetInt64(0), data.GetString(1), data.GetString(2), data.GetDateTime(3), data.GetInt64(4));
                            return videogame;
                    }

                    
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    
                }
                return null;
            }
        }
    }
}
