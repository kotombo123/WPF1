using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Xml.Serialization;
using Microsoft.Win32;

namespace ContactManager
{
    public partial class MainWindow : Window
    {
        // Kolekcja kontaktów wyświetlana w programie
        public ObservableCollection<Contact> Contacts { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Contacts = new ObservableCollection<Contact>();
            DataContext = this;
        }

        // Metoda eksportująca dane do pliku XML
        private void MenuItem_Export(object sender, RoutedEventArgs e)
        {
            // Konfiguracja okna zapisu pliku
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML Files (*.xml)|*.xml";
            
            // Jeśli użytkownik wybierze miejsce zapisu
            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    // Tworzenie obiektu odpowiedzialnego za zamianę listy na XML
                    XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Contact>));
                    
                    // Otwarcie strumienia do pliku
                    using (TextWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        // Zapisanie danych do pliku
                        serializer.Serialize(writer, Contacts);
                    }
                    
                    MessageBox.Show("Export successful", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error during export: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        // Metoda importująca dane z pliku XML
        private void MenuItem_Import(object sender, RoutedEventArgs e)
        {
            // Konfiguracja okna otwierania pliku
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML Files (*.xml)|*.xml";
            
            // Jeśli użytkownik wybierze plik
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    // Narzędzie do odczytu formatu XML dla naszej listy kontaktów
                    XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Contact>));
                    
                    // Otwarcie pliku do odczytu
                    using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open))
                    {
                        // Odczytanie danych i zamiana ich z powrotem na obiekty C#
                        var importedContacts = (ObservableCollection<Contact>)serializer.Deserialize(fs);
                        
                        // Wyczyszczenie obecnej listy i dodanie zaimportowanych elementów
                        Contacts.Clear();
                        foreach (var contact in importedContacts)
                        {
                            Contacts.Add(contact);
                        }
                    }
                    
                    MessageBox.Show("Import successful", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error during import: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        // Pozostałe metody obsługi menu (skrócone dla przejrzystości)
        private void MenuItem_AddContact(object sender, RoutedEventArgs e)
        {
            this.Opacity = 0.5;
            var addWindow = new AddContactWindow();
            if (addWindow.ShowDialog() == true) { Contacts.Add(addWindow.NewContact); }
            this.Opacity = 1.0;
        }

        private void MenuItem_ClearContacts(object sender, RoutedEventArgs e) { Contacts.Clear(); }
        private void MenuItem_Exit(object sender, RoutedEventArgs e) { this.Close(); }
        private void MenuItem_About(object sender, RoutedEventArgs e) { MessageBox.Show("Simple contact manager", "About", MessageBoxButton.OK, MessageBoxImage.Information); }
    }
}
