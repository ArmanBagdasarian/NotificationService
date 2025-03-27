using NotificationService.Enums;

namespace NotificationService.Contracts.RequestModels
{
    public class NotificationSendRequestModel
    {
        public string From { get; set; } // sender identity
        public string Destination { get; set; } // for example email, phone number, or another identity
        public string Subject { get; set; }
        public string Text { get; set; }
        public NotificationChannelType NotificationType { get; set; }
    }
}
