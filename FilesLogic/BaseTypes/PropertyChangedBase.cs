using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;

namespace FilesLogic.BaseTypes
{
    public class PropertyChangedBase:BasicModel,INotifyPropertyChanged
    {


        public PropertyChangedBase(IMessageService messageService)
            :base(messageService)
        {

        }

        public PropertyChangedBase()
            : base()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
