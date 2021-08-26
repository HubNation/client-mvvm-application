using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Expl
{
    public class Client : INotifyPropertyChanged
    {

        private string full_name;
        private int age;
        private string registration_address;
        private string residence_permit;
        private string phone;
        private string email;

        public string Fullname
        {
            get { return full_name; }
            set
            {
                full_name = value;
                OnPropertyChanged("Fullname");
            }
        }
        public int Age
        {
            get { return age; }
            set
            {
                age = value;
                OnPropertyChanged("Age");
            }
        }
        public string RegistrationAddress
        {
            get { return registration_address; }
            set
            {
                registration_address = value;
                OnPropertyChanged("RegistrationAddress");
            }
        }
        public string ResidencePermit
        {
            get { return residence_permit; }
            set
            {
                residence_permit = value;
                OnPropertyChanged("ResidencePermit");
            }
        }
        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                OnPropertyChanged("Phone");
            }
        }
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
