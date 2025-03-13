# CineMultisalas - Sistema de Gestión de Reservas

Este proyecto es un sistema de gestión de reservas para un cine, desarrollado en **WPF** con **C#** y utilizando **Firebase Realtime Database** como backend. A continuación, se describe la estructura de clases, los paquetes NuGet utilizados y el diseño del proyecto.

---

## Estructura del Proyecto

CineMultisalas/
├── 📁 Helpers/
│   ├── 🟢 Validations.cs
│   ├── 🟢 ContextualHelps.cs
│   └── 🟢 SeatsConverter.cs
├── 📁 Resources/
│   └── 🟢 Styles.xaml
├── 📁 Models/
│   ├── 🟢 User.cs
│   ├── 🟢 Film.cs
│   ├── 🟢 Cinema.cs
│   ├── 🟢 Function.cs
│   ├── 🟢 Reservation.cs
│   └── 🟢 Seat.cs
├── 📁 ViewModels/
│   ├── 🟢 LoginViewModel.cs
│   ├── 🟢 HomeViewModel.cs
│   ├── 🟢 FilmsViewModel.cs
│   ├── 🟢 CinemasViewModel.cs
│   ├── 🟢 FunctionsViewModel.cs
│   ├── 🟢 ReservationsViewModel.cs
│   └── 🟢 SelectSeatsViewModel.cs
├── 📁 Views/
│   ├── 🟢 LoginView.xaml
│   ├── 🟢 HomeView.xaml
│   ├── 🟢 FilmsView.xaml
│   ├── 🟢 CinemasView.xaml
│   ├── 🟢 FunctionsView.xaml
│   ├── 🟢 ReservationsView.xaml
│   ├── 🟢 SelectSeatsView.xaml
│   └── 📁 Comp/
│       ├── 🟢 AddCinemaView.xaml
│       ├── 🟢 EditCinemaView.xaml
│       ├── 🟢 DeleteCinemaView.xaml
│       ├── 🟢 AddFilmView.xaml
│       ├── 🟢 EditFilmView.xaml
│       ├── 🟢 DeleteFilmView.xaml
│       ├── 🟢 AddFunctionView.xaml
│       ├── 🟢 EditFunctionView.xaml
│       └── 🟢 DeleteFunctionView.xaml
├── 📁 Services/
│   ├── 🟢 FirebaseService.cs
│   └── 🟢 AuthService.cs
├── 🟢 App.xaml
└── 🟢 MainWindow.xaml

---

## Paquetes NuGet Utilizados

- **Firebase.Database**: Para interactuar con Firebase Realtime Database.
- **CommunityToolkit.Mvvm**: Para implementar el patrón MVVM y simplificar el uso de comandos.
- **Newtonsoft.Json**: Para serializar y deserializar objetos JSON (usado internamente por Firebase.Database).

---

## Descripción de las Clases y Componentes

### **1. Modelos (`Models`)**
Representan las entidades principales del sistema.

- **`Cinema`**: Representa una sala de cine.
  - Propiedades: `Id`, `Name`, `Capacity`.
  
- **`Film`**: Representa una película.
  - Propiedades: `Id`, `Title`, `Duration`, `Genre`.
  
- **`Function`**: Representa una función (horario de película).
  - Propiedades: `Id`, `FilmId`, `CinemaId`, `StartTime`.
  - Propiedades de navegación: `Film`, `Cinema`.
  
- **`Reservation`**: Representa una reserva de asientos.
  - Propiedades: `Id`, `FunctionId`, `SelectedSeats`.
  
- **`Seat`**: Representa un asiento en una sala.
  - Propiedades: `SeatNumber`, `IsSelected`, `IsAvailable`.
  
- **`User`**: Representa un usuario del sistema.
  - Propiedades: `UserId`, `Username`, `Password`, `Role`.

---

### **2. ViewModels (`ViewModels`)**
Gestionan la lógica de la aplicación y se conectan con las vistas.

- **`CinemasViewModel`**: Gestiona las salas de cine.
  - Propiedades: `Cinemas`, `SelectedCinema`.
  - Comandos: `AddCinemaCommand`, `EditCinemaCommand`, `DeleteCinemaCommand`.
  
- **`FilmsViewModel`**: Gestiona las películas.
  - Propiedades: `Films`, `SelectedFilm`.
  - Comandos: `AddFilmCommand`, `EditFilmCommand`, `DeleteFilmCommand`.
  
- **`FunctionsViewModel`**: Gestiona las funciones (horarios).
  - Propiedades: `Functions`, `SelectedFunction`, `Films`, `Cinemas`.
  - Comandos: `AddFunctionCommand`, `EditFunctionCommand`, `DeleteFunctionCommand`.
  
- **`HomeViewModel`**: Controla la navegación entre vistas.
  - Comandos: `NavigateToFilmsCommand`, `NavigateToCinemasCommand`, `NavigateToFunctionsCommand`, `NavigateToReservationsCommand`.
  
- **`LoginViewModel`**: Gestiona el inicio de sesión.
  - Propiedades: `Username`, `Password`.
  - Comandos: `LoginCommand`.
  
- **`ReservationsViewModel`**: Gestiona las reservas.
  - Propiedades: `Reservations`.
  
- **`SelectSeatsViewModel`**: Gestiona la selección de asientos.
  - Propiedades: `Seats`, `Rows`, `FunctionId`.

