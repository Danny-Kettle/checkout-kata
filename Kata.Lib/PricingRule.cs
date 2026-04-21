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
    public string SKU { get; }

    /// <summary>
    /// The standard unit price of the item.
    /// </summary>
    public int UnitPrice { get; }

    /// <summary>
    /// The quantity required to trigger a special offer (if any).
    /// </summary>
    public int? OfferQuantity { get; }

    /// <summary>
    /// The total price for the special offer quantity (if any).
    /// </summary>
    public int? OfferPrice { get; }

    /// <summary>
    /// Creates a new pricing rule for a SKU.
    /// </summary>
    /// <param name="sku">The SKU identifier.</param>
    /// <param name="unitPrice">The standard unit price.</param>
    /// <param name="offerQuantity">The quantity required to trigger a special offer (if any).</param>
    /// <param name="offerPrice">The total price for the special offer quantity (if any).</param>
    public PricingRule(string sku, int unitPrice, int? offerQuantity = null, int? offerPrice = null)
    {
        SKU = sku;
        UnitPrice = unitPrice;
        OfferQuantity = offerQuantity;
        OfferPrice = offerPrice;
    }

    /// <summary>
    /// Calculates the total price for a given quantity of items based on the pricing rule.
    /// If an offer is applicable, it applies the offer price for the qualifying quantity
    /// and the unit price for any remaining items.
    /// </summary>
    /// <param name="quantity">The quantity of items to calculate the price for.</param>
    /// <returns>The total price for the given quantity of items.</returns>
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