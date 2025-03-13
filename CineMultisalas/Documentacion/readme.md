# CineMultisalas - Sistema de Gestión de Reservas

Este proyecto es un sistema de gestión de reservas para un cine, desarrollado en **WPF** con **C#** y utilizando **Firebase Realtime Database** como backend. A continuación, se describe la estructura de clases y su diseño.

---

## Estructura de Clases

### Diagrama UML
A continuación, se muestra un diagrama UML que representa la estructura de clases del proyecto:

![Diagrama UML](https://via.placeholder.com/800x600.png?text=Diagrama+UML)  
*(Reemplaza esta imagen con tu diagrama UML)*

---

### Descripción de las Clases

#### 1. **Modelos (`Models`)**
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

#### 2. **ViewModels (`ViewModels`)**
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

#### 3. **Vistas (`Views`)**
Interfaz gráfica de la aplicación.

- **`CinemasView`**: Muestra y gestiona las salas de cine.
- **`FilmsView`**: Muestra y gestiona las películas.
- **`FunctionsView`**: Muestra y gestiona las funciones (horarios).
- **`HomeView`**: Vista principal después del login.
- **`LoginView`**: Vista de inicio de sesión.
- **`ReservationsView`**: Muestra las reservas.
- **`SelectSeatsView`**: Permite seleccionar asientos para una función.

---

#### 4. **Helpers (`Helpers`)**
Clases de utilidad.

- **`ContextualHelps`**: Proporciona mensajes de ayuda contextual.
- **`SeatsConverter`**: Convierte una lista de asientos en una cadena de texto.
- **`Validations`**: Contiene métodos de validación.

---

#### 5. **Servicios (`Services`)**
Gestionan la interacción con Firebase.

- **`AuthService`**: Gestiona la autenticación de usuarios.
- **`FirebaseService`**: Realiza operaciones CRUD en Firebase.

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

## Instrucciones de Uso

1. **Iniciar Sesión**:
   - Abre la aplicación e inicia sesión como administrador o usuario normal.

2. **Gestionar Salas, Películas y Funciones**:
   - Como administrador, puedes añadir, editar y eliminar salas, películas y funciones.

3. **Seleccionar Asientos**:
   - Como usuario normal, selecciona una función y reserva tus asientos.

4. **Ver Reservas**:
   - Como administrador, puedes ver todas las reservas realizadas.

---

## Diagrama UML



---
