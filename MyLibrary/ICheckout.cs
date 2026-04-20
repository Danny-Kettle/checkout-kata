namespace MyLibrary;

/// <summary>
/// Represents a checkout system that allows scanning items and calculating a total price
/// based on pricing rules and special offers.
/// </summary>
public interface ICheckout
{
    /// <summary>
    /// Scans an item into the checkout basket.
    /// </summary>
    /// <param name="item">The SKU of the item being scanned.</param>
    void Scan(string item);

    /// <summary>
    /// Calculates the total price of all scanned items, including any special pricing rules.
    /// </summary>
    /// <returns>The total price of the basket.</returns>
    int GetTotalPrice();
}