using PlusUltraContacts.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlusUltraContacts.Domain.Interfaces.Services
{
    interface IEditContactService
    {
        public void EditContact(Contact contact);
    }
}
