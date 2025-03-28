using NotificationService.Abstractions;
using NotificationService.Contracts.RequestModels;
using NotificationService.Data;
using NotificationService.Entities;
namespace NotificationService.Implementations
{
    public class NotificationSender : INotificationSender
    {
        private readonly DataContext _context;
        private readonly ILogger<NotificationSender> _logger;
        public NotificationSender(DataContext context, ILogger<NotificationSender> logger) 
        {
          _context = context;
            _logger = logger;
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
            if(result)
            {
              _logger.LogInformation($"Notification sent to {model.Destination} via {model.NotificationType}");
            }
            else
            {
                _logger.LogWarning($"Unable send notification to {model.Destination} via {model.NotificationType}");
            }
            
            //return result
        }
    }
}
