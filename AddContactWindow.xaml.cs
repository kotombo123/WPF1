using System.Windows;

namespace ContactManager
{
    public partial class AddContactWindow : Window
    {
        // Obiekt przechowujący dane wpisywane w formularzu
        public Contact NewContact { get; private set; }

        public AddContactWindow()
        {
            InitializeComponent();
            // Tworzenie nowej instancji kontaktu i powiązanie jej z UI
            NewContact = new Contact();
            DataContext = NewContact;
        }

        // Zatwierdza dodawanie i zamyka okno z wynikiem True
        private void AddContact_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        // Anuluje operację i zamyka okno
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
