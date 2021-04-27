using AutoMapper;
using Core.Entities.Concrete;
using Core.Interfaces;
using EmailService.Enums;
using EmailService.Interfaces;
using EmailService.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class EmailService : IEmailService<Email>
    {
        IEmailClientFactory _emailClientFactory;
        IEmailServiceClient _emailClient;
        IMapper _mapper;
        public EmailService(IEmailClientFactory client,IMapper mapper)
        {
            _emailClientFactory = client??throw new ArgumentNullException();
            _emailClient = _emailClientFactory.GetEmailClient(EnumEmaiClientTypeId.SendGrid)??throw new ArgumentNullException();
            _mapper = mapper ?? throw new ArgumentNullException();
        }
        public async Task SendBulkEmailAsync(IEnumerable<Email> T)
        {
           
            throw new NotImplementedException();
        }

        public async Task SendEmailAsync(Email email)
        {
            await _emailClient.SendEmailAsync(_mapper.Map<EmailModel>(email));
        }
    }
}
