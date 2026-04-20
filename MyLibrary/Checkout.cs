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

        var groupedItems = _items.GroupBy(i=> i); // Grouped items to calculate offers

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

                totalPrice += offerCount * rule.OfferPrice.Value + remainingCount * rule.UnitPrice;
            }
            else
            {
                totalPrice += quantity * rule.UnitPrice;
            }
        
        }

        return totalPrice;
    }
}