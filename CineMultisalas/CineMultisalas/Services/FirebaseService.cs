using Firebase.Database;
using Firebase.Database.Query;
using System.Collections.Generic;
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
        public async Task AddDataAsync<T>(string path, T data)
        {
            await _firebase.Child(path).PostAsync(data);
        }

        // Actualiza un objeto en una ruta específica en Firebase
        public async Task UpdateDataAsync<T>(string path, string key, T data)
        {
            await _firebase.Child(path).Child(key).PutAsync(data);
        }

        // Elimina un objeto de una ruta específica en Firebase
        public async Task DeleteDataAsync(string path, string key)
        {
            await _firebase.Child(path).Child(key).DeleteAsync();
        }
    }
}