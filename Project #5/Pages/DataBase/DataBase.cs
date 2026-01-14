
using MySql.Data.MySqlClient;

namespace Project__5.Pages.DataBase
{
    public class DataBase
// hello
    {
        private MySqlConnectionStringBuilder builder = new ();
        private MySqlConnection conn = new MySqlConnection("Server=192.168.42.3;Database=CampKeeper;User Id=Global;Password=@@rdaPPel23");
        public MySqlConnection GetConnection()
        {
            builder.Server = "192.168.42.3";
            builder.Database = "CampKeeper";
            builder.UserID = "Global";
            builder.Password = "@@rdaPPel23";
            conn = new MySqlConnection(builder.ConnectionString);

            return conn; 
        }


        public bool GetUserByEmailAndPassword(string email, string password)
        {
            conn.Open();
            string query = "SELECT COUNT(*) FROM Huurder WHERE email = @Email AND wachtwoord = @Wachtwoord";

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Wachtwoord", password);

                var count = cmd.ExecuteScalar();
                return (count != null && Convert.ToInt32(count) > 0);
                }
            }
        }
    };
