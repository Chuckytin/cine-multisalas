namespace CineMultisalas.Helpers
{
    public static class Validations
    {
        // Valida que el nombre de usuario y la contraseña no estén vacíos
        public static bool ValidateUserInput(string username, string password)
        {
            return !string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password);
        }
    }
}