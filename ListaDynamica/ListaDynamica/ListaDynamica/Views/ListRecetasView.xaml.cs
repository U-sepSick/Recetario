using ListaDynamica.Services;
using ListaDynamica.ViewModels;
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
	public partial class ListRecetasView : ContentPage
	{
        RecetaViewModel contexto = new RecetaViewModel();
        Servicios servicio = new Servicios();

        public EditRecetaView editReceta = new EditRecetaView();

        public ListRecetasView()
		{
			InitializeComponent ();
            BindingContext = contexto;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listRecetasView.ItemsSource = await App.Database.GetRecetaAsync();
        }

        private async void Volver(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RecetaView());
        }

        private async void AddRecetaView_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddRecetaView());
        }

        private async void EditarReceta_Clicked(object sender, SelectedItemChangedEventArgs e)
        {
            var button = sender as Button;
            var vm = BindingContext as RecetaViewModel;
            var groupItem = button.BindingContext as Receta;

            await Navigation.PushAsync(new EditRecetaView());
        }

        private async void RemoveReceta_Clicked(object sender, SelectedItemChangedEventArgs e)
        {
            var button = sender as Button;
            var vm = BindingContext as RecetaViewModel;
            var groupItem = button.BindingContext as Receta;

            Receta it = groupItem;
            contexto.groupItem = groupItem;

            vm.DelRecetaCommand.Execute(groupItem);
            listRecetasView.ItemsSource = await App.Database.GetPeopleAsync();
        }
    }
}