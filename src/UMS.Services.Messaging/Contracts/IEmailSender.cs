namespace UMS.Services.Messaging.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Infrastructure;

    public interface IEmailSender
    {
        Task SendEmailAsync(
            string from,
            string fromName,
            string to,
            string subject,
            string htmlContent,
            IEnumerable<EmailAttachment> attachments = null);
    }
}
