using ContactManager.Models;
using ContactManager.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace ContactManager.Controllers
{
    [Route("[controller]")]
    public class ContactController : Controller
    {
        private ContactRepository contactRepository;

        public ContactController(ContactRepository contactRepo)
        {
            this.contactRepository = contactRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("get")]
        public Contact[] Get()
        {
            return contactRepository.GetAllContacts();
        }


        [Route("add")]
        public Contact[] Save()
        {
            var result = contactRepository.SaveContact(
                new Contact { Id = 1, Name = "Save me" }
                );
            return result;
        }

        [HttpPost]
        [Route("post")]
        public IActionResult Post(Contact contact)
        {
            var result = this.contactRepository.SaveContact(contact);

            return Ok(result[result.Length-1]);
        }
    }
}
