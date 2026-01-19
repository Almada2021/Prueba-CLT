namespace Domain.Entities;
/*
Tabla Addresses
Relación: Un User tiene muchos Addresses. 
Campos mínimos: 
• Id (int, PK) 
• UserId (int, requerido, FK a Users.Id) 
• Street (string, requerido) 
• City (string, requerido) 
• Country (string, requerido) 
• ZipCode (string, opcional) 
• etc
*/
public class Address
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public required string Street { get; set; }
    public required string City { get; set; }
    public required string Country { get; set; }
    public string? ZipCode { get; set; }
    public User? User { get; set; }
}