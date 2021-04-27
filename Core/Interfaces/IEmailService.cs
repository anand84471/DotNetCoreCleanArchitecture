using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IEmailService<T>
    {
        public Task SendEmailAsync(T email);
        public Task SendBulkEmailAsync(IEnumerable<T> T);
    }
}
