using Microsoft.EntityFrameworkCore;
using OrderService.ApplicationCore.Entities;
using OrderService.ApplicationCore.Repositories;
using OrderService.Infrastructure.Data;

namespace OrderService.Infrastructure.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(OrderDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ICollection<UserAddress>> GetCustomerAddress(int id)
        {
            return await _DbContext
                .UserAddresses
                .Include(a => a.Address)
                .Where(a => a.CustomerId == id).ToListAsync();
        }

        public async Task<bool> SaveCustomerAddress(Address address, UserAddress ua)
        {
            _DbContext.Set<Address>().Add(address);
            _DbContext.Set<UserAddress>().Add(ua);
            await _DbContext.SaveChangesAsync();
            return true;
        }
    }   
    
    
}
