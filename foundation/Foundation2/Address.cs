class Address(string street, string city, string state, string country)
{
    private string _street = street;
    private string _city = city;
    private string _state = state;
    private string _country = country;

    public bool IsUSA()
    {
        if (_country == "USA")
        {
            return true;
        }
        else{
            return false;
        }
    }

    public string CreateAddress()
    {
        return $"{_street}, {_city}, {_state}, {_country}";
    }
}