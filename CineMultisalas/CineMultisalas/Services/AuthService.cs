using CineMultisalas.Models;
using System.Linq;
using System.Threading.Tasks;

namespace CineMultisalas.Services
{
    public class AuthService
    {
        private readonly DatabaseService _databaseService;

        public AuthService()
        {
            _databaseService = new DatabaseService("YourConnectionString");
        }

        public async Task<bool> Authenticate(string username, string password)
        {
            // Obtiene la lista de usuarios desde la base de datos
            var users = await _databaseService.GetUsersAsync();

            // Busca el usuario que coincida con el nombre de usuario y la contraseña
            var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);

            // True si el usuario existe, false en caso contrario
            return user != null;
        }
    }
}