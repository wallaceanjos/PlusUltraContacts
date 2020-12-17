using System;
using System.Collections.Generic;
using System.Text;

namespace PlusUltraContacts.Domain.Interfaces.Services
{
    interface IDeleteContactService
    {
        public void DeleteContact(Guid id);
    }
}
