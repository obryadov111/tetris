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
    public partial class TwoBtn : ContentPage
    {
        public TwoBtn()
        {
            InitializeComponent();
        }
        Button buttongame = new Button
        {
            Text = "Играть",
            FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
            BorderWidth = 1,
            VerticalOptions = LayoutOptions.CenterAndExpand
        };
        Button buttonscore = new Button
        {
            Text = "Результаты",
            FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
            BorderWidth = 1,
            VerticalOptions = LayoutOptions.CenterAndExpand
        };
    }
}