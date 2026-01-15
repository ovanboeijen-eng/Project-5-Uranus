
using MySql.Data.MySqlClient;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace Project__5.Pages.DataBase
{
    public class DataBase
    // hello
    {
        private MySqlConnectionStringBuilder builder = new();
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


        public bool GetHuurderByEmailAndPassword(string email, string password)
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
        public bool GetKlantByEmailAndPassword(string email, string password)
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

        public bool CreateHuurder(string email)
        {
            conn.Open();
            string query = "INSERT INTO Huurder (email) VALUES (@Email)";
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool CreateHuisje(string huisje_ID)
        {
            conn.Open();
            string query = "INSERT INTO Huisje (huisje_ID) VALUES (@Huisje_ID)";
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Huisje_ID", huisje_ID);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool CreateAuto(string kenteken)
        {
            conn.Open();
            string query = "INSERT INTO Auto (kenteken) VALUES (@Kenteken)";
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Kenteken", kenteken);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool DashboardBetaald(string email)
        {
            conn.Open();
            string query = "UPDATE Huurder SET isBetaald = 1  WHERE email = @Email";
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }

        }

        public bool Verwijder(string email)
        {
            conn.Open();
            string query = "DELETE FROM Huurder WHERE email = @Email";
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                int result = cmd.ExecuteNonQuery();
                return result == 1;
            }
        }

        public bool PasAan (string email, string huisje, string kenteken)
        {
            conn.Open();
            string query = "UPDATE Huurder SET huisje = @Huisje, kenteken = @Kenteken WHERE email = @Email";
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Kenteken", kenteken);
                cmd.Parameters.AddWithValue("@Huisje", huisje);
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

    }
};
