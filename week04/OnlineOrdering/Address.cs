public class Address
{
    private string _street;
    private string _city;
    private string _country;

    public Address(string street, string city, string country)
    {
        _street = street;
        _city = city;
        _country = country;
    }

    public bool IsCountryUsa() => _country.Equals("USA", StringComparison.OrdinalIgnoreCase);

    public string GetFormattedAddress()
    {
        return $"{_street}\n {_city}, {_country}";
    }
}