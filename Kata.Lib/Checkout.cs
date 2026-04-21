namespace CheckoutKata.Lib;

/// <summary>
/// Represents a checkout basket that allows items to be scanned
/// and calculates a total price based on pricing rules and special offers.
/// </summary>
public class Checkout : ICheckout
{
    private readonly Dictionary<string, int> _items = new();
    private readonly Dictionary<string, PricingRule> _rules;

    /// <summary>
    /// Creates a new checkout instance with a set of pricing rules.
    /// </summary>
    /// <param name="pricingRules">The pricing rules used to calculate item totals.</param>
    public Checkout(IEnumerable<PricingRule> pricingRules)
    {
        _rules = pricingRules.ToDictionary(r => r.SKU);
    }

    /// <summary>
    /// Scans an item into the checkout.
    /// </summary>
    /// <param name="item">The SKU of the item being scanned.</param>
    public void Scan(string item)
    {
        if (string.IsNullOrWhiteSpace(item))
            throw new CheckoutException("Item cannot be null or empty");

        if (!_rules.ContainsKey(item))
            throw new CheckoutException($"Unknown SKU: {item}");

        _items[item] = _items.GetValueOrDefault(item) + 1;
    }

    /// <summary>
    /// Calculates the total price of all scanned items,
    /// applying unit prices and any applicable special offers.
    /// </summary>
    /// <returns>The total price of the basket.</returns>
    public int GetTotalPrice()
    {
        return _items.Sum(scannedItem => _rules[scannedItem.Key].Calculate(scannedItem.Value));
    }
}