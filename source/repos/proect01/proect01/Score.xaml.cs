using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace proect01
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Score : ContentPage
    {
        public class User
        { 
            public int Id_s { get; set; }
            public int Point { get; set; }
        }

        DatabaseService databaseService = new DatabaseService();

        public Score()
        {
            InitializeComponent();
            var dataLabel = new Label();
            databaseService.GetDataAndDisplay(dataLabel);

            Content = new StackLayout
            {
                Children = { dataLabel }
            };
        }
    }
}