using PlusUltraContacts.Domain.Entities;
using PlusUltraContacts.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PlusUltraContacts.Infrastructure.Repositories
{
    public class ContactFileRepository : IContactRepository
    {
        private static List<Contact> _fileContacts = new List<Contact>();

        public void Create(Contact contact)
        {
            var file = new StreamWriter(@"D:\contacts.csv", true);
            file.WriteLine(contact.Id + ";" + contact.Name + ";" + contact.Phone + ";" + contact.DayOfBirth);
            file.Close();
        }

        public void Delete(Guid id)
        {

            //throw new NotImplementedException();
            var contacts = new List<Contact>();
            var file = new System.IO.StreamReader(@"D:\contacts.csv", true);
            var line = file.ReadLine();
            
            while (line != null && line != "")
            {
                var contactFields = line.Split(';');
                var fileContact = new Contact();

                fileContact.Id = Guid.Parse(contactFields[0]);
                fileContact.Name = contactFields[1];
                fileContact.Phone = contactFields[2];
                fileContact.DayOfBirth = DateTime.Parse(contactFields[3]);
                //fazer um if para comparar se contact == fileContact.id se for igual deleta 

                contacts.Add(fileContact);

                line = file.ReadLine();
            }
            //File.Delete
            file.Close();

            // Encontrando o contato pela id
            var editContact = contacts.Find(c => c.Id == id);
            contacts.Remove(editContact);

            // Criando um arquivo com a lista nova
            var updatefile = new System.IO.StreamWriter(@"D:\contacts.csv", false);          
            foreach (var c in contacts)
            {
                updatefile.WriteLine(c.Id + ";" + c.Name + ";" + c.Phone + ";" + c.DayOfBirth);
            }
            updatefile.Close();
                

        }

        public IEnumerable<Contact> ReadAll()
        {
            // Construção da lista
            var contacts = new List<Contact>();

            var file = new StreamReader(@"D:\contacts.csv", true);
            var line = file.ReadLine();
            
            // Fatiando e atribuindo informações
            while(line != null && line != "")
            {
                var contactFields = line.Split(';');
                var contact = new Contact();

                contact.Id = Guid.Parse(contactFields[0]);
                contact.Name = contactFields[1];
                contact.Phone = contactFields[2];
                contact.DayOfBirth = DateTime.Parse(contactFields[3]);

                contacts.Add(contact);

                line = file.ReadLine();
            }
            file.Close();
            return contacts;
        }

        public void Update(Contact contact)
        {
            //throw new NotImplementedException();
            var contacts = new List<Contact>();
            var file = new System.IO.StreamReader(@"D:\contacts.csv", true);
            var line = file.ReadLine();
            
            while (line != null && line != "")
            {
                var contactFields = line.Split(';');
                var fileContact = new Contact();

                fileContact.Id = Guid.Parse(contactFields[0]);
                fileContact.Name = contactFields[1];
                fileContact.Phone = contactFields[2];
                fileContact.DayOfBirth = DateTime.Parse(contactFields[3]);
                //fazer um if para comparar se contact == fileContact.id se for igual deleta 

                contacts.Add(fileContact);

                line = file.ReadLine();
            }
            //File.Delete
            file.Close();

            // Encontrando o contato pela id
            var editContact = contacts.Find(c => c.Id == contact.Id);


            // Editando este contato da lista
            editContact.Id = contact.Id;
            editContact.Name = contact.Name;
            editContact.Phone = contact.Phone;
            editContact.DayOfBirth = contact.DayOfBirth;
            
            // Criando um arquivo com a lista nova
            var updatefile = new System.IO.StreamWriter(@"D:\contacts.csv", false);
           
            if (editContact.Id == contact.Id)
            {
                foreach (var c in contacts)
                {
                    updatefile.WriteLine(c.Id + ";" + c.Name + ";" + c.Phone + ";" + c.DayOfBirth);
                }
                updatefile.Close();
                
            }


        }
    }
}
