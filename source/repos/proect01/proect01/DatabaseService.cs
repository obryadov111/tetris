using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;
using System.Threading.Tasks;
using static proect01.Score;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace proect01
{
    public class DatabaseService
    {
        private readonly string connectionString = "Host=172.26.64.1;Port=5432;Username=egor;Password=egor;Database=tetrisbd";

        public async Task<bool> ValidateUserAsync(string username, string password)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT COUNT(1) FROM Users WHERE Username = @Username AND Password = @Password";
                var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("Username", username);
                command.Parameters.AddWithValue("Password", password);

                var result = (long)await command.ExecuteScalarAsync();
                return result > 0;
            }
        }
        public void GetDataAndDisplay(Label dataLabel)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT (SELECT username FROM Users WHERE id_user = id_u), point FROM Score", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string result = "";

                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                result += reader[i] + " ";
                            }

                            dataLabel.Text += result + "\n";
                        }
                    }
                }
                conn.Close();
            }

        }
    }
}
