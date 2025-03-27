using NotificationService.Abstractions;
using NotificationService.Contracts.RequestModels;
using NotificationService.Data;
using NotificationService.Entities;
namespace NotificationService.Implementations
{
    public class NotificationSender : INotificationSender
    {
        private readonly DataContext _context;
        public NotificationSender(DataContext context) 
        {
          _context = context;
        }
        public void Send(INotificationService notificationService, NotificationSendRequestModel model)// return bool
        {
            var result = notificationService.Send(model);
            notificationService.Dispose();
            Notification notification = new()
            {
                Destination = model.Destination,
                From = model.From,
                NotificationType = model.NotificationType,
                Subject = model.Subject,
                Text = model.Text,
                NotificationStatus = result?Enums.NotificationStatus.Sent:Enums.NotificationStatus.Error,
                CreatedDate = DateTimeOffset.Now,
                SendDate = result?DateTimeOffset.Now:null
            };

            _context.Notifications.Add(notification);
            _context.SaveChanges();
            //return result
        }
    }
}
