# 📚 Library Management System - DSW1 T2

Este proyecto es una solución integral para la gestión de una biblioteca universitaria, permitiendo el control de inventario de libros y el registro de préstamos a estudiantes. Ha sido desarrollado bajo una **Arquitectura Hexagonal (Onion Architecture)** para asegurar un código desacoplado, testeable y mantenible.

---

## 🛠️ Tecnologías y Herramientas

### **Backend (.NET Core)**
* **Framework:** .NET 8.0
* **Base de Datos:** PostgreSQL
* **ORM:** Entity Framework Core (Code First)
* **Arquitectura:** Hexagonal / Domain-Driven Design (DDD)

### **Frontend (React)**
* **Librería:** React.js con TypeScript
* **Herramienta de Construcción:** Vite
* **Estilos:** Bootstrap 5 & FontAwesome

---

## 🏗️ Estructura de la Solución (Backend)

La solución se divide en 4 capas siguiendo los principios de la arquitectura de cebolla:

1.  **Domain:** Contiene las entidades (`Book`, `Loan`) y la lógica de negocio pura.
2.  **Application:** Contiene las interfaces de servicio, los DTOs y el mapeo de datos.
3.  **Infrastructure:** Implementa la persistencia de datos, el `DbContext` y los repositorios.
4.  **API:** Los controladores RESTful y la configuración de la aplicación (CORS, DI).



---

## 🚀 Configuración e Instalación

### 1. Requisitos
* Tener instalado el **SDK de .NET 8.0**.
* Servidor **PostgreSQL** activo.
* **Node.js** para el entorno de React.

### 2. Preparación de la Base de Datos
1. Crea una base de datos llamada `db_library` en tu PostgreSQL.
2. Configura tus credenciales en el archivo `src/DSW1_T2_ChicllaZamoraRonny.API/appsettings.json`:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Host=localhost;Port=5432;Database=db_library;Username=postgres;Password=TU_CONTRASEÑA"
   }

3. Ejecutar Migraciones (Backend)
Desde la carpeta raíz del proyecto backend, ejecuta:

Bash

dotnet tool run dotnet-ef database update -p src/DSW1_T2_ChicllaZamoraRonny.Infrastructure -s src/DSW1_T2_ChicllaZamoraRonny.API

4. Iniciar la Aplicación

Para el Backend:

Bash

dotnet run --project src/DSW1_T2_ChicllaZamoraRonny.API/DSW1_T2_ChicllaZamoraRonny.API.csproj

Para el Frontend:

Bash

npm install
npm run dev

📑 Documentación de Endpoints
Módulo de Libros

GET /api/Books - Lista todos los libros disponibles.

POST /api/Books - Registra un nuevo libro en el inventario.

PUT /api/Books/{id} - Actualiza la información de un libro.

Módulo de Préstamos

GET /api/Loans - Obtiene la lista de préstamos activos.

POST /api/Loans - Registra un préstamo (valida stock y lo disminuye).

PUT /api/Loans/{id}/return - Procesa la devolución de un libro (repone el stock).

⚖️ Reglas de Negocio Clave

Control de Stock: Un libro no puede ser prestado si su stock actual es 0. La API retornará un error 400 Bad Request con un mensaje descriptivo.

Persistencia Atómica: Cada préstamo y devolución actualiza automáticamente la tabla de libros para mantener la integridad de los datos.

👤 Autor
Nombre: Ronny Chiclla Zamora

Institución: Cibertec

Curso: Desarrollo de Servicios Web I

Examen: T2 - Ciclo V
