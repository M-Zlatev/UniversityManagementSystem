namespace UMS.Services.Messaging
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Contracts;
    using Infrastructure;

    public class NullMessageSender : IEmailSender
    {
        public Task SendEmailAsync(string from, string fromName, string to, string subject, string htmlContent, IEnumerable<EmailAttachment> attachments = null)
        {
            return Task.CompletedTask;
        }
    }
}
