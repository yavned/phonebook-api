using Microsoft.EntityFrameworkCore;
using PhoneBook.Data;
using PhoneBook.Interfaces;
using PhoneBook.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext context;

        public ContactRepository(ApplicationDbContext context)
        {
            this.context = context;
        }


        public async Task<Contact> GetByIdAsync(Guid id)
        {
            return await context.Contact.FindAsync(id);
        }

        public IQueryable<Contact> Get()
        {
            return context.Contact.AsQueryable();
        }

        public void Insert(Contact contact)
        {
            context.Contact.Add(contact);
        }

        public void Update(Contact contact)
        {
            context.Entry(contact).State = EntityState.Modified;
        }

        public void Delete(Contact contact)
        {
            context.Contact.Remove(contact);
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }


        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
