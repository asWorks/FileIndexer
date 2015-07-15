using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MessageService:IMessageService
    {
        public void Message(string Message)
        {
            Console.WriteLine(Message);
            Trace.WriteLine(Message);
            Trace.Flush();
        }
    }
}
