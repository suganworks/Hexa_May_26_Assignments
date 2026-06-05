using System;
using SmartCourierApp.Models;

namespace SmartCourierApp.Notifications
{
    public class WhatsAppNotificationService : INotificationService
    {
        public void SendNotification(Customer customer)
        {
            Console.WriteLine("Send booking confirmation to WhatsApp number");
        }
    }
}