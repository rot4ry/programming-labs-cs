using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    class User : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public string Login { get; set; }
        private int _points;
        public int Points {
            
            get {
                return _points;
            }
            
            set{
                
                if (_points != value)
                {
                    _points = value;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Points"));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        

        public User(int id, string login, int points)
        {
            ID = id;
            Login = login;
            Points = points;
        }
    }
}
