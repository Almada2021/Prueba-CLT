namespace Application.Addresses.Commands;

public class UpdateAddressRequest
{
    /// <example>Calle 123</example>
    public string Street { get; set; } = string.Empty;
    /// <example>Asuncion</example>
    public string City { get; set; } = string.Empty;
    /// <example>Paraguay</example>
    public string Country { get; set; } = string.Empty;
    /// <example> 110221</example>
    public string ZipCode { get; set; } = string.Empty;
}