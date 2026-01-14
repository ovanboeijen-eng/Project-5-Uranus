
using MySql.Data.MySqlClient;

namespace Project__5.Pages.DataBase
{
    public class DataBase
    {
        private MySqlConnection conn = new MySqlConnection("Server=192.168.42.3;Database=CampKeeper;User Id=CampKeeper;Password=@@rdaPPel23");
        public MySqlConnection GetConnection()
        {
            return conn; 
        }


        public void GetHuurder()
        {
            conn.Open();
            string query = "SELECT * FROM huurders";
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string naam = reader["email"].ToString();
                        string email = reader["wachtwoord"].ToString();
                    }
                    conn.Close();

                }
            }
        }

        public bool GetUserByEmailAndPassword(string email, string password)
        {
            conn.Open();
            string query = "SELECT * FROM gebruikers WHERE email = @Email AND wachtwoord = @Wachtwoord";

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Wachtwoord", password);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {

                    bool userExists = reader.HasRows;

                    conn.Close();
                    return userExists;
                }
            }
        }
    }
}
