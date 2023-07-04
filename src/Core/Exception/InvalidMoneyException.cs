namespace Core.Exception;

public class InvalidMoneyException : System.Exception
{
    public InvalidMoneyException(string cannotAddMoneyWithDifferentCurrencies): base(cannotAddMoneyWithDifferentCurrencies) { }
}