using ListaDynamica.Services;
using ListaDynamica.ViewModels;
using ListaDynamica.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListaDynamica
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
	{
        public ObservableCollection<Receta> Recet { get; set; }

        public MainPage()
		{
			InitializeComponent();
            BindingContext = Recet;
        }

        private async void OpenReceta(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RecetaView());
        }

        public async void GetRecetas()
        {
            List<Receta> re = await App.Database.GetPeopleAsync();

            if(re.Count != 0)
            {
                for(int i = 0; i < re.Count; i++)
                {
                    
                }
            }
        }
    }
}
