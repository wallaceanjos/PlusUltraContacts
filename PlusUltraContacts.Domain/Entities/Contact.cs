using System;
using System.Collections.Generic;
using System.Text;

namespace PlusUltraContacts.Domain.Entities
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime DayOfBirth { get; set; }
        public int NextBirthday { get; set; }
    }



}
