namespace Application.Adresses.Commands;

public class CreateAddressRequest
{
    public required string Street { get; set; }
    public required string City { get; set; }
    public required string Country { get; set; }
    public string? ZipCode { get; set; }
}