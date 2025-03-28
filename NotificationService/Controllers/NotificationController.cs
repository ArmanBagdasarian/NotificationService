using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NotificationService.Abstractions;
using NotificationService.Contracts.RequestModels;
using NotificationService.Contracts.ResponseModels;
using NotificationService.Implementations;

namespace NotificationService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationControllerController : ControllerBase
    {
       
        private readonly ILogger<NotificationControllerController> _logger;
        private readonly INotificationSender _notificationSender;
        private readonly INotificationManageService _notificationManageService;
        private readonly IValidator<NotificationSendRequestModel> _validator;
        public NotificationControllerController(ILogger<NotificationControllerController> logger, 
            INotificationSender notificationSender, 
            INotificationManageService notificationManageService, 
            IValidator<NotificationSendRequestModel> validator)
        {
            _logger = logger;
            _notificationSender = notificationSender;
            _notificationManageService = notificationManageService;
            _validator = validator;
        }

        [HttpGet(Name = "GetNotifications")]
        public IEnumerable<NotificationResponseModel> Get()
        {
          
            return _notificationManageService.GetAll();
        }

        [HttpPost(Name = "AddNotification")]
        public IActionResult Add(NotificationSendRequestModel model)
        {
            var result = _validator.Validate(model);
            if (!result.IsValid) 
            {
               
                return BadRequest(result.Errors);
            }
            INotificationService notificationService = null;

            switch(model.NotificationType)
            {
                case Enums.NotificationChannelType.Push:
                    notificationService = new PushNotificationService();
                    break;

                case Enums.NotificationChannelType.SMS:
                    notificationService = new SmsNotificationService();
                    break;

                case Enums.NotificationChannelType.Email:
                    notificationService = new EmailNotificationService();
                    break;
            }
           var status = _notificationSender.Send(notificationService, model);
            return Ok(new {status});
        }

    }
}
