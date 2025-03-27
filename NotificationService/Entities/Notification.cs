using NotificationService.Enums;

namespace NotificationService.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public string From { get; set; } 
        public string Destination { get; set; } 
        public string Subject { get; set; }
        public string Text { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? SendDate { get; set; }
        public NotificationChannelType NotificationType { get; set; }
        public NotificationStatus NotificationStatus { get; set; }
    }
}
