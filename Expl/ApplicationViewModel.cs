using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace Expl
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private Client selectedClient;

        public ObservableCollection<Client> Clients { get; set; }
        public Client SelectedClient
        {
            get { return selectedClient; }
            set
            {
                selectedClient = value;
                OnPropertyChanged("SelectedClient");
            }
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(obj =>
                    {
                        Client client = new Client ();
                        Clients.Insert(0, client);
                        SelectedClient = client;
                    }));
            }
        }

        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                    (removeCommand = new RelayCommand(obj =>
                    {
                        Client client = obj as Client;
                        if (client != null)
                        {
                            Clients.Remove(client);
                        }
                    },
                    (obj) => Clients.Count > 0));
            }
        }

        public ApplicationViewModel()
        {
            Clients = new ObservableCollection<Client>
            {
                new Client { Fullname="Иванов Иван Иванович", Age=25, RegistrationAddress="ул. Кутузова, д. 6",
                    ResidencePermit="ул. Котельникова, д. 8", Phone="89234213488", Email="coolemail@mail.ru"},
                new Client { Fullname="Петров Петр Петрович", Age=30, RegistrationAddress="ул. Мира, д. 20",
                    ResidencePermit="ул. Петрова, д. 1", Phone="89233211223", Email="verycoolemail@mail.ru"},
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
