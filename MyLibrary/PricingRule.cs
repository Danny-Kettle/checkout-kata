namespace MyLibrary; 

public class PricingRule
{
    public string SKU { get; set; }
    public int UnitPrice { get; set; }
    public int? OfferQuantity { get; set; }
    public int? OfferPrice { get; set; }
}

