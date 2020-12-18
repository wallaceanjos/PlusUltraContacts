using PlusUltraContacts.Domain.Entities;
using PlusUltraContacts.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PlusUltraContacts.Domain.Interfaces.Services;

namespace PlusUltraContacts.Domain.Services
{

    public class ContactService : IRegisterContactService, IGetContactService, IEditContactService, IDeleteContactService, ISearchContactService
    {
        /// <summary>
        /// 1) Requisitos Funcionais e Casos de Uso
        /// Na camada de serviço nos vamos colocar as lógicas relacionadas aos REQUISITOS FUNCIONAIS e CASOS DE USO e vamos fazer as validações.
        ///     - RegisterContact
        ///     - EditContact
        ///     - GetAllContacts
        ///     - DeleteContact
        ///     - SearchByName
        /// IEnumerable é uma interface que não permite alterações nos dados, ele permite apenas percorrer as informações
        /// 
        /// Esse build block não resolverá questões de persistência
        /// Para persistir as informações apenas delegaremos para funções das interfaces de repositórios que resolverão essa questão.
        /// 
        /// 2) Instância de Objeto - Interface de repositório
        /// privete readonly IContactRepository _repository
        /// 
        /// 3) Método construtor
        /// Atalho para criar o metodo, Ctrl + "."
        /// O metodo aloca os recursos necessários nesta classe, e recebe como parametro o contexto do repositorio por intermédio da interface.
        /// </summary>

        private readonly IContactRepository _repository;

        public ContactService(IContactRepository repository)
        {
            _repository = repository;
        }
        // Register Contact Feature
        public void RegisterContact(Contact contact)
        {
            //
            if (contact.Name == "")
                return; //retorna sem cadastrar

            contact.Id = Guid.NewGuid();
            _repository.Create(contact);
        }

        // Show all contacts Feature
        public IEnumerable<Contact> GetAllContacts()
        {
            return _repository.ReadAll();
        }

        // Get Contact by Id
        public Contact GetContactById(Guid id)
        {
            return GetAllContacts().FirstOrDefault(c => c.Id == id);
        }       

        // Edit Contact Feature
        public void EditContact(Contact contact)
        {   
            _repository.Update(contact);
        }

        // Remove from contacts Feature
        public void DeleteContact(Guid id)
        {
            _repository.Delete(id);
        }

        // Search Feature
        public IEnumerable<Contact> SearchByName(string search)
        {
            if(search != null)
            {
                return _repository.ReadAll().Where(c => c.Name.ToLower().Contains(search.ToLower()));
            }
            return _repository.ReadAll();
        }
    }
}
