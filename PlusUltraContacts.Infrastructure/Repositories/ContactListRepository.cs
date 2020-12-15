using PlusUltraContacts.Domain.Entities;
using PlusUltraContacts.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PlusUltraContacts.Infrastructure.Repositories
{
    public class ContactListRepository : IContactRepository
    {
        private static List<Contact> _contacts = new List<Contact>();

        public void Create(Contact contact)
        {
            _contacts.Add(contact);
        }

        public IEnumerable<Contact> ReadAll()
        {
            return _contacts;
        }

        public void Update(Contact contact)
        {
            // Encontrando o contato pela id
            var listContact = _contacts.Find(c => c.Id == contact.Id);
            
            // Editando este contato
            listContact.Name = contact.Name;
            listContact.Phone = contact.Phone;
            listContact.DayOfBirth = contact.DayOfBirth;
        }

        public void Delete(Guid id)
        {
            // Encontrando o contato pela id
            var listContacts = _contacts.Find(c => c.Id == id);
            _contacts.Remove(listContacts);

        }

    }
}
