using Microsoft.AspNetCore.Mvc;
using PlusUltraContacts.Domain.Entities;
using PlusUltraContacts.Domain.Interfaces.Services;
using PlusUltraContacts.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlusUltraContacts.WebApp.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ContactService _service;
        private readonly ICalcBirthDay _birthdayService;

        public ContactsController(ContactService service, ICalcBirthDay birthdayService)
        {
            _service = service;
            _birthdayService = birthdayService;
        }


        // GET: Contacts
        public IActionResult Index()
        {
            var contacts = _service.GetAllContacts().ToList();
            var contact = new Contact();
            List<String> aux = new List<String>();

            for (int i = 0; i < contacts.Count; i++)
            {
                var data = contacts[i].DayOfBirth;
                contact.NextBirthday = _birthdayService.CacularDiasAniversario(data);

                contacts[i].NextBirthday = contact.NextBirthday;

                if (contacts[i].Name != null)
                {
                    if (contacts[i].NextBirthday == 0)
                    {
                        aux.Add(contacts[i].Name);
                    }
                }

            }

            aux.Sort();
            ViewBag.List = aux;

            if (aux.Count == 0)
            {
                ViewBag.Message = "Nenhum aniversariante no dia!";
            }

            return View(contacts.OrderBy(u => u.NextBirthday));

        }

        // GET: Contacts/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
                return NotFound();
            
            var contact = _service.GetContactById(id.Value);
            
            if (contact == null)
                return NotFound();

            return View(contact);
        }

        // GET: Contacts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Phone,DayOfBirth")] Contact contact)
        {
            _service.RegisterContact(contact);
            return RedirectToAction(nameof(Index));
        }

        // GET: Contacts/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
                return NotFound();

            var contact = _service.GetContactById(id.Value);

            if (contact == null)
                return NotFound();
            return View(contact);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Id,Name,Phone,DayOfBirth")] Contact contact)
        {
            if (id != contact.Id)
                return NotFound();


            _service.EditContact(contact);

            return View();

        }

        // GET: Contacts/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
                return NotFound();

            var contact = _service.GetContactById(id.Value);
            
            if (contact == null)
                return NotFound();

            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _service.DeleteContact(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: Contacts/Search/5
        [HttpGet]
        public IActionResult Index(string search)
        {
            //_service   = new PessoaRepository();

            IEnumerable<Contact> contacts = _service.SearchByName(search);
            return View(contacts);
        }

    }
}
