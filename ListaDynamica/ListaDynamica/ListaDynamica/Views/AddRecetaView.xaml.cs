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
	public partial class AddRecetaView : ContentPage
	{
        IngredienteViewModel contexto = new IngredienteViewModel();

        Servicios servicio = new Servicios();

        public AddRecetaView ()
		{
			InitializeComponent ();

            BindingContext = contexto;
        }

        private void AddNomReceta(object sender, SelectedItemChangedEventArgs e)
        {
            var button = sender as Button;
            var vm = BindingContext as IngredienteViewModel;
            var item = button.BindingContext as Ingrediente;

            //vm.arvm.NomReceta = item.NomReceta;

            vm.arvm.AddRecetaCommand.Execute(item);
        }

        private void Remove_Clicked(object sender, SelectedItemChangedEventArgs e)
        {
            var button = sender as Button;
            var vm = BindingContext as IngredienteViewModel;
            var item = button.BindingContext as Ingrediente;

            Ingrediente it = item;
            contexto.IdI = it.IdI;

            vm.DelIngredienteCommand.Execute(item);
        }

        private async void Volver(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListRecetasView());
        }

    }
}