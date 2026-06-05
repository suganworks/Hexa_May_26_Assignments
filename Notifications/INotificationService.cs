using SmartCourierApp.Models;

namespace SmartCourierApp.Notifications
{
    public interface INotificationService
    {
        void SendNotification(Customer customer);
    }
}