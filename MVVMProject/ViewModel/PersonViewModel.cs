using MVVMProject.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMProject.ViewModel
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        private Person person;

        public Person Person
        {
            get { return person; }
            set { person = value; NotifyPropertyChanged("Person"); }
        }
  

        private ObservableCollection<Person> _people;

        public ObservableCollection<Person> People
        {
            get 
            { 
                return _people; 
            }
            set 
            { 
                _people = value;
                NotifyPropertyChanged("Persons");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
