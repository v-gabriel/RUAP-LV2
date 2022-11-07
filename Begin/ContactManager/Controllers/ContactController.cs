using ContactManager.Models;
using ContactManager.Services;
using Microsoft.AspNetCore.Mvc;

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


        [Route("save")]
        public bool Save()
        {
            var result = contactRepository.SaveContact(
                new Contact { Id = 1, Name = "Save me" }
                );
            return result;
        }
    }
}
