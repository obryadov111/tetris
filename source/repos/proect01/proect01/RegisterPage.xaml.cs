using System;
using Xamarin.Forms;
using Npgsql;

namespace proect01
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            var username = usernameEntry.Text;
            var password = passwordEntry.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                DisplayAlert("Ошибка", "Пожалуйста, заполните все поля.", "OK");
                return;
            }

            var connectionString = "Host=172.26.64.1;Port=5432;Username=egor;Password=egor;Database=tetrisbd";

            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    // Проверка на существование пользователя
                    var checkUserQuery = "SELECT COUNT(*) FROM Users WHERE Username = @username";
                    int userExists = 0;

                    using (var checkUserCommand = new NpgsqlCommand(checkUserQuery, connection))
                    {
                        checkUserCommand.Parameters.AddWithValue("username", username);
                        var result = checkUserCommand.ExecuteScalar();
                        if (result != null && !DBNull.Value.Equals(result))
                        {
                            userExists = Convert.ToInt32(result);
                        }
                    }

                    if (userExists > 0)
                    {
                        DisplayAlert("Ошибка", "Пользователь с таким именем уже существует.", "OK");
                        return;
                    }

                    // Вставка нового пользователя
                    var insertUserQuery = "INSERT INTO Users (Username, Password) VALUES (@username, @password)";
                    using (var insertUserCommand = new NpgsqlCommand(insertUserQuery, connection))
                    {
                        insertUserCommand.Parameters.AddWithValue("username", username);
                        insertUserCommand.Parameters.AddWithValue("password", password);
                        insertUserCommand.ExecuteNonQuery();

                        DisplayAlert("Успех", "Регистрация прошла успешно.", "OK");

                        // Переход на страницу логина
                        Navigation.PushModalAsync(new LoginPage());
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Ошибка", $"Ошибка подключения: {ex.Message}", "OK");
            }
        }
    }
}
