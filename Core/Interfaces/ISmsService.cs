using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ISmsService
    {
        public Task SendSmsAsync(Sms sms);
    }
}
