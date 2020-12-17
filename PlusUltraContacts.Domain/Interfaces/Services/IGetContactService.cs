using PlusUltraContacts.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlusUltraContacts.Domain.Interfaces.Services
{
    public interface IGetContactService
    {
        public IEnumerable<Contact> GetAllContacts();
        public Contact GetContactById(Guid id);
    }
}
