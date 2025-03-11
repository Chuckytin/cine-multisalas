namespace CineMultisalas.Helpers
{
    public static class ContextualHelps
    {
        // Devuelve un mensaje de ayuda contextual basado en la vista actual
        public static string GetHelp(string viewName)
        {
            switch (viewName)
            {
                case "LoginView":
                    return "Ingrese su nombre de usuario y contraseña para acceder al sistema.";
                case "HomeView":
                    return "Aquí puedes navegar a las diferentes secciones del cine.";
                case "FilmsView":
                    return "Gestiona las películas disponibles en el cine.";
                case "CinemasView":
                    return "Gestiona las salas de cine.";
                case "FunctionsView":
                    return "Gestiona las funciones (horarios de películas).";
                case "ReservationsView":
                    return "Gestiona las reservas de los usuarios.";
                default:
                    return "Ayuda no disponible para esta vista.";
            }
        }
    }
}