---

### **3. Vistas (`Views`)**
Interfaz gráfica de la aplicación.

- **`CinemasView`**: Muestra y gestiona las salas de cine.
- **`FilmsView`**: Muestra y gestiona las películas.
- **`FunctionsView`**: Muestra y gestiona las funciones (horarios).
- **`HomeView`**: Vista principal después del login.
- **`LoginView`**: Vista de inicio de sesión.
- **`ReservationsView`**: Muestra las reservas.
- **`SelectSeatsView`**: Permite seleccionar asientos para una función.

---

### **4. Componentes (`Comp`)**
Ventanas adicionales para operaciones específicas.

- **`AddCinemaView`**: Ventana para añadir una nueva sala de cine.
- **`EditCinemaView`**: Ventana para editar una sala de cine existente.
- **`DeleteCinemaView`**: Ventana para confirmar la eliminación de una sala de cine.
- **`AddFilmView`**: Ventana para añadir una nueva película.
- **`EditFilmView`**: Ventana para editar una película existente.
- **`DeleteFilmView`**: Ventana para confirmar la eliminación de una película.
- **`AddFunctionView`**: Ventana para añadir una nueva función (horario de película).
- **`EditFunctionView`**: Ventana para editar una función existente.
- **`DeleteFunctionView`**: Ventana para confirmar la eliminación de una función.

---

### **5. Helpers (`Helpers`)**
Clases de utilidad.

- **`ContextualHelps`**: Proporciona mensajes de ayuda contextual.
- **`SeatsConverter`**: Convierte una lista de asientos en una cadena de texto.
- **`Validations`**: Contiene métodos de validación.

---

### **6. Servicios (`Services`)**
Gestionan la interacción con Firebase.

- **`AuthService`**: Gestiona la autenticación de usuarios.
- **`FirebaseService`**: Realiza operaciones CRUD en Firebase.

---

### **7. Recursos (`Resources`)**
Archivos de recursos para la aplicación.

- **`Styles.xaml`**: Define estilos globales para la aplicación.

---

## Funcionalidades Principales

1. **Autenticación de Usuarios**:
   - Los usuarios pueden iniciar sesión como administradores o usuarios normales.
   - Los administradores tienen acceso completo a todas las funcionalidades.
   - Los usuarios normales solo pueden seleccionar asientos y ver funciones.

2. **Gestión de Salas**:
   - Añadir, editar y eliminar salas de cine.
   - Mostrar la lista de salas en un `DataGrid`.

3. **Gestión de Películas**:
   - Añadir, editar y eliminar películas.
   - Mostrar la lista de películas en un `DataGrid`.

4. **Gestión de Funciones**:
   - Añadir, editar y eliminar funciones (horarios de películas).
   - Mostrar la lista de funciones en un `DataGrid`.

5. **Reservas**:
   - Los usuarios pueden seleccionar asientos disponibles para una función.
   - Las reservas se almacenan en Firebase.

6. **Ayuda Contextual**:
   - Cada vista tiene un mensaje de ayuda contextual que se muestra al hacer clic en el botón de ayuda.

---

## Tecnologías Utilizadas

- **WPF (Windows Presentation Foundation)**: Para la interfaz gráfica.
- **Firebase Realtime Database**: Para almacenar y gestionar datos.
- **CommunityToolkit.Mvvm**: Para implementar el patrón MVVM y simplificar el uso de comandos.
- **XAML**: Para definir la interfaz de usuario.

---

## Instrucciones de Uso y Solución de Problemas Comunes

### **Para Nuevos Integrantes**

1. **Clonar el Repositorio**:
   - Clona el repositorio en tu máquina local usando Git:
     ```bash
     git clone https://github.com/Chuckytin/cine-multisalas.git
     ```

2. **Abrir el Proyecto**:
   - Abre el proyecto en **Visual Studio 2022**.

3. **Restaurar Paquetes NuGet**:
   - Si hay errores relacionados con paquetes NuGet, restaura los paquetes:
     - Haz clic derecho en la solución y selecciona **"Restaurar paquetes NuGet"**.

4. **Limpieza Profunda (Si es Necesario)**:
   - Si persisten errores de compilación o referencias, realiza una limpieza profunda:
     1. Cierra Visual Studio.
     2. Elimina las carpetas `bin/`, `obj/` y `packages/` del proyecto.
     3. Abre Visual Studio nuevamente.
     4. Restaura los paquetes NuGet.
     5. Reconstruye la solución (**Build > Rebuild Solution**).

5. **Configurar Firebase**:
   - Asegúrate de tener configurado Firebase Realtime Database con las credenciales correctas en el archivo `FirebaseService.cs`.

6. **Ejecutar el Proyecto**:
   - Presiona **F5** o selecciona **"Start Debugging"** para ejecutar la aplicación.
   
---

### **Instrucciones de Uso para Usuarios**

1. **Iniciar Sesión**:
   - Abre la aplicación e inicia sesión como administrador (admin) o usuario normal (user).

2. **Gestionar Salas, Películas y Funciones**:
   - Como administrador (admin), puedes añadir, editar y eliminar salas, películas y funciones.

3. **Seleccionar Asientos**:
   - Como usuario normal (user), selecciona una función y reserva tus asientos.

4. **Ver Reservas**:
   - Como administrador (admin), puedes ver todas las reservas realizadas.
