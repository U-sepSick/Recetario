using ListaDynamica.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;

namespace ListaDynamica
{
    public class Servicios
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string nombre = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }

        public ObservableCollection<Ingrediente> ingredientes { get; set; }
        public ObservableCollection<Receta> recetas { get; set; }

        Receta _receta = new Receta();

        private bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy = false; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
            }
        }

        public Servicios()
        {
            if (ingredientes == null)
            {
                ingredientes = new ObservableCollection<Ingrediente>();
            }

            if (recetas == null)
            {
                recetas = new ObservableCollection<Receta>();
            }
        }

        #region Ingrediente
        public ObservableCollection<Ingrediente> ConsultarI()
        {
            return ingredientes;
        }

        public void AddIngrediente(Ingrediente item)
        {
            ingredientes.Add(item);
        }

        public void DelIngrediente(string IDitem)
        {
            //Ingrediente delItem = ingredientes.FirstOrDefault(p => p.IdI == IDitem);
            //ingredientes.Remove(delItem);
        }
        #endregion

        #region Receta
        public ObservableCollection<Receta> ConsultarR()
        {
            return recetas;
        }

        public void AddReceta(Receta groupItem)
        {
            //groupItem.IngredientesList = ingredientes.ToList();
            //recetas.Add(groupItem);
            //App.Database.SavePersonAsync(groupItem);
        }

        public void EditReceta(Receta groupItem)
        {

        }

        public void DelReceta(Receta groupItem)
        {
            App.Database.DeletePersonAsync(groupItem);
        }
        #endregion
    }
}
