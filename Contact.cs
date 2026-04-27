using System;
using System.Xml.Serialization;

namespace ContactManager
{
    // Typ wyliczeniowy dla płci
    public enum Gender
    {
        Male,
        Female
    }

    // Klasa kontaktu przygotowana do zapisu w formacie XML
    public class Contact
    {
        // Imię - zostanie zapisane jako element XML
        public string Name { get; set; }
        
        // Nazwisko - zostanie zapisane jako element XML
        public string Surname { get; set; }
        
        // Adres e-mail
        public string Email { get; set; }
        
        // Numer telefonu
        public string Phone { get; set; }
        
        // Płeć
        public Gender Gender { get; set; }

        // Pusty konstruktor jest niezbędny dla mechanizmu serializacji XML
        public Contact() { }
    }
}
