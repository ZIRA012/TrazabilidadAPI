# Trazabilidad API - .NET 8

Este proyecto es una API RESTful desarrollada con .NET 8 y Entity Framework Core. Gestiona un sistema de trazabilidad de procedimientos y conjuntos de datos, con autenticación basada en JWT y control de roles.

**[ **🎞️🎞️🎞️🎞️🎞️VER VIDEO DE PRESENTACION 🎞️🎞️🎞️🎞️🎞️**](https://youtu.be/nkmPMbNLUOo)**

## 🚀 Tecnologías Utilizadas

- ASP.NET Core 8 | Entity Framework Core | SQL Server |JWT (JSON Web Token) |Swagger |Git

## 📁 Estructura del Proyecto

La solución está compuesta por 4 capas/proyectos:

- **Domain**: Entidades.
- **Application**: Reglas de negocio y DTOs.
- **Infrastructure**: Repositorios y context EF.
- **Presentation**: API Controllers y configuración de servicios.

## ✅ Requisitos Previos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- SQL Server (o SQL Server Express)
- Visual Studio 2022 
- Postman (opcional, para probar endpoints)

## ⚙️ Configuración Inicial

1. **Clona el repositorio**:

   ```bash
   git clone https://github.com/tu-usuario/tu-repositorio.git
   cd tu-repositorio


2. **Configura la cadena de conexión**:

   En `appsettings.json` del proyecto `Presentation`, configura tu cadena de conexión a SQL Server con el nombre de tu servidor:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=.;Database=TrazabilidadDb;Trusted_Connection=True;TrustServerCertificate=True;"
   }


3. **Ejecuta el siguiente comando en la raíz de la solución**:
   ```bash
   dotnet restore

5. Marca el Proyecto TrazabilidadAPI.Presentation como proyecto de Inicio

5.Migracion
  - Compila toda la solucion
  - En Herramientas -> Administración de Paquetes Nuget -> Consola de Administrador de paquetes
  - Pon como proyecto predeterminado  TrazabilidadAPI.Infrastructure
  - Comando(Asegurate que la Connection string este bien configurado y que apunte a la base de datos `TrazabilidadDB`):
    ```bash
    Update-Database
6. Poblar Base de datos
   - Abre SQL Managament
   - Verifica que la base fue creada Correcamente
   - Abre el archivo adjunto `PoblarBasedeDatos.sql`
   - Ejecuta la Query
   - Verifica que la base de datos este llena
   
8. Corre el proyecto en https



