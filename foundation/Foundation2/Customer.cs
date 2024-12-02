class Customer(string name, Address address)
{
    private string _name = name;
    private Address _address = address;

    public string Name()
    {
        return _name;
    }

    public Address Address()
    {
        return _address;
    }
    
    public bool IsAmerican()
    {
        return _address.IsUSA();
    }
}