class Product(string name, int productID, double price, int quantity)
{
    private string _name = name;
    private int _productID = productID;
    private double _price = price;
    private int _quantity = quantity;

    public string Name()
    {
        return _name;
    }

    public int ProductID()
    {
        return _productID;
    }

    public double Price()
    {
        return _price;
    }

    public int Quantity()
    {
        return _quantity;
    }
    
    public double TotalCost()
    {
        return _price * _quantity;
    }
}