using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace TodoList.Классы
{
    class TodoModel : INotifyPropertyChanged
    {
        private bool isDone = false;
        private string text;

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public bool IsDone
        {
            get { return isDone; }
            set 
            {
                if (isDone == value)
                    return;
                isDone = value;
                OnePropertyChange("IsDone");
            }
        }
       
        public string Text
        {
            get { return text; }
            set
            {
                if (text == value)
                    return;
                text = value;
                OnePropertyChange("Text");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnePropertyChange(string propertychange ="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertychange));
        }
    }
}
