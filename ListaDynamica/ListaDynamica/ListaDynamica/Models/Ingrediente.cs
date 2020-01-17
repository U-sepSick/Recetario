using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ListaDynamica
{
    public class Ingrediente : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string nombre = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }

        private int idI;
        [PrimaryKey, AutoIncrement]
        public int IdI
        {
            get { return idI; }
            set
            {
                idI = value;
                OnPropertyChanged();
            }
        }

        private string nomIngrediente;
        [MaxLength(50), Unique]
        public string NomIngrediente
        {
            get { return nomIngrediente; }
            set
            {
                nomIngrediente = value;
                OnPropertyChanged();
            }
        }

    }
}