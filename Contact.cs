using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _4__Lists
{
    public class Contact : INotifyPropertyChanged
    {
        private string name;
        public string Name {

            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(FullInfo));
                }
            }
        
        }
        private string surname;
        public string Surname
        {

            get { return surname; }
            set
            {
                if (surname != value)
                {
                    surname = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(FullInfo));
                }
            }
        }

        public override string ToString()
        {
            return $"{Name} : {Surname} - {PhoneNumber}({Operator})";
        }
        public string PhoneNumber { get; set; }
        public string Operator { get; set; }
        public string FullInfo => $"{Name} {Surname}";
        public string photoPath { get; set; }

        public Contact()
        {
            Name = "No name";
            Surname = "No surname";
            PhoneNumber = "No number";
            Operator = "No operator";
            photoPath = Environment.CurrentDirectory + "\\Resources\\1.png";
        }
        public Contact(string name, string surname, string phone, string operatorType)
        {
            Name = name;
            Surname = surname;
            PhoneNumber = phone;
            Operator = operatorType;
            photoPath = Environment.CurrentDirectory + "\\Resources\\1.png";

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
