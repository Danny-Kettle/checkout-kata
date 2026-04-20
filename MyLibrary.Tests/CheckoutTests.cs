namespace MyLibrary.Tests;

public class CheckoutTests
{
    [Fact]
    public void GetTotalPrice_ReturnsZero_IfNoItemScanned()
    {
        var checkout = new Checkout();

        var totalPrice = checkout.GetTotalPrice();

        Assert.Equal(0, totalPrice);
    }

}