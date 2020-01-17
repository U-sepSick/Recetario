using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ListaDynamica.Models
{
    public class Receta_Ingredente
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string nombre = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }

        private int idReceta;
        public int IDReceta
        {
            get { return idReceta; }
            set
            {
                idReceta = value;
                OnPropertyChanged();
            }
        }

        private int idIgrediente;
        public int IDIgrediente
        {
            get { return idIgrediente; }
            set
            {
                idIgrediente = value;
                OnPropertyChanged();
            }
        }

        private string cantidad;
        [MaxLength(10)]
        public string Cantidad
        {
            get { return cantidad; }
            set
            {
                cantidad = value;
                OnPropertyChanged();
            }
        }

    }
}
