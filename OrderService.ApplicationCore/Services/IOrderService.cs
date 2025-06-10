using OrderService.ApplicationCore.Entities;
using OrderService.ApplicationCore.Models;

namespace OrderService.ApplicationCore.Services
{
    public interface IOrderService
    {
        public Task<ICollection<CustomerModel>> GetCustomerAddressById(int id);
        public Task<bool> SaveCustomerAddress(CustomerModel model, int CustId);


        public Task<ICollection<OrderViewModel>> GetAllOrders(int page);
        public Task<bool> SaveOrder(OrderRequestModel order);
        public Task<ICollection<OrderViewModel>> CheckOrderHistory(int id);
        public Task<OrderViewModel> CheckOrderStatus(int orderId);
        public Task<OrderViewModel> CancelOrder(int orderId);
        public Task<OrderViewModel> AddCompletedOrder(OrderRequestModel order);
        public Task<OrderViewModel> UpdateOrder(OrderRequestModel order, int Id);
        public OrderViewModel OrderEntityToModel(Order order);


        public Task<ICollection<PaymentModel>> GetPaymentMethodByCustId(int id);
        public Task<PaymentModel> SavePayment(PaymentModel model);
        public Task<PaymentModel> DeletePayment(int id);
        public Task<PaymentModel> UpdatePayment(PaymentModel model);


        public Task<ICollection<ShoppingCartItemModel>> GetCartByCustId(int customerId);
        public Task<ShoppingCartItemModel> SaveCart(ShoppingCartItemModel model);
        public Task<bool> DeleteCart(int customerId);

        public Task<ShoppingCartItemModel> DeleteCartItem(int id);



    }
}
