namespace CheckoutKata.Lib;

/// <summary>
/// Represents pricing information for a SKU, including unit price
/// and optional multi-buy offer pricing.
/// </summary>
public class PricingRule
{
    /// <summary>
    /// The stock keeping unit identifier.
    /// </summary>
    public string SKU { get; set; }

    /// <summary>
    /// The standard unit price of the item.
    /// </summary>
    public int UnitPrice { get; set; }

    /// <summary>
    /// The quantity required to trigger a special offer (if any).
    /// </summary>
    public int? OfferQuantity { get; set; }

    /// <summary>
    /// The total price for the special offer quantity (if any).
    /// </summary>
    public int? OfferPrice { get; set; }

    /// <summary>
    /// Calculates the total price for a given quantity of items based on the pricing rule.
    /// </summary>
    /// <param name="quantity"></param>
    /// <returns>total price for the given quantity</returns>
    public int Calculate(int quantity)
    {
        if (OfferQuantity.HasValue && OfferPrice.HasValue)
        {
            int offerCount = quantity / OfferQuantity.Value;
            int remainingCount = quantity % OfferQuantity.Value;
            return offerCount * OfferPrice.Value + remainingCount * UnitPrice;
        }

        return quantity * UnitPrice;
    }
}