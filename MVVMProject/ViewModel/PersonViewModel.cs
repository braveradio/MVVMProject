using MVVMProject.Command;
using MVVMProject.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMProject.ViewModel
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        private Person _person;
        public Person Person
        {
            get { return _person; }
            set { _person = value; NotifyPropertyChanged("Person"); }
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
                NotifyPropertyChanged("People");
            }
        }

        public PersonViewModel()
        {
            
            Person = new Person();
            People = new ObservableCollection<Person>();
        }

        private ICommand _SubmitCommand;
        public ICommand SubmitCommand
        {
            get
            {
                if(_SubmitCommand == null)
                {
                    _SubmitCommand = new RelayCommand(SubmitExecute, CanSubmitExecute, false);
                }
                return _SubmitCommand;
            }
        }

        private bool CanSubmitExecute(object parameter)
        {
            if(string.IsNullOrEmpty(Person.FName) || string.IsNullOrEmpty(Person.LName))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void SubmitExecute(object parameter)
        {
            People.Add(Person);
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
