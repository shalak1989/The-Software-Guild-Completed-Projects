using System.Collections.Generic;
using System.Linq;

namespace WebAPISample.Models
{
    public class FakeContactDatabase
    {
        private static List<Contact> _contacts = new List<Contact>();

        static FakeContactDatabase()
        {
            _contacts.AddRange(new[]
            {
                new Contact() {ContactId = 1, Name = "Jenny", PhoneNumber = "867-5309"}, 
                new Contact() {ContactId = 2, Name = "Bob", PhoneNumber = "555-1212"}
            });
        }

        public List<Contact> GetAll()
        {
            return _contacts;
        }

        public void Add(Contact contact)
        {
            if (_contacts.Any())
                contact.ContactId = _contacts.Max(c => c.ContactId) + 1;
            else
                contact.ContactId = 1;

            _contacts.Add(contact);
        }

        public void Delete(int id)
        {
            _contacts.RemoveAll(c => c.ContactId == id);
        }

        public void Edit(Contact contact)
        {
            Delete(contact.ContactId);
            _contacts.Add(contact);
        }


        public Contact GetById(int id)
        {
            return _contacts.First(c => c.ContactId == id);
        }
    }
}