# Trazabilidad API - .NET 8

Este proyecto es una API RESTful desarrollada con .NET 8 y Entity Framework Core. Gestiona un sistema de trazabilidad de procedimientos y conjuntos de datos, con autenticación basada en JWT y control de roles.

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

   En `appsettings.json` del proyecto `Presentation`, coloca tu cadena de conexión a SQL Server:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=.;Database=TrazabilidadDb;Trusted_Connection=True;TrustServerCertificate=True;"
   }


3. **Ejecuta el siguiente comando en la raíz de la solución**:
   ```bash
    dotnet restore

5. Marca el Proyecto TrazabilidadAPI.Presentation como proyecto de Inicio

5.Migracion
   -Compila toda la solucion 
  - En Herramientas -> Administración de Paquetes Nuget -> Consola de Administrador de paquetes
  - Pon como proyecto predeterminado  TrazabilidadAPI.Infrastructure
  - Comando (Asegurate de que tu String Connection este bien):
     ```bash
    - Add-Migration FirstMigration
  - Comando:
      ```bash
      Update-Database
6. Agrega los datos de prueba en sql server
  Usa una query para poblas la base de datos con los datos de prueba
7. Corre el proyecto



