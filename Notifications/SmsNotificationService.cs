using System;
using SmartCourierApp.Models;

namespace SmartCourierApp.Notifications
{
    public class SmsNotificationService : INotificationService
    {
        public void SendNotification(Customer customer)
        {
            Console.WriteLine("Send booking confirmation to mobile");
        }
    }
}