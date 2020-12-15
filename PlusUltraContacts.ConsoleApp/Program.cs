using PlusUltraContacts.Domain.Entities;
using PlusUltraContacts.Domain.Services;
using PlusUltraContacts.Infrastructure.Repositories;
using System;

namespace PlusUltraContacts.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Injeção de dependência - Repositórios
            var service = new ContactService(new ContactFileRepository());
            // var service = new ContactService(new ContactDbRepository(new Infrastructure.PlusUltraContactsDbContext()));
            int option = 0;

            do
            {
                Console.WriteLine("> Plus Ultra Contacts - ConsoleApp");
                Console.WriteLine();
                Console.WriteLine("1 - Registrar Contato");
                Console.WriteLine("2 - Editar um Contato");
                Console.WriteLine("3 - Listar Contatos");
                Console.WriteLine("4 - Remover Contato");
                Console.WriteLine("5 - Procurar Contato");
                Console.WriteLine("6 - Sair");
                Console.WriteLine();

                option = int.Parse(Console.ReadLine());
                Console.Clear();
                Contact contact;
                var brCulture = new System.Globalization.CultureInfo("pt-BR");
                
                // Services.ContactService - Register Contact Feature
                if ( option == 1)
                {
                    contact = new Contact();
                    Console.WriteLine("Digite o nome do contato");
                    contact.Name = Console.ReadLine();
                    Console.WriteLine("Digite o telefone do contato");
                    contact.Phone = Console.ReadLine();

                    Console.WriteLine("Digite a data de nascimento. Use o formato: " + brCulture.DateTimeFormat.ShortDatePattern);
                    string dateString = Console.ReadLine();
                    DateTime userDate;
                    // Verifica se a data foi digitada corretamente e calcula 
                    if (DateTime.TryParse(dateString, brCulture.DateTimeFormat, System.Globalization.DateTimeStyles.None, out userDate))
                    {
                        Console.WriteLine(contact.Name + " foi cadastrado! Nascido em: " + userDate.ToString("D", brCulture));
                        contact.DayOfBirth = userDate;
                        System.DateTime systemActualDay = DateTime.Now;
                        System.DateTime contactBirthDay = userDate;
                        // Separando a data atual
                        int tYear = systemActualDay.Year;
                        int tMonth = systemActualDay.Month;
                        int tDay = systemActualDay.Day;
                        // Separando a data de aniversário
                        //int bYear = contactBirthDay.Year;
                        int bMonth = contactBirthDay.Month;
                        int bDay = contactBirthDay.Day;
                        // Próximo ano
                        int nYear = tYear + 1;
                        // comparação
                        DateTime d1 = new DateTime(tYear, bMonth, bDay, 0, 0, 0);
                        DateTime d2 = new DateTime(tYear, tMonth, tDay, 0, 0, 0);
                        Console.WriteLine("DateTime 1 = {0:dd} {0:y}, {0:hh}:{0:mm}:{0:ss} ", d1);
                        Console.WriteLine("DateTime 2 = {0:dd} {0:y}, {0:hh}:{0:mm}:{0:ss} ", d2);
                        int res = DateTime.Compare(d1, d2);

                        // res <0 Se a data1 for anterior à data2
                        if (res < 0)
                        {
                            Console.WriteLine(res);
                            Console.WriteLine("Já passou");
                            // Quanto falta para próximo aniversário 
                            System.DateTime nextBirthDay = new System.DateTime(nYear, bMonth, bDay, 0, 0, 0);
                            System.TimeSpan daysRemaining = nextBirthDay.Subtract(d2);
                            Console.WriteLine("Faltam " + daysRemaining.Days + " para o proximo aniversário!");

                        }
                        // res >0 Se a data1 for posterior à data2
                        else if (res > 0)
                        {
                            Console.WriteLine(res);
                            Console.WriteLine("Está chegando");
                            System.TimeSpan daysRemaining = d1.Subtract(d2);
                            Console.WriteLine("Faltam " + daysRemaining.Days + " o aniversário!");
                        }
                        // res ==0 Se data1 for igual a data2
                        else if (res == 0)
                        {
                            Console.WriteLine(res);
                            Console.WriteLine("O aniversário de " + contact.Name + " é hoje!");
                        }
                    }

                    else
                    Console.WriteLine("A data informada está fora do padrão " + brCulture.DateTimeFormat.ShortDatePattern + ".");
                    service.RegisterContact(contact);
                }
                
                // Services.ContactService - Edit Contact Feature
                else if (option == 2)
                {
                    contact = new Contact();
                    Console.WriteLine("Digite o Id do usuário que deseja Editar:");
                    contact.Id = Guid.Parse(Console.ReadLine());
                    Console.WriteLine("Digite o novo nome:");
                    contact.Name = Console.ReadLine();
                    Console.WriteLine("Digite o novo Telefone:");
                    contact.Phone = Console.ReadLine();

                    Console.WriteLine("Digite a nova data de nascimento. Use o formato: " + brCulture.DateTimeFormat.ShortDatePattern);
                    string dateString = Console.ReadLine();
                    DateTime userDate;
                    if (DateTime.TryParse(dateString, brCulture.DateTimeFormat, System.Globalization.DateTimeStyles.None, out userDate))
                    {
                        Console.WriteLine(contact.Name + " foi cadastrado! Nascido em: " + userDate.ToString("D", brCulture));
                        contact.DayOfBirth = userDate;
                    }
                        
                    else
                        Console.WriteLine("A data informada está fora do padrão " + brCulture.DateTimeFormat.ShortDatePattern + ".");
                    service.EditContact(contact);

                }
                
                // Services.ContactService - Show all contacts Feature
                else if (option == 3)
                {
                    var contacts = service.GetAllContacts();
                    foreach (var c in contacts)
                    {
                        Console.WriteLine(c.Id);
                        Console.WriteLine(c.Name);
                        Console.WriteLine(c.Phone);
                        Console.WriteLine(c.DayOfBirth);
                        Console.WriteLine();
                    }

                }

                // Services.ContactService - Remove from Contacts Feature
                else if (option == 4)
                {
                    Console.WriteLine("Digite o Id do contato que deseja remover:");
                    var id = Guid.Parse(Console.ReadLine());
                    service.DeleteContact(id);
                }
                
                // Services.ContactService - Search Contact Feature
                else if (option == 5)
                {
                    Console.WriteLine("Digite o nome do contato que está procurando:");
                    var name = Console.ReadLine();
                    var result = service.SearchByName(name);
                    foreach (var c in result)
                    {
                        Console.WriteLine(c.Id);
                        Console.WriteLine(c.Name);
                        Console.WriteLine(c.Phone);
                        Console.WriteLine(c.DayOfBirth);
                        Console.WriteLine();
                    }

                }

                Console.WriteLine();
                Console.WriteLine("Digite ENTER para continuar...");
                Console.ReadKey();
                Console.Clear();


            } while (option != 6);
        }
    }
}
