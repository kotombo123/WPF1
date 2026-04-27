using System;

namespace ContactManager
{
    // Definicja płci dostępnych w aplikacji
    public enum Gender
    {
        Male,
        Female
    }

    // Klasa reprezentująca pojedynczy kontakt
    public class Contact
    {
        // Imię kontaktu
        public string Name { get; set; }
        // Nazwisko kontaktu
        public string Surname { get; set; }
        // Adres e-mail
        public string Email { get; set; }
        // Numer telefonu
        public string Phone { get; set; }
        // Płeć kontaktu (wykorzystywana do wyboru awatara)
        public Gender Gender { get; set; }

        // Konstruktor bezparametrowy wymagany do serializacji i wiązania danych
        public Contact() { }
    }
}
