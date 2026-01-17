using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

/*
Campos mínimos:
• Id (int, PK, identity/autoincrement)
• Name (string, requerido)
• Email (string, requerido, único)
• IsActive (bool, por defecto true)
• Password (hasheado)
*/

public class User
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public bool IsActive { get; set; } = true;
    public required string Password { get; set; }

    // 1:N One To Many
    public ICollection<Address> Addresses { get; set; } = new List<Address>();
}