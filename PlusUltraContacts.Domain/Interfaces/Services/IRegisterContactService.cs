using PlusUltraContacts.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlusUltraContacts.Domain.Interfaces.Services
{
    public interface IRegisterContactService
    {
        public void RegisterContact(Contact contact);
    }
}
