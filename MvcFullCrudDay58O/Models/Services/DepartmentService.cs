using Microsoft.EntityFrameworkCore;
using MvcFullCrudDay58O.Models.DataAccess;

namespace MvcFullCrudDay58O.Models.Services
{
    public class DepartmentService
    {
        public async Task<List<Department>> GetAllAsync()
        {
            using var context = new MvcDbContext();

            var department = from dept in context.Departments
                             select dept;

            return await department.ToListAsync();
        }
        public async Task<Department> GetByIdAsync(int id)
        {
            using var context = new MvcDbContext();
            var departmets = from dept in context.Departments
                             where dept.Id == id
                             select dept;
            return await departmets.SingleOrDefaultAsync();
        }

        public async Task CreateAsync(Department department)
        {
            using var context = new MvcDbContext();
            await context.Departments.AddAsync(department);
            await context.SaveChangesAsync();
        }

        public async Task EditAsync(Department department)
        {
            using var context = new MvcDbContext();
            context.Departments.Update(department);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            using var context = new MvcDbContext();

            var departmets = await
                (from department in context.Departments
                 where department.Id == id
                 select department).SingleAsync();

            context.Departments.Remove(departmets);

            await context.SaveChangesAsync();
        }
    }
}
