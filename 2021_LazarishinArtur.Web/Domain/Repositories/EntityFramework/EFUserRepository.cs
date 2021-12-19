using _2021_LazarishinArtur.Web.Domain.Entities;
using _2021_LazarishinArtur.Web.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace _2021_LazarishinArtur.Web.Domain.Repositories.EntityFramework
{
    public class EFUserRepository : IUserRepository
    {
        private readonly AppDbContext context;
        public EFUserRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void SeveUser(User entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;

            context.SaveChanges();
        }

        public void DeleteUser(Guid id)
        {
            context.Users.Remove(new User { Id = id.ToString() });
            context.SaveChanges();
        }

        public User GetUserId(Guid id)
        {
            return context.Users.FirstOrDefault(x => x.Id == id.ToString());
        }

        public IQueryable<User> GetUsers()
        {
            return context.Users;
        }
    }
}
