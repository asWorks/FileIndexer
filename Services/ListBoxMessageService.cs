using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Services
{
    public class ListBoxMessageService:IMessageService,INotifyPropertyChanged 
    {
     


        
        private ObservableCollection<string > _Messages;
        public ObservableCollection<string > Messages
        {
            get { return _Messages; }
            set
            {
                if (value != _Messages)
                {
                    _Messages = value;
                    OnPropertyChanged("Messages");
                    //  isDirty = true;
                }
            }
        }    

        public ListBoxMessageService()
        {
            Messages = new ObservableCollection<string>();
        }

        public void Message(string Message)
        {
           Messages.Add(Message);
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
