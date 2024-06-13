using System;
using System.Data.SqlClient;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Xaml;
using Microsoft.SqlServer.Server;
using SQLite;
using Microsoft.Data.Sqlite;
using static proect01.LoginPage;
using Microsoft.Data.SqlClient;
using Npgsql;

namespace proect01
{

    public partial class LoginPage : ContentPage
    {
        private readonly DatabaseService _databaseService;
        public static int LoggedInUserId { get; set; }

        public LoginPage()
        {
            InitializeComponent();
            _databaseService = new DatabaseService();
        }
        private readonly string connectionString = "Host=172.26.64.1;Port=5432;Username=egor;Password=egor;Database=tetrisbd";
        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            string username = usernameEntry.Text;
            string password = passwordEntry.Text;

            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    var query = "SELECT Id_u, Password FROM Users WHERE Username = @username";
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("username", username);

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            if (reader.Read())
                            {
                                var userId = reader.GetInt32(0);
                                var storedPassword = reader.GetString(1);

                                if (storedPassword == password)
                                {
                                    LoggedInUserId = userId;
                                    resultLabel.TextColor = Color.Green;
                                    resultLabel.Text = "Авторизация успешна!";
                                    // Переход на страницу игры
                                    await Navigation.PushModalAsync(new TwoBtn());
                                }
                                else
                                {
                                    resultLabel.TextColor = Color.Red;
                                    resultLabel.Text = "Неправильный пароль";
                                }
                            }
                            else
                            {
                                resultLabel.TextColor = Color.Red;
                                resultLabel.Text = "Пользователь не найден";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                resultLabel.TextColor = Color.Red;
                resultLabel.Text = $"Ошибка подключения: {ex.Message}";
            }
        }
        private async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RegisterPage());
        }
    }
}