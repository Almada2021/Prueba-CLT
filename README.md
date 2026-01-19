# Prueba Técnica - CLT S.A.

Este repositorio contiene la solución desarrollada para el proceso de selección de **CLT S.A.** Se trata de una **API REST** desarrollada bajo el framework **.NET 10.0**, utilizando un enfoque de arquitectura moderna y eficiente.

## Tecnologías Implementadas

* **.NET 10.0 (Minimal APIs):** Para una estructura de servicios ligera y de alto rendimiento.
* **Entity Framework Core:** ORM para la gestión y persistencia de datos.
* **Fluent Validation:** Implementación de reglas de validación de forma desacoplada y robusta.
* **Swagger (OpenAPI):** Documentación interactiva para facilitar el consumo y pruebas de la API.
* **Seguridad:** Sistema de autenticación basado en un **Header personalizado** para todas las peticiones.

---

## Requisitos de Software

* **.NET SDK 10.0.100**
* Herramientas de Entity Framework Core instaladas:
    ```bash
    dotnet tool install --global dotnet-ef
    ```

---

## Instrucciones para Ejecución Local

Siga estos pasos para configurar y ejecutar el proyecto en su entorno:

1.  **Clonar el repositorio** y situarse en la raíz del mismo.
2.  **Restaurar dependencias:**
    ```bash
    dotnet restore
    ```
3.  **Configurar la Base de Datos:**
    Ejecute el comando de migración para generar la base de datos local:
    ```bash
    dotnet ef database update
    ```
    > **Nota sobre los datos:** La API cuenta con un sistema de *Data Seeding*. Al ejecutar la actualización de la base de datos, se cargarán automáticamente **datos de prueba** en las tablas de `Users`, `Addresses` y `Currencies` para permitir una evaluación inmediata sin necesidad de cargas manuales.

4.  **Iniciar la Aplicación:**
    ```bash
    dotnet run
    ```
5.  **Acceder a Swagger:**
    Una vez iniciado el servidor, puede probar los endpoints en: `http://localhost:5165/swagger`

---

## Ejecución con Docker

El proyecto está preparado para ejecutarse en contenedores (tenga en cuenta que la imagen de .NET 10 puede demorar unos minutos en descargarse por primera vez):

1.  Asegúrese de tener **Docker Desktop** en ejecución.
2.  Desde la terminal, en la carpeta raíz, ejecute:
    ```bash
    docker-compose up --build
    ```

---

## Características Implementadas

Todas Las requeridds

## Configuración

La configuración se centraliza en el archivo `appsettings.json`:
* **API Key:** Clave configurable necesaria para la autenticación de los endpoints.
* **Persistencia:** Por defecto, utiliza **SQLite** para facilitar la portabilidad, generando el archivo local `PruebaTecnica.db`.