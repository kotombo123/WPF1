using System.Collections.ObjectModel;
using System.Windows;

namespace ContactManager
{
    public partial class MainWindow : Window
    {
        // Kolekcja kontaktów z powiadamianiem o zmianach
        public ObservableCollection<Contact> Contacts { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            // Inicjalizacja listy i ustawienie kontekstu danych dla bindowania
            Contacts = new ObservableCollection<Contact>();
            DataContext = this;
        }

        // Otwiera okno dodawania kontaktu jako modalne
        private void MenuItem_AddContact(object sender, RoutedEventArgs e)
        {
            this.Opacity = 0.5; // Efekt przyciemnienia głównego okna
            var addWindow = new AddContactWindow();
            
            if (addWindow.ShowDialog() == true)
            {
                Contacts.Add(addWindow.NewContact);
            }
            this.Opacity = 1.0; // Przywrócenie jasności
        }

        // Czyści całą listę kontaktów
        private void MenuItem_ClearContacts(object sender, RoutedEventArgs e)
        {
            Contacts.Clear();
        }

        // Zamyka aplikację
        private void MenuItem_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // Wyświetla informacje o programie
        private void MenuItem_About(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is simple contact manager.", "Contact Manager", 
                            MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
