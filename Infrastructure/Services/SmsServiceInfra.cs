using AutoMapper;
using Core.Entities.Concrete;
using Core.Interfaces;
using Microsoft.Extensions.Configuration;
using SmsService.Enums;
using SmsService.Interfaces;
using SmsService.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class SmsServiceInfra : ISmsService
    {
        ISmsClient _smsClient;
        IMapper _mapper;
        public SmsServiceInfra(ISmsClientFactory smsClientFactory,IMapper mapper, IConfiguration config)
        {
            _smsClient = smsClientFactory.GetSmsClient(new SmsConfigModel()
            {
                AccountSid = config["Twillio:Sid"],
                AuthToken = config["Twillio:Token"],
                SenderPhoneNo= config["Twillio:PhoneNo"]
            },EnumSmsClientTypeId.TWILLIO) ??throw new ArgumentNullException();
            _mapper = mapper ?? throw new ArgumentNullException();
        }
        public async Task SendSmsAsync(Sms sms)
        {
            await _smsClient.SendSmsAsync(_mapper.Map<SmsModel>(sms));
        }
    }
}
