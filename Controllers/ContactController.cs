using DawnAPI.Models;
using DawnAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DawnAPI.Controllers
{
    //"api/" "[controller] = nameController" ( ip+portaServer/api/[controller] )
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase //"Controller" simple controller 
    {
        //public IActionResult Index() simple controller
        //{
        //    return View();
        //}

        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository= contactRepository;
        }

        [HttpGet]
        public async  Task<ActionResult<List<ContactModel>>> SearchAllContacts()
        {
            List<ContactModel> contactsList = await _contactRepository.SearchAllContacts();
            return Ok(contactsList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<ContactModel>>> SearchContact(int contactId)
        {
            ContactModel contact = await _contactRepository.SearchContact(contactId);
            return Ok(contact);
        }

        [HttpPost]
        public async Task<ActionResult<ContactModel>> RegisterContact([FromBody] ContactModel contact)
        {
            ContactModel addContact = await _contactRepository.AddContact(contact);
            return Ok(addContact);
        }

        [HttpPut]
        public async Task<ActionResult<ContactModel>> UpdateContact([FromBody] ContactModel contact, int contactId)
        {
            contact.Id = contactId;
            ContactModel addContact = await _contactRepository.UpdateContact(contact, contactId);
            return Ok(addContact);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ContactModel>> DeleteContact([FromBody] int contactId)
        {
            bool deleteContact = await _contactRepository.DeleteContact(contactId);
            return Ok(deleteContact);
        }
    }
}
