namespace MyLibrary;

public class Checkout : ICheckout
{
    private readonly List<string> _items = new List<string>();
    private readonly Dictionary<string, PricingRule> _rules = new Dictionary<string, PricingRule>
    {
        { "A", new PricingRule { SKU = "A", UnitPrice = 50 } },
        { "B", new PricingRule { SKU = "B", UnitPrice = 30 } },
        { "C", new PricingRule { SKU = "C", UnitPrice = 20 } },
        { "D", new PricingRule { SKU = "D", UnitPrice = 15 } }
    };

    public void Scan(string item)
    {
        _items.Add(item);
    }

    public int GetTotalPrice()
    {
        int totalPrice = 0;

        foreach (var item in _items)
        {
            totalPrice += _rules[item].UnitPrice;
        }

        return totalPrice;
    }
}