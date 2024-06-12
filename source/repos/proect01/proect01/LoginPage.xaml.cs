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

namespace proect01
{
    public partial class LoginPage : ContentPage
    {
        private readonly DatabaseService _databaseService;

        public LoginPage()
        {
            InitializeComponent();
            _databaseService = new DatabaseService();
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            string username = usernameEntry.Text;
            string password = passwordEntry.Text;

            bool isValid = await _databaseService.ValidateUserAsync(username, password);

            if (isValid)
            {
                // Переход на главную страницу
                await Navigation.PushModalAsync(new TwoBtn());
            }
            else
            {
                messageLabel.Text = "Неверное имя пользователя или пароль.";
            }
        }
    }
}