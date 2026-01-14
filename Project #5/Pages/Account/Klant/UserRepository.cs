using MySql.Data.MySqlClient;
using Project__5.Pages.DataBase;

namespace Login.Klant.Data
{
    public class UserRepository
    {
        private readonly DataBase _database;

        public UserRepository(DataBase database)
        {
            _database = database;
        }

        public bool CheckLogin(string email, string wachtwoord)
        {
            using var connection = _database.GetConnection();
            connection.Open();

            string query = "SELECT * FROM gebruikers WHERE email=@Email AND wachtwoord=@Wachtwoord";

            using var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Wachtwoord", wachtwoord);

            using var reader = cmd.ExecuteReader();

            return reader.HasRows; // true = gebruiker bestaat
        }
    }
}
