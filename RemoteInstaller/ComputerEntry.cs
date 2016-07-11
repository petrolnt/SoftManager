using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

///<summary>
///класс обьект которого представляет состояние компьютера на котором идет процесс установки/удаления программы
///</summary>

namespace SoftManager
{
    class ComputerEntry : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        string name;
        string status;
        public ComputerEntry()
        {
        }
        public ComputerEntry(string name)
        {
            this.name = name;
            status = "Ожидание...";
        }

        public ComputerEntry(string name, string status)
        {
            this.name = name;
            this.status = status;
        }

        /// <summary>
        /// при изменении значения оповещаются подписчики и изменение заносится в форму progressTable
        /// 
        /// </summary> 

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                this.NotifyPropertyChanged("Name");
            }
            
        }

        public string Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
                 this.NotifyPropertyChanged("Status");
            }
           
        }
        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
