
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

        public bool CreateGeheel(string email, string ruimte, string kenteken)
        {
            using var conn = GetConnection();
            conn.Open();

            using var transaction = conn.BeginTransaction();

            try
            {
                string huurderQuery = """
            INSERT INTO Huurder (email, isBetaald)
            VALUES (@Email, 0)
        """;

                using (var cmd = new MySqlCommand(huurderQuery, conn, transaction))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.ExecuteNonQuery();
                }

                string huisjeQuery = """
            INSERT INTO Huisje (ruimte, email)
            VALUES (@Ruimte, @Email)
        """;

                using (var cmd = new MySqlCommand(huisjeQuery, conn, transaction))
                {
                    cmd.Parameters.AddWithValue("@Ruimte", ruimte);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.ExecuteNonQuery();
                }

                string autoQuery = """
            INSERT INTO Auto (kenteken, email)
            VALUES (@Kenteken, @Email)
        """;

                using (var cmd = new MySqlCommand(autoQuery, conn, transaction))
                {
                    cmd.Parameters.AddWithValue("@Kenteken", kenteken);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.ExecuteNonQuery();
                }

                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                return false;
            }
        }


        public bool DashboardBetaald(string email)
        {
            conn.Open();
            string query = "UPDATE Huurder SET isBetaling = 1  WHERE email = @Email";
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

        public bool PasAan(string email, string ruimte, string kenteken)
        {
            using var conn = GetConnection();
            conn.Open();

            using var transaction = conn.BeginTransaction();

            try
            {
                // Update Huisje
                string huisjeQuery = """
            UPDATE Huisje 
            SET ruimte = @Ruimte 
            WHERE email = @Email
        """;

                using (var cmd = new MySqlCommand(huisjeQuery, conn, transaction))
                {
                    cmd.Parameters.AddWithValue("@Ruimte", ruimte);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.ExecuteNonQuery();
                }

                // Update Auto
                string autoQuery = """
            UPDATE Auto 
            SET kenteken = @Kenteken 
            WHERE email = @Email
        """;

                using (var cmd = new MySqlCommand(autoQuery, conn, transaction))
                {
                    cmd.Parameters.AddWithValue("@Kenteken", kenteken);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.ExecuteNonQuery();
                }

                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }


    }
};
