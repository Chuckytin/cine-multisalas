using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CineMultisalas.Models;

namespace CineMultisalas.Services
{
    internal class DatabaseService
    {

        private string connectionString = "TuCadenaDeConexión";

        public List<Pelicula> ObtenerPeliculas()
        {
            var peliculas = new List<Pelicula>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Peliculas";
                var command = new SqlCommand(query, connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    peliculas.Add(new Pelicula
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Genre = reader.GetString(2),
                        Duration = reader.GetInt32(3),
                        Classification = reader.GetString(4)
                    });
                }
            }
            return peliculas;
        }

        public void AgregarPelicula(Pelicula pelicula)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = "INSERT INTO Peliculas (Title, Genre, Duration, Classification) VALUES (@Titulo, @Genero, @Duracion, @Clasificacion)";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Title", pelicula.Title);
                command.Parameters.AddWithValue("@Genre", pelicula.Genre);
                command.Parameters.AddWithValue("@Duration", pelicula.Duration);
                command.Parameters.AddWithValue("@Classification", pelicula.Classification);
                command.ExecuteNonQuery();
            }
        }

        // Implementar métodos para Actualizar y Eliminar películas

    }
}
