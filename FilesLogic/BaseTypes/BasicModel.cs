using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;

namespace FilesLogic.BaseTypes
{
    public class BasicModel
    {

        private IMessageService _MessageService;

       public void ReportMessage(string message)
        {
            if (_MessageService != null)
            {
                _MessageService.Message(message);
            }
        }
     

        public BasicModel(IMessageService messageService)
       {
           _MessageService = messageService;
       }

        public BasicModel()
        {
            _MessageService = null;
        }
    }
}
