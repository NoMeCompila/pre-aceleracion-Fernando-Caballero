using SendGrid;
using SendGrid.Helpers.Mail;
using proyectoAlkemy.Interfaces;
using proyectoAlkemy.Models;

namespace proyectoAlkemy.Services
{
    public class MailService: IMailService
    {
        private readonly ISendGridClient _sendGridClient;
        private readonly ILogger<MailService> _logger;
        private const string FromEmail = "cabafer1@gmail.com";
        private const string FromName= "Fer";
        public MailService(ISendGridClient sendGridClient, ILogger<MailService> logger)
        {
            _sendGridClient = sendGridClient;
            _logger = logger;
        }

        /// <summary>
        /// Envia Emails a un username particular
        /// </summary>
        /// <param name="email"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task SendEmail(User user)
        {
            if (user == null || string.IsNullOrEmpty(user.Email)) return;//programación defensiva
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(FromEmail,FromName),
                Subject = "the Registry was Successful"
            };
            msg.AddContent(MimeType.Text, $"the Registry was Successful for the user {user.UserName}");
            msg.AddTo(new EmailAddress(user.Email, user.UserName));
            var response = await _sendGridClient.SendEmailAsync(msg);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Error en el envío de Email");
            }

            _logger.LogInformation("Se envió el email de forma correcta");
        }
    }
}
