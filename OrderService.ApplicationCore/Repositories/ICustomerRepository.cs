using OrderService.ApplicationCore.Entities;
using OrderService.ApplicationCore.Models;

namespace OrderService.ApplicationCore.Repositories
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        public Task<ICollection<UserAddress>> GetCustomerAddress(int id);
        public Task<bool> SaveCustomerAddress(Address address, UserAddress ua);
    }
}
