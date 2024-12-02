class Order(List<Product> products, Customer customer)
{
    private List<Product> _products = products;
    private Customer _customer = customer;

    public double OrderCost()
    {
        double cost = 5;

        foreach (var product in _products)
        {
            cost += product.TotalCost();
        }

        if (!_customer.IsAmerican()) { cost += 30; }

        return cost;
    }

    public string CreatePackingLabel()
    {
        string packingLabel = "";
        foreach (var product in _products)
        {
            packingLabel += $"{product.ProductID()}: {product.Name()}\n";
        }
        return packingLabel;
    }

    public string CreateShippingLabel()
    {
        return $"{_customer.Name()}, {_customer.Address().CreateAddress()}\n";
    }
}