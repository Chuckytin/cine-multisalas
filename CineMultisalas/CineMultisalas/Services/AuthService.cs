using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using CineMultisalas.Models;

namespace CineMultisalas.Services
{
    public class AuthService
    {
        private readonly FirebaseClient _firebase;

        public AuthService()
        {
            _firebase = new FirebaseClient("https://cines-multisalas-default-rtdb.europe-west1.firebasedatabase.app/");
        }

        // Autentica a un usuario con username y password
        public async Task<string> LoginAsync(string username, string password)
        {
            try
            {
                var users = await _firebase
                    .Child("users")
                    .OnceAsync<User>();

                foreach (var user in users)
                {
                    System.Diagnostics.Debug.WriteLine($"Usuario: {user.Object.Username}, Contraseña: {user.Object.Password}");
                }

                var userMatch = users.FirstOrDefault(u =>
                    u.Object.Username == username &&
                    u.Object.Password == password
                );

                if (userMatch != null)
                {
                    return userMatch.Object.UserId.ToString();
                }
                else
                {
                    return null;
                }
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en LoginAsync: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"Stack Trace: {ex.StackTrace}");
                return null;
            }
        }
    }
}