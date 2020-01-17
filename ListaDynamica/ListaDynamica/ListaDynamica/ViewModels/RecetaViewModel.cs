using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListaDynamica.ViewModels
{
    public class RecetaViewModel : Receta
    {
        public ObservableCollection<Receta> Recetas { get; set; }
        Servicios servicio = new Servicios();

        public Receta groupItem;

        public Command AddRecetaCommand { get; set; }
        public Command EditRecetaCommand { get; set; }
        public Command DelRecetaCommand { get; set; }

        public RecetaViewModel()
        {
            Recetas = servicio.ConsultarR();
            AddRecetaCommand = new Command(async () => await AddReceta(), () => !servicio.IsBusy);
            //EditRecetaCommand = new Command(async () => await EditReceta(), () => !servicio.IsBusy);
            DelRecetaCommand = new Command(async () => await DelReceta(groupItem), () => !servicio.IsBusy);
        }

        private async Task AddReceta()
        {
            servicio.IsBusy = true;
            byte[] Idgroup = Guid.NewGuid().ToByteArray();
            int i = BitConverter.ToInt32(Idgroup, 0);
            groupItem = new Receta()
            {
                IdR = i,
                NomReceta = NomReceta,
                Instrucciones = Instrucciones,
            };

            servicio.AddReceta(groupItem);

            await Task.Delay(10);
            servicio.IsBusy = false;
        }

        private async Task EditReceta(Receta receta)
        {
            servicio.IsBusy = true;

            groupItem = new Receta()
            {
                NomReceta = NomReceta,
                //IngredientesList = ivm,
                //Instrucciones = groupItem.Instrucciones,
            };

            servicio.EditReceta(groupItem);

            await Task.Delay(10);
            servicio.IsBusy = false;
        }

        private async Task DelReceta(Receta groupItem)
        {
            //IsBusy = true;
            servicio.DelReceta(groupItem);
            await Task.Delay(10);
            //IsBusy = false;
        }
    }
}
