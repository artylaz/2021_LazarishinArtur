using _2021_LazarishinArtur.Web.Domain.Entities;
using System;
using System.Linq;

namespace _2021_LazarishinArtur.Web.Domain.Repositories.Abstract
{
    public interface IUserRepository
    {
        IQueryable<User> GetUsers();
        void SeveUser(User user);
        void DeleteUser(Guid id);
    }
}
