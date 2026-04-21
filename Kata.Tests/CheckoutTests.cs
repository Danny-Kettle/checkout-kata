namespace CheckoutKata.Tests;

using CheckoutKata.Lib;

public class CheckoutTests
{
        private List<PricingRule> GetDefaultRules() => new()
        {
            new PricingRule("A", 50, offerQuantity: 3, offerPrice: 130),
            new PricingRule("B", 30, offerQuantity: 2, offerPrice: 45),
            new PricingRule("C", 20),
            new PricingRule("D", 15),
        };

    [Fact]
    public void GetTotalPrice_ReturnsZero_IfNoItemScanned()
    {
        var checkout = new Checkout(GetDefaultRules());

        var totalPrice = checkout.GetTotalPrice();

        Assert.Equal(0, totalPrice);
    }

    [Fact]
    public void GetTotalPrice_SingleItem_ReturnsCorrectPrice()
    {
        var checkout = new Checkout(GetDefaultRules());

        checkout.Scan("A");

        var totalPrice = checkout.GetTotalPrice();

        Assert.Equal(50, totalPrice);
    }

    [Fact]
    public void GetTotalPrice_MultipleItems_ReturnsCorrectPrice()
    {
        var checkout = new Checkout(GetDefaultRules());

        checkout.Scan("A");
        checkout.Scan("B");

        var totalPrice = checkout.GetTotalPrice();

        Assert.Equal(80, totalPrice);
    }

    [Fact]
    public void GetTotalPrice_ThreeAs_UsesSpecialPrice()
    {

        var checkout = new Checkout(GetDefaultRules());

        checkout.Scan("A");
        checkout.Scan("A");
        checkout.Scan("A");

        var total = checkout.GetTotalPrice();

        Assert.Equal(130, total);
    }

    [Fact]
    public void GetTotalPrice_MixedBasket_AppliesAllOffersCorrectly()
    {
        var checkout = new Checkout(GetDefaultRules());

        checkout.Scan("A");
        checkout.Scan("A");
        checkout.Scan("A"); 

        checkout.Scan("B");
        checkout.Scan("B"); 

        checkout.Scan("C");

        var total = checkout.GetTotalPrice();

        Assert.Equal(195, total);
    }

    [Fact]
    public void GetTotalPrice_ExampleScenario_ReturnsCorrectPrice()
    {
        var checkout = new Checkout(GetDefaultRules());

        checkout.Scan("A"); 

        checkout.Scan("B");
        checkout.Scan("B"); 

        var total = checkout.GetTotalPrice();

        Assert.Equal(95, total);
    }


    [Fact]
    public void Scan_InvalidItem_ThrowsCheckoutException()
    {
        var checkout = new Checkout(new List<PricingRule>());

        Assert.Throws<CheckoutException>(() => checkout.Scan("Z"));
    }
    
}