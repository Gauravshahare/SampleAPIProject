using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPIProject.Services
{
    public class LocalMailService : IMailService
    {
        private string _mailTo = "admin@company.com";
        private string _mailFrom = "noreply@company.com";
        public void Send(string subject, string message)
        {
            Debug.WriteLine($"mail from {_mailFrom} to {_mailTo}, with LocalMail Service.");
            Debug.WriteLine($"Subject: {subject}");
            Debug.WriteLine($"Message: {message}");
        }
    }
}
