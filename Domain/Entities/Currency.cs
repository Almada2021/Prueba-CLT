namespace Domain.Entities;
/*
tabla Currencies
• Id (int, PK) 
• Code (string, requerido, único, ej: "USD", "PYG") 
• Name (string, requerido) 
• RateToBase (decimal, requerido) o Tasa respecto a una moneda base (ej: PYG = 
1). 
*/
public class Currency
{
    public int Id { get; set; }
    public required string Code { get; set; }
    public required string Name { get; set; }
    public required decimal RateToBase { get; set; }
}