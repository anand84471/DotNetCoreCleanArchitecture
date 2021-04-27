using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class Email
    {
        public string Cleint { set; get; }
        public string ReceiverEmail { set; get; }
        public string SenderEmail { set; get; }
        public string Subject { set; get; }
        public string PlainTextContent { set; get; }
        public string HtmlContent { set; get; }
        public string SenderName { set; get; }
    }
}
