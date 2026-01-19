namespace Application.Currencies.Commands;

public class CreateCurrencyRequest
{
    /// <example>USD</example>
    public required string Code { get; set; }
    /// <example>United States Dollar</example>
    public required string Name { get; set; }
    /// <example>7300.0</example>
    public required decimal RateToBase { get; set; }
}
