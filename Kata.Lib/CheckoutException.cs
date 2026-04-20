namespace CheckoutKata.Lib;

public class CheckoutException : Exception
{
    public CheckoutException(string message)
        : base(message)
    {
    }
}