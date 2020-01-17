using ListaDynamica.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListaDynamica.Services
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            // Conexion
            _database = new SQLiteAsyncConnection(dbPath);

            _database.CreateTableAsync<Receta>().Wait();
            _database.CreateTableAsync<Ingrediente>().Wait();
            _database.CreateTableAsync<Receta_Ingredente>().Wait();
        }


        // Delete registers
        public Task<int> DeletePersonAsync(Receta receta)
        {
            return _database.DeleteAsync(receta);
        }

        // Save registers
        public Task<int> UpdatePersonAsync(Receta receta)
        {
            return _database.UpdateAsync(receta);
        }

        // Ingredientes  ------------------

        public Task<List<Ingrediente>> GetIngredienteAsync()
        {
            return _database.QueryAsync("SELECT * ");
        }

        public Task<int> GuardarIngrediente(Ingrediente ingrediente)
        {
            return _database.InsertAsync(ingrediente);
        }

        // Receta  ------------------------

        public Task<List<Receta>> GetRecetaAsync()
        {
            return _database.Table<Receta>().ToListAsync();
        }

        public Task<int> GuardarReceta(Receta receta)
        {
            return _database.InsertAsync(receta);
        }

        // Receta_Ingredientes  -----------

        public Task<int> GuardarRecetaIngrediente(int idReceta, int idIngrediente, string cantidad)
        {
            Receta_Ingredente rI = new Receta_Ingredente()
            { 
                IDReceta = idReceta,
                IDIgrediente = idIngrediente,
                Cantidad = cantidad,
            };
            return _database.InsertAsync(rI);
        }
    }
}
