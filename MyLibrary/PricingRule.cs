namespace MyLibrary;

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
}