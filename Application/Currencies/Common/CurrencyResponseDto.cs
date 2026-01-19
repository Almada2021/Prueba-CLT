namespace Application.Currencies;

public class CurrencyResponseDto
{
    public int Id { get; set; }
    public required string Code { get; set; }
    public required string Name { get; set; }
    public required decimal RateToBase { get; set; }
}
