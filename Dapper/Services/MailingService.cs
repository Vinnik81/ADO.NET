using MyDapper.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyDapper.Services
{
    public class MailingService
    {
        public readonly IMailingRepository mailingRepository;

        public MailingService(IMailingRepository mailingRepository)
        {
            this.mailingRepository = mailingRepository;
        }
    }
}
