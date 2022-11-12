using DawnAPI.Models;

namespace DawnAPI.Repositories.Interfaces
{
    public interface IContactRepository
    {
        Task<bool> DeleteContact(int contactId);

        Task<ContactModel> AddContact(ContactModel contact);

        Task<ContactModel> SearchContact(int contactId);

        Task<ContactModel> UpdateContact(ContactModel contact, int contactId);

        //Task<List<ContactModel>> SearchUserContact(int userId);//with parameter performs specific search

        Task<List<ContactModel>> SearchAllContacts(); //without parameter to search all
    }
}
