using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineMultisalas.Services
{
    internal class AuthService
    {

        private string connectionString = "TuCadenaDeConexión";

        public bool ValidarUsuario(string usuario, string contraseña)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT COUNT(*) FROM Users WHERE Name = @Usuario AND Password = @Password";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@User", usuario);
                command.Parameters.AddWithValue("@Password", contraseña);

                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0; // Si count > 0, el usuario es válido
            }
        }

    }
}
