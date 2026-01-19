namespace Application.Addresses.Commands;

public class CreateAddressRequest
{
    /// <example>Calle 123</example>
    public required string Street { get; set; }
    /// <example>Asuncion</example>
    public required string City { get; set; }
    /// <example>Paraguay</example>
    public required string Country { get; set; }
    /// <example> 110221</example>
    public string? ZipCode { get; set; }
}