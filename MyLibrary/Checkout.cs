namespace MyLibrary;

public class Checkout : ICheckout
{
    private readonly List<string> _items = new List<string>();
    private readonly Dictionary<string, PricingRule> _rules;

    //Constructor
    public Checkout(IEnumerable<PricingRule> pricingRules)
    {
        _rules = pricingRules.ToDictionary(r => r.SKU);
    }

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