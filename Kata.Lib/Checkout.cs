namespace CheckoutKata.Lib;

/// <summary>
/// Represents a checkout basket that allows items to be scanned
/// and calculates a total price based on pricing rules and special offers.
/// </summary>
public class Checkout : ICheckout
{
    private readonly List<string> _items = new();
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

        _items.Add(item);
    }

    /// <summary>
    /// Calculates the total price of all scanned items,
    /// applying unit prices and any applicable special offers.
    /// </summary>
    /// <returns>The total price of the basket.</returns>
    public int GetTotalPrice()
    {
        int totalPrice = 0;

        var groupedItems = _items.GroupBy(i => i); // Grouped items to calculate offers

        foreach (var group in groupedItems)
        {
            var sku = group.Key;
            var quantity = group.Count();
            var rule = _rules[sku];

            //Checks if there is an offer for the item 
            if (rule.OfferQuantity.HasValue && rule.OfferPrice.HasValue)
            {
                int offerCount = quantity / rule.OfferQuantity.Value;           
                // Needs this to calculate the remaining items that do not fit 
                int remainingCount = quantity % rule.OfferQuantity.Value;

                totalPrice += offerCount * rule.OfferPrice.Value
                              + remainingCount * rule.UnitPrice;
            }
            else
            {
                totalPrice += quantity * rule.UnitPrice;
            }
        }

        return totalPrice;
    }
}