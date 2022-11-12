using DawnAPI.Data;
using DawnAPI.Models;
using DawnAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DawnAPI.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly DataContext _dbContext;
        public ContactRepository(DataContext dataContext)
        {
            _dbContext = dataContext;
        }

        public async Task<ContactModel> AddContact(ContactModel contact)
        {
            await _dbContext.ContactsTable.AddAsync(contact);
            await _dbContext.SaveChangesAsync();
            return contact;
        }

        public async Task<ContactModel> UpdateContact(ContactModel contact, int contactId)
        {
            ContactModel updateContact = await SearchContact(contactId);
            if(updateContact == null) 
            {
                throw new Exception($"Contato para o ID: {contactId} não foi encontrado.");
            }

            updateContact.Name = contact.Name;

            _dbContext.ContactsTable.Update(updateContact);
            await _dbContext.SaveChangesAsync();

            return updateContact;
        }

        public async Task<bool> DeleteContact(int contactId)
        {
            ContactModel deleteContact = await SearchContact(contactId);

            if (deleteContact == null)
            {
                throw new Exception($"Contato para o ID: {contactId} não foi encontrado.");
            }

             _dbContext.ContactsTable.Remove(deleteContact);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<ContactModel>> SearchAllContacts()
        {
            return await _dbContext.ContactsTable.ToListAsync();
        }

        //public async Task<List<ContactModel>> SearchUserContact(int userId)
        //{
        //    //return await _dbContext.UsersTable.ToListAsync();
        //    throw new Exception();
        //}

        public async Task<ContactModel> SearchContact(int contactId)
        {
            return await _dbContext.ContactsTable.FirstOrDefaultAsync(contact => contact.Id == contactId);
        }
    }
}
