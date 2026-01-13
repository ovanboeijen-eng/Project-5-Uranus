
using MySql.Data.MySqlClient;

namespace Project__5.Pages.DataBase
{
    public class DataBase
    {
       private MySqlConnection conn = new MySqlConnection("");


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
                        string naam = reader["naam"].ToString();
                        string email = reader["email"].ToString();
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
