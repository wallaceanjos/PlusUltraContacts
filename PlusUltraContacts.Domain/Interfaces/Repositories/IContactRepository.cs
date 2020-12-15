using PlusUltraContacts.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlusUltraContacts.Domain.Interfaces.Repositories
{
    
    public interface IContactRepository
    {
        /// <summary>
        /// S.O.L.I.D - (D) Dependency Inversion Principle 
        /// Esta Interface de repositorio só faz CRUD
        /// - Create -> Create(Contact contact);
        /// - Read   -> IEnumerable<Contact> ReadAll(); 
        /// - Update -> Update(Contact contact);
        /// - Delete -> Delete(Guid id);
        ///     
        /// IEnumerable é uma interface que não permite alterações nos dados, ele permite apenas percorrer as informações
        /// 
        /// </summary>
        /// <param name="contact"></param>

        public void Create(Contact contact);

        public IEnumerable<Contact> ReadAll();

        public void Update(Contact contact);

        public void Delete(Guid id);
    }
}
