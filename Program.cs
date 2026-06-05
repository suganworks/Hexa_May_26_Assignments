using System;
using SmartCourierApp.Models;
using SmartCourierApp.DeliveryCalculators;
using SmartCourierApp.Notifications;
using SmartCourierApp.Invoices;
using SmartCourierApp.Services;

namespace SmartCourierApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to SmartCourier Delivery System");
            Console.WriteLine("---------------------------------------");

            var customer = new Customer();
            Console.Write("Enter Customer Name: ");
            customer.Name = Console.ReadLine();

            Console.Write("Enter Customer Email: ");
            customer.Email = Console.ReadLine();

            Console.Write("Enter Customer Mobile Number: ");
            customer.MobileNumber = Console.ReadLine();

            var parcel = new Parcel();
            Console.Write("Enter Source City: ");
            parcel.SourceCity = Console.ReadLine();

            Console.Write("Enter Destination City: ");
            parcel.DestinationCity = Console.ReadLine();

            Console.Write("Enter Parcel Weight (kg): ");
            parcel.Weight = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("\nSelect Delivery Type:");
            Console.WriteLine("1. Standard Delivery");
            Console.WriteLine("2. Express Delivery");
            Console.WriteLine("3. International Delivery");
            Console.Write("Choice (1-3): ");
            string deliveryChoice = Console.ReadLine();

            IDeliveryChargeCalculator calculator;
            string deliveryTypeName = "";

            if (deliveryChoice == "2")
            {
                calculator = new ExpressDeliveryCalculator();
                deliveryTypeName = "Express Delivery";
            }
            else if (deliveryChoice == "3")
            {
                calculator = new InternationalDeliveryCalculator();
                deliveryTypeName = "International Delivery";
            }
            else
            {
                // defaults to standard if they type something else
                calculator = new StandardDeliveryCalculator();
                deliveryTypeName = "Standard Delivery";
            }

            Console.WriteLine("\nSelect Notification Type:");
            Console.WriteLine("1. Email");
            Console.WriteLine("2. SMS");
            Console.WriteLine("3. WhatsApp");
            Console.Write("Choice (1-3): ");
            string notificationChoice = Console.ReadLine();

            INotificationService notificationService;

            if (notificationChoice == "2")
            {
                notificationService = new SmsNotificationService();
            }
            else if (notificationChoice == "3")
            {
                notificationService = new WhatsAppNotificationService();
            }
            else
            {
                notificationService = new EmailNotificationService();
            }

            IInvoiceGenerator invoiceGenerator = new ConsoleInvoiceGenerator();

            var bookingService = new CourierBookingService(calculator, notificationService, invoiceGenerator);

            Console.WriteLine("\nProcessing your booking...");
            bookingService.ProcessBooking(customer, parcel, deliveryTypeName);

            Console.ReadLine();
        }
    }
}