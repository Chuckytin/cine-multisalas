using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CineMultisalas.Models;
using Dapper;

namespace CineMultisalas.Services
{
    internal class DatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Métodos para películas
        public async Task<List<Film>> GetFilmsAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var films = await connection.QueryAsync<Film>("SELECT * FROM Films");
                return films.ToList();
            }
        }

        public async Task AddFilmAsync(Film film)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "INSERT INTO Films (Title, Description, Duration, Genre) VALUES (@Title, @Description, @Duration, @Genre)";
                await connection.ExecuteAsync(query, film);
            }
        }

        // Métodos para salas
        public async Task<List<Cinema>> GetCinemasAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var cinemas = await connection.QueryAsync<Cinema>("SELECT * FROM Cinemas");
                return cinemas.ToList();
            }
        }

        public async Task AddCinemaAsync(Cinema cinema)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "INSERT INTO Cinemas (Name, Capacity) VALUES (@Name, @Capacity)";
                await connection.ExecuteAsync(query, cinema);
            }
        }

        // Métodos para funciones
        public async Task<List<Function>> GetFunctionsAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var functions = await connection.QueryAsync<Function>("SELECT * FROM Functions");
                return functions.ToList();
            }
        }

        public async Task AddFunctionAsync(Function function)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "INSERT INTO Functions (FilmId, CinemaId, StartTime, EndTime) VALUES (@FilmId, @CinemaId, @StartTime, @EndTime)";
                await connection.ExecuteAsync(query, function);
            }
        }

        // Métodos para reservas
        public async Task<List<Reservation>> GetReservationsAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var reservations = await connection.QueryAsync<Reservation>("SELECT * FROM Reservations");
                return reservations.ToList();
            }
        }

        public async Task AddReservationAsync(Reservation reservation)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "INSERT INTO Reservations (UserId, FunctionId, Seats) VALUES (@UserId, @FunctionId, @Seats)";
                await connection.ExecuteAsync(query, reservation);
            }
        }

        // Método para obtener usuarios
        public async Task<List<User>> GetUsersAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var users = await connection.QueryAsync<User>("SELECT * FROM Users");
                return users.ToList();
            }
        }
    }
}
