using System.Collections.Generic;
using System.Text;

class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(List<Product> products, Customer customer)
    {
        _products = products;
        _customer = customer;
    }

    public List<Product> Products
    {
        get { return _products; }
        set { _products = value; }
    }

    public Customer Customer
    {
        get { return _customer; }
        set { _customer = value; }
    }

    public decimal GetTotalCost()
    {
        decimal total = 0m;
        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }

        total += GetShippingCost();
        return total;
    }

    public string GetPackingLabel()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine("Packing Label:");
        foreach (Product product in _products)
        {
            builder.AppendLine($"{product.Name} (ID: {product.ProductId})");
        }
        return builder.ToString().TrimEnd();
    }

    public string GetShippingLabel()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine("Shipping Label:");
        builder.AppendLine(_customer.Name);
        builder.Append(_customer.Address.GetFullAddress());
        return builder.ToString();
    }

    private decimal GetShippingCost()
    {
        return _customer.LivesInUSA() ? 5m : 35m;
    }
}
