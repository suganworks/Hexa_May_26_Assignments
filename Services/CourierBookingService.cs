using SmartCourierApp.Models;
using SmartCourierApp.DeliveryCalculators;
using SmartCourierApp.Notifications;
using SmartCourierApp.Invoices;

namespace SmartCourierApp.Services
{
    public class CourierBookingService
    {
        private readonly IDeliveryChargeCalculator _calculator;
        private readonly INotificationService _notification;
        private readonly IInvoiceGenerator _invoice;

        public CourierBookingService(
            IDeliveryChargeCalculator calculator,
            INotificationService notification,
            IInvoiceGenerator invoice)
        {
            _calculator = calculator;
            _notification = notification;
            _invoice = invoice;
        }

        public void ProcessBooking(Customer customer, Parcel parcel, string deliveryType)
        {
            double amount = _calculator.CalculateCharge(parcel.Weight);

            var booking = new CourierBooking
            {
                Customer = customer,
                Parcel = parcel,
                DeliveryType = deliveryType,
                TotalCharge = amount
            };

            _invoice.GenerateInvoice(booking);
            _notification.SendNotification(customer);
        }
    }
}