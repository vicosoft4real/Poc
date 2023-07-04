using System.ComponentModel.DataAnnotations.Schema;
using Core.Exception;

namespace Core.ValueObject;

/// <summary>
/// 
/// </summary>
/// <param name="Amount"></param>
/// <param name="Currency"></param>
[ComplexType]
public record Money(decimal Amount, string Currency)
{
    public Money() : this(0, "NGN")
    {
    }

    public static Money operator +(Money amount1, Money amount2)
    {
        if (!amount1.Currency.Equals(amount2.Currency, StringComparison.InvariantCultureIgnoreCase))
        {
            throw new InvalidMoneyException("Cannot add money with different currencies");
        }
        return new Money(amount1.Amount + amount2.Amount, amount1.Currency);
    }

    public static Money operator -(Money amount1, Money amount2)
    {
        if (!amount1.Currency.Equals(amount2.Currency, StringComparison.InvariantCultureIgnoreCase))
        {
            throw new InvalidMoneyException("Cannot subtract money with different currencies");
        }
        return new Money(amount1.Amount - amount2.Amount, amount1.Currency);
    }
}

