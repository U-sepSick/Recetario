using ListaDynamica.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListaDynamica
{
    public class IngredienteViewModel: Ingrediente
    {
        public ObservableCollection<Ingrediente> Ingredientes { get; set; }

        Servicios servicio = new Servicios();

        public RecetaViewModel arvm = new RecetaViewModel();

        Ingrediente item;

        public Command AddIngredienteCommand { get; set; }
        public Command DelIngredienteCommand { get; set; }

        public IngredienteViewModel()
        {
            Ingredientes = servicio.ConsultarI();
            AddIngredienteCommand = new Command(async () => await AddIngrediente(), () => !servicio.IsBusy);
            DelIngredienteCommand = new Command(async () => await DelIngrediente(), () => !servicio.IsBusy);

        }

        private async Task AddIngrediente()
        {
            servicio.IsBusy = true;
            Guid IdItem = Guid.NewGuid();
            item = new Ingrediente()
            {
                //IdI = IdItem.ToString(),
                NomIngrediente = NomIngrediente,
            };

            if (NomIngrediente == null)
                return;

            servicio.AddIngrediente(item);
            Limpiar();

            await Task.Delay(10);
            servicio.IsBusy = false;
        }

        private async Task DelIngrediente()
        {
            servicio.IsBusy = true;

            //servicio.DelIngrediente(IdI);

            await Task.Delay(10);
            servicio.IsBusy = false;
        }

        private void Limpiar()
        {
            //IdI = "";
            //Cantidad = "";
            NomIngrediente = "";
        }
    }
}
