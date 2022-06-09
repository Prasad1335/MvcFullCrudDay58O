using Microsoft.EntityFrameworkCore;
using MvcFullCrudDay58O.Models.DataAccess;

namespace MvcFullCrudDay58O.Models.Services
{
    public class UserService
    {
        public async Task<List<User>> GetAllAsync()
        {
            using var context = new MvcDbContext();
            var users = from user in context.Users
                        select user;

            return await users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            using var context = new MvcDbContext();
            var users = from user in context.Users
                        where user.Id == id
                        select user;
            return await users.SingleOrDefaultAsync();
        }

        public async Task CreateAsync(User user)
        {
            using var context = new MvcDbContext();

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            using var context = new MvcDbContext();

            context.Users.Update(user);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            using var context = new MvcDbContext();

            var userToDelete = await
                (from user in context.Users
                 where user.Id == id
                 select user).SingleAsync();

            context.Users.Remove(userToDelete);

            await context.SaveChangesAsync();
        }
    }
}
