namespace MyLibrary.Tests;

using MyLibrary;

public class CheckoutTests
{
    [Fact]
    public void GetTotalPrice_ReturnsZero_IfNoItemScanned()
    {
        var checkout = new Checkout(new List<PricingRule>());

        var totalPrice = checkout.GetTotalPrice();

        Assert.Equal(0, totalPrice);
    }

    [Fact]
    public void GetTotalPrice_SingleItem_ReturnsCorrectPrice()
    {
        var rules = new List<PricingRule>
        {
            new PricingRule { SKU = "A", UnitPrice = 50 }
        };

        var checkout = new Checkout(rules);

        checkout.Scan("A");

        var totalPrice = checkout.GetTotalPrice();

        Assert.Equal(50, totalPrice);
    }

    [Fact]
    public void GetTotalPrice_MultipleItems_ReturnsCorrectPrice()
    {
        var rules = new List<PricingRule>
        {
            new PricingRule { SKU = "A", UnitPrice = 50 },
            new PricingRule { SKU = "B", UnitPrice = 30 }
        };

        var checkout = new Checkout(rules);

        checkout.Scan("A");
        checkout.Scan("B");

        var totalPrice = checkout.GetTotalPrice();

        Assert.Equal(80, totalPrice);
    }
}