using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ListaDynamica
{
    public class Receta :  INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string nombre = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }

        private int idR;
        [PrimaryKey, AutoIncrement]
        public int IdR
        {
            get { return idR; }
            set
            {
                idR = value;
                OnPropertyChanged();
            }
        }

        private string nomReceta;
        [MaxLength(50), Unique]
        public string NomReceta
        {
            get { return nomReceta; }
            set
            {
                nomReceta = value;
                OnPropertyChanged();
            }
        }

        private string instrucciones;
        public string Instrucciones
        {
            get { return instrucciones; }
            set
            {
                instrucciones = value;
                OnPropertyChanged();
            }
        }
    }
}