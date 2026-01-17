# Prueba CLT SA

Este repositorio fue creado para la prueba de la empresa CLT SA. en la cual me piden crear un API REST con .NET 10.0
utilizando minimal Api y Entity Framework Core. validaciones con Fluent Validation. y el uso de swagger para la documentacion de la API.
ademas de el uso de un header especifico para la autenticacion de las peticiones.

## Version de Dotnet usada
- .NET 10.0.100


## Instrucciones para ejecutar el proyecto 

1. Clonar el repositorio tener instalado dotnet 10.0.100 y entity framework core.
2. Ejecutar el comando `dotnet ef database update` para crear la base de datos con sus tablas users, adresses y currencies.
3. Ejecutar el comando `dotnet run` para iniciar el servidor
4. Abrir el navegador y acceder a `http://localhost:5165/swagger` Para ver la documentacion de la API.


## Caracteristicas ya Implementadas de los requisitos
- Creacion de la base de datos con sus tablas users, adresses y currencies.
- Creacion de los modelos de entidades con sus relaciones.