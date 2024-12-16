using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PhoneContactF.Models;
using PhoneContactF.Services;

namespace PhoneContactF.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext context;

        public ContactController(ApplicationDbContext context)
        {
            this.context = context;
        }


        public IActionResult Index()
        {
            var contacts = context.contacts.ToList();

            return View(contacts);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ContactDto contactDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Contact contact = new Contact()
            {
                Name = contactDto.Name,
                Surname = contactDto.Surname,
                PhoneNumber = contactDto.PhoneNumber
            };

            context.contacts.Add(contact);
            context.SaveChanges();

            return RedirectToAction("Index" , "Contact");
        }

        public IActionResult Delete(int Id) 
        {
            var contact = context.contacts.Find(Id);

            if(contact == null)
            {
                return RedirectToAction("Index", "Contact");
            }

            context.contacts.Remove(contact);
            context.SaveChanges();

            return RedirectToAction("Index", "Contact");
        }
        public IActionResult Edit(int Id)
        {
            var contact = context.contacts.Find(Id);
            if (contact == null)
            {
                return RedirectToAction("Index", "Contact");
            }

            var contactDto = new ContactDto()
            {
                Name = contact.Name,
                Surname = contact.Surname,
                PhoneNumber = contact.PhoneNumber
            };

            ViewData["ContactId"] = contact.Id;

            return View(contactDto);
        }

        [HttpPost]
        public IActionResult Edit(int id , ContactDto contactDto)
        {
            var contact = context.contacts.Find(id);

            if (contact == null)
            {
                return RedirectToAction("Index", "Contact");
            }

            if (!ModelState.IsValid)
            {
                ViewData["ContacttId"] = contact.Id;
                return View(contactDto);
            }

            contact.Name = contactDto.Name;
            contact.Surname = contactDto.Surname;
            contact.PhoneNumber = contactDto.PhoneNumber;

            context.SaveChanges();

            return RedirectToAction("Index", "Contact");
        }




    }
}
