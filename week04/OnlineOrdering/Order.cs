using System.Text;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(List<Product> products, Customer customer)
    {
        _products = products;
        _customer = customer;
    }

    private double GetTotalOrderCost()
    {
        double orderTotalCost = 0;

        foreach (Product product in _products)
        {
            orderTotalCost += product.GetTotalCost();
        }

        return orderTotalCost;
    }

    private double GetShippingCost() => _customer.IsLivingInUsa() ? 5 : 35;

    public string GetPackingLabel()
    {
        var packingLabel = new StringBuilder("-------Packing Label-------\n");
        foreach (Product product in _products)
        {
            packingLabel.AppendLine($" {product.GetName()} (ID: {product.GetProductId()})");
        }
        return packingLabel.ToString();
    }

    public string GetShippingLabel()
    {
        string shippingLabel = $"-------Shipping Label-------\n Customer name: {_customer.GetName()}\n";
        shippingLabel += $" {_customer.GetAddress().GetFormattedAddress()}";

        return shippingLabel;
    }

    public double GetTotalPrice()
    {
        return GetTotalOrderCost() + GetShippingCost();
    }


}