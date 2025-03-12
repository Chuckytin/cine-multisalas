using CineMultisalas.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineMultisalas.Services
{
    public class FirebaseService
    {
        private readonly FirebaseClient _firebase;

        public FirebaseService()
        {
            _firebase = new FirebaseClient("https://cines-multisalas-default-rtdb.europe-west1.firebasedatabase.app/");
        }

        // Obtiene datos de una ruta específica en Firebase
        public async Task<List<T>> GetDataAsync<T>(string path)
        {
            var data = await _firebase.Child(path).OnceAsync<T>();
            var result = new List<T>();
            foreach (var item in data) result.Add(item.Object);
            return result;
        }

        // Agrega un nuevo objeto a una ruta específica en Firebase
        public async Task<string> AddDataAsync<T>(string path, T data)
        {
            var response = await _firebase.Child(path).PostAsync(data);
            return response.Key; // Devuelve el ID generado por Firebase
        }

        // Actualiza un objeto en una ruta específica en Firebase
        public async Task UpdateDataAsync<T>(string path, int id, T data)
        {
            // Buscar el registro en Firebase por ID
            var items = await _firebase.Child(path).OnceAsync<T>();
            var itemToUpdate = items.FirstOrDefault(i => (i.Object as dynamic).Id == id); // Usar dynamic para acceder a la propiedad Id

            if (itemToUpdate != null)
            {
                // Actualizar el registro encontrado
                await _firebase.Child(path).Child(itemToUpdate.Key).PutAsync(data);
            }
            else
            {
                throw new ArgumentException("No se encontró el registro con el ID especificado.");
            }
        }

        // Elimina un objeto de una ruta específica en Firebase
        public async Task DeleteDataAsync<T>(string path, int id)
        {
            // Buscar el registro en Firebase por ID
            var items = await _firebase.Child(path).OnceAsync<T>();
            var itemToDelete = items.FirstOrDefault(i => (i.Object as dynamic).Id == id); // Usar dynamic para acceder a la propiedad Id

            if (itemToDelete != null)
            {
                // Eliminar el registro encontrado
                await _firebase.Child(path).Child(itemToDelete.Key).DeleteAsync();
            }
            else
            {
                throw new ArgumentException("No se encontró el registro con el ID especificado.");
            }
        }
    }
}