using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace proect01
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TwoBtn : ContentPage
    {
        string us_name;
        public TwoBtn()
        {
            InitializeComponent();
            

            Xamarin.Forms.Button buttongame = new Xamarin.Forms.Button
            {
                Text = "Играть",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Xamarin.Forms.Button)),
                BorderWidth = 1,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            buttongame.Clicked += ToGame;

            Xamarin.Forms.Button buttonscore = new Xamarin.Forms.Button
            {
                Text = "Результаты",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Xamarin.Forms.Button)),
                BorderWidth = 1,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            buttonscore.Clicked += ToScore;


            StackLayout stackLayout = new StackLayout();
            stackLayout.Children.Add(buttongame);
            stackLayout.Children.Add(buttonscore);
            this.Content = stackLayout;
        }

        
        private async void OnButtonClicked(object sender, System.EventArgs e)
        {
            Xamarin.Forms.Button buttongame = (Xamarin.Forms.Button)sender;
            
        }
        private async void ToGame(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MainPage());
        }
        private async void ToScore(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Score());
        }
    }
}