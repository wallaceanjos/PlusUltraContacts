using PlusUltraContacts.Domain.Entities;
using PlusUltraContacts.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PlusUltraContacts.Infrastructure.Repositories
{
    public class ContactDbRepository : IContactRepository
    {
        /// <summary>
        /// Instância de classe "EntityDbRepository"
        /// Essa classe é para nossa entidade ser cadastrado no banco de dados.
        /// Isso se dá por intermédio de outra classe que sabe se conectar com o banco de dados"SolutionListDbContext".
        /// 
        /// Instância de objeto "_db" (o prefixo underscore representa o modificador de acesso private)
        /// Aqui estamos configurando o atributo _db dessa classe.
        /// Esse atributo _db  será um objeto do tipo readonly de uma classe que sabe acessar o banco de dados "SolutionDbContext"
        /// agora que _db é um objeto, deverá ser recebido no construtor do repositório logo abaixo.
        /// 
        /// Método construtor "EntityDbRepository" - Alocando recursos necessários nesta classe, recebendo como parametro para esta classe o contexto de "SolutionDbContext".
        /// responsável pela alocação de recursos necessários ao funcionamento do objeto (_db) além da definição inicial das variáveis de estado (atributos).
        /// </summary>

        private readonly PlusUltraContactsDbContext _context;

        public ContactDbRepository(PlusUltraContactsDbContext context)
        {
            _context = context;
        }

        public void Create(Contact contact)
        {
            _context.Add(contact);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var contact =  _context.Contacts.Find(id);
            _context.Contacts.Remove(contact);
            _context.SaveChanges();
        }

        public IEnumerable<Contact> ReadAll()
        {
            return _context.Contacts;
        }

        public void Update(Contact contact)
        {
            _context.Update(contact);
            _context.SaveChanges();
        }
    }
}
