using System;

public class OrderBillingService
{
    public decimal CalculateSubTotal(decimal productPrice, int quantity)
    {
        if (productPrice <= 0 || quantity <= 0)
            throw new ArgumentException("Price and Quantity must be greater than 0.");

        return productPrice * quantity;
    }

    public decimal CalculateDiscount(decimal subTotal)
    {
        if (subTotal >= 5000)
            return subTotal * 0.10m; // 10% dis

        if (subTotal >= 2000)
            return subTotal * 0.05m; // 5% disc

        return 0m; // No disc
    }

    public decimal CalculateDeliveryCharge(decimal amountAfterDiscount)
    {
        return amountAfterDiscount < 1000 ? 100m : 0m;
    }

    public decimal CalculateFinalAmount(decimal productPrice, int quantity)
    {
        decimal subTotal = CalculateSubTotal(productPrice, quantity);
        decimal discount = CalculateDiscount(subTotal);
        decimal amountAfterDiscount = subTotal - discount;
        decimal deliveryCharge = CalculateDeliveryCharge(amountAfterDiscount);

        return amountAfterDiscount + deliveryCharge;
    }
}