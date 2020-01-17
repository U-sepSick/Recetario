using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListaDynamica.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RecetaView : ContentPage
	{

        public RecetaView ()
		{
			InitializeComponent ();
        }

        private async void Volver(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void ChangeReceta(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListRecetasView());
        }
    }
}