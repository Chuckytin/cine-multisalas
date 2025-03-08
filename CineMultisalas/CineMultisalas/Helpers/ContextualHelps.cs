using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineMultisalas.Helpers
{
    public static class ContextualHelps
    {
        public static string GetHelp(string viewName)
        {
            switch (viewName)
            {
                case "LoginView":
                    return "Ingrese su nombre de usuario y contraseña para acceder al sistema.";
                case "FilmsView":
                    return "Aquí puede gestionar las películas disponibles en el cine.";
                default:
                    return "Ayuda no disponible para esta vista.";
            }
        }
    }
}
