using ContactManager.Models;
using ContactManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactManager.Controllers
{
    [Route("[controller]")]
    public class ContactController : Controller
    {
        private ContactRepository contactRepository;

        public ContactController()
        {
            this.contactRepository = new ContactRepository();
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
    }
}
