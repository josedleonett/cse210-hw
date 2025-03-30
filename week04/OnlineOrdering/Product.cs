public class Product
{
    private string _productId;
    private string _name;
    private double _unitPrice;
    private int _quantity;

    public Product(string productId, string name, double unitPrice, int quantity)
    {
        _productId = productId;
        _name = name;
        _unitPrice = unitPrice;
        _quantity = quantity;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetProductId()
    {
        return _productId;
    }

    public double GetTotalCost() =>  _unitPrice * _quantity;
}