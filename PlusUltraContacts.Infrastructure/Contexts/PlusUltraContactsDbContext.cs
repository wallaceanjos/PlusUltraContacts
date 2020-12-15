using Microsoft.EntityFrameworkCore;
using PlusUltraContacts.Domain.Entities;
using System;

namespace PlusUltraContacts.Infrastructure
{
    // DbContext é nada mais que uma classe que sabe acessar banco de dados
    public class PlusUltraContactsDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        // Constructor Database.EnsureCreated() - Verifica o banco de dados para ter certeza que este foi criado
        public PlusUltraContactsDbContext()
        {
            Database.EnsureCreated();
        }

        // override OnConf... aqui é passada o tipo de banco e a string de conexão com o banco de dados
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PlusUltraContactsDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }


}
