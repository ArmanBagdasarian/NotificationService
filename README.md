
For Notification Add the system validade input data with Fluent Validation, at the moment I validate only two fields.
Among the fields to fill in, there is a NotificationType field, which is an Enum type, it is this that determines how the notification will be sent to our user (Email, SMS, Push). 
After that, depending on the NotificationType in the switch construct, we define it and create a class corresponding to this value. 
The Send method of the NotificationSender class receives an object of the INotificationService type and all the sending data and, depending on which INotificationService the Sender get, calls the implementation of the method that was selected as the method for sending the notification.
If in the future there is a need to add new types of notification, we can add new class which is implement INotificationService interface and use it with NotificationSender.
The Send method makes a request to our API and returns a Boolean value, after which we free our unmanaged resources (For example: HttpClient for connecting to external API services (Sendgrid, Twilio, FireBase, etc)) using the Dispose method.

Also we have notification status field for checking notification delivery status and implement retry functionality based on it. 
For testing I use InMemory Database, for logging I use .Net built-in logger.
