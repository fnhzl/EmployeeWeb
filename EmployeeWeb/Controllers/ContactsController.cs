using EmployeeWeb.Data;
using EmployeeWeb.Models;
using EmployeeWeb.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ContactlyDbContext dbContext;

        public ContactsController(ContactlyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllContacts()
        {
            var contacts = await dbContext.Contacts.ToListAsync();
            return Ok(contacts);
        }

        [HttpPost]
        public async Task<IActionResult> AddContact([FromBody] AddContactRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var domainModelContact = new Contact
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
                JobTitle = request.JobTitle,
                Salary = request.Salary,
                Department = request.Department
            };

            await dbContext.Contacts.AddAsync(domainModelContact);
            await dbContext.SaveChangesAsync();

            return Ok(domainModelContact);
        }

        //[HttpGet("{id:guid}")]
        //public async Task<IActionResult> GetContactById(Guid id)
        //{
        //    var contact = await dbContext.Contacts.FindAsync(id);
        //    if (contact == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(contact);
        //}

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateContact(Guid id, [FromBody] UpdateContactRequestDTO request)
        {
            if (id != request.Id || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var contact = await dbContext.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            contact.Name = request.Name;
            contact.Email = request.Email;
            contact.Phone = request.Phone;
            contact.JobTitle = request.JobTitle;
            contact.Salary = request.Salary;
            contact.Department = request.Department;

            await dbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteContact(Guid id)
        {
            var contact = await dbContext.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            dbContext.Contacts.Remove(contact);
            await dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
