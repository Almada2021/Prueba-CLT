# Prueba CLT SA

Este repositorio fue creado para la prueba de la empresa CLT SA. en la cual me piden crear un API REST con .NET 10.0
utilizando minimal Api y Entity Framework Core. validaciones con Fluent Validation. y el uso de swagger para la documentacion de la API.
ademas de el uso de un header especifico para la autenticacion de las peticiones.

## Version de Dotnet usada

- .NET 10.0.100

## Instrucciones para ejecutar el proyecto Local

1. Clonar el repositorio tener instalado dotnet 10.0.100 y entity framework core.
2. Restaurar paquetes: dotnet restore
3. Instalar las herramientas de EF (si no las tiene): `dotnet tool install --global dotnet-ef`
4. Ejecutar el comando `dotnet ef database update` para crear la base de datos con sus tablas users, adresses y currencies.
5. Ejecutar el comando `dotnet run` para iniciar el servidor
6. Abrir el navegador y acceder a `http://localhost:5165/swagger` Para ver la documentacion de la API.

## Instrucciones para docker
Este proceso puede tardar unos minutos en completarse la imagen de .net 10.0 es pesada.
1. Tener Docker Desktop instalado y corriendo.
2. Abrir una terminal en la carpeta de tu proyecto.
3. Ejecutar: `docker-compose up --build`

## Caracteristicas ya Implementadas de los requisitos

- Creacion de la base de datos con sus tablas users, adresses y currencies.
- Creacion de los modelos de entidades con sus relaciones.

## Configuraciòn

La api key se puede configurar en el appsettings.json asi como el string de conexion a la base de datos. de momento se encuentra configurado para usar una base de datos en memoria. que por defecto se llama PruebaTecnica.db