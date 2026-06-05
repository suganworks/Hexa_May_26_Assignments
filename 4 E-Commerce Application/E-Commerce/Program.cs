using System;

class Program
{
    static void Main()
    {
        var billingService = new OrderBillingService();
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("--- E-Commerce Billing System ---");

        decimal price = GetValidDecimal("Enter product price: ");
        int quantity = GetValidInt("Enter quantity: ");

        try
        {
            decimal finalBill = billingService.CalculateFinalAmount(price, quantity);
            Console.WriteLine($"\n--- Order Summary ---");
            Console.WriteLine($"Final Amount Due: {finalBill:C}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static decimal GetValidDecimal(string prompt)
    {
        decimal value;
        while (true)
        {
            Console.Write(prompt);
            if (decimal.TryParse(Console.ReadLine(), out value) && value > 0)
                return value;

            Console.WriteLine("Invalid input. Please enter a positive number.");
        }
    }

    static int GetValidInt(string prompt)
    {
        int value;
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out value) && value > 0)
                return value;

            Console.WriteLine("Invalid input. Please enter a positive whole number.");
        }
    }
}