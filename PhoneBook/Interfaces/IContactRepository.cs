using PhoneBook.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Interfaces
{
    public interface IContactRepository : IDisposable
    {
        IQueryable<Contact> Get();
        Task<Contact> GetByIdAsync(Guid id);
        void Insert(Contact contact);
        void Delete(Contact contact);
        void Update(Contact contact);
        Task SaveAsync();
    }
}
