using OrderService.ApplicationCore.Entities;
using OrderService.ApplicationCore.Models;
using OrderService.ApplicationCore.Repositories;
using OrderService.ApplicationCore.Services;

namespace OrderService.Infrastructure.Services
{
    public class OrderServices : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IShoppingCartItemRepository _shoppingCartItemRepository;

        public OrderServices(
            IOrderRepository orderRepository, 
            ICustomerRepository customerRepository, 
            IPaymentRepository paymentRepository, 
            IShoppingCartRepository shoppingCartRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _paymentRepository = paymentRepository;
            _shoppingCartRepository = shoppingCartRepository;
        }

        public async Task<OrderViewModel> AddCompletedOrder(OrderRequestModel order)
        {
            Order val = new Order
            {
                CustomerId = order.CustomerId,
                OrderDate = DateTime.UtcNow,
                CustomerName = order.CustomerName,
                PaymentMethodId = order.PaymentMethodId,
                ShippingAddress = order.ShippingAddress,
                PaymentName = order.PaymentName,
                ShippingMethod = order.ShippingMethod,
                BillAmount = order.BillAmount,
                OrderStatus = "Completed"
            };
            var savedOrder = await _orderRepository.Insert(val);
            return OrderEntityToModel(savedOrder);

        }

        public async Task<OrderViewModel> CancelOrder(int orderId)
        {
            Order val = await _orderRepository.GetById(orderId);
            val.OrderStatus = "Cancelled";
            var updatedOrder = await _orderRepository.Update(val);
            return OrderEntityToModel(updatedOrder);
        }

        public async Task<ICollection<OrderViewModel>> CheckOrderHistory(int id)
        {
            var orders = await _orderRepository.GetUserOrderHistory(id);
            return orders.Select(o => OrderEntityToModel(o)).ToList();

        }

        public async Task<OrderViewModel> CheckOrderStatus(int orderId)
        {
            var order = await _orderRepository.GetById(orderId);
            if (order == null) 
            {
                return null;
            }
            return OrderEntityToModel(order);
        }

        public async Task<bool> DeleteCart(int customerId)
        {
            return await _shoppingCartRepository.DeleteCart(customerId);
        }

        public async Task<ShoppingCartItemModel> DeleteCartItem(int id)
        {
            var val = await _shoppingCartItemRepository.DeleteById(id);
            if (val == null)
            {
                return null;
            }
            return new ShoppingCartItemModel
            {
                Id = val.Id,
                Price = val.Price,
                CartId = val.CartId,
                ProductId = val.ProductId,
                ProductName = val.ProductName,  
                Qty = val.Qty
            };
        }

        public async Task<PaymentModel> DeletePayment(int id)
        {
            var val = await _paymentRepository.DeleteById(id);
            if (val == null)
            {
                return null;
            }
            return new PaymentModel
            {
                Id = val.Id,
                AccountNumber = val.AccountNumber,  
                Expiry = val.Expiry,
                IsDefault= val.IsDefault,
                PaymentTypeId = val.PaymentTypeId,
                Provider = val.Provider,
            };
        }

        public async Task<ICollection<OrderViewModel>> GetAllOrders(int page)
        {
            var val = await _orderRepository.GetAllOrders(page);
            return val.Select(o => OrderEntityToModel(o)).ToList();
        }

        public async Task<ICollection<ShoppingCartItemModel>> GetCartByCustId(int customerId)
        {
            var val = await _shoppingCartRepository.GetShoppingCartItemsByCustId(customerId);
            if (val == null || !val.Any())
            {
                return new List<ShoppingCartItemModel>();
            }
            var res = new List<ShoppingCartItemModel>();
            foreach (var item in val)
            {
                res.Add(new ShoppingCartItemModel
                {
                    Id = item.Id,
                    Price = item.Price,
                    CartId = item.CartId,
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    Qty = item.Qty
                });
            }
            return res;

        }

        public async Task<ICollection<CustomerModel>> GetCustomerAddressById(int id)
        {
            var val = await _customerRepository.GetCustomerAddress(id);
            if (val == null)
            {
                return null;
            }

            var res = new List<CustomerModel>();
            foreach (var v in val) {
                res.Add(new CustomerModel
                {
                    Address1 = v.Address.Street1,
                    Address2 = v.Address.Street2 ?? "",
                    City = v.Address.City,
                    ZipCode = v.Address.Zipcode,
                    Country = v.Address.Country,
                    State = v.Address.State,
                    FirstName = v.Customer.FirstName,
                    LastName = v.Customer.LastName,
                });
            }
            return res;
        }

        public async Task<ICollection<PaymentModel>> GetPaymentMethodByCustId(int id)
        {
            var val = await _orderRepository.GetCustPayments(id);
            if (val == null || !val.Any())
            {
                return new List<PaymentModel>();
            }
            var res = new List<PaymentModel>();
            foreach (var item in val)
            {
                res.Add(new PaymentModel
                {
                    Id = item.Id,
                    AccountNumber = item.AccountNumber,
                    Expiry = item.Expiry,
                    IsDefault = item.IsDefault,
                    PaymentTypeId = item.PaymentTypeId,
                    Provider = item.Provider
                });
            }
            return res;
        }

        public async Task<ShoppingCartItemModel> SaveCart(ShoppingCartItemModel model)
        {
            ShoppingCartItem val = new ShoppingCartItem
            {
                CartId = model.CartId,
                Price = model.Price,
                ProductId = model.ProductId,
                ProductName = model.ProductName,
                Qty = model.Qty
            };
            var savedItem = await _shoppingCartItemRepository.Insert(val);
            return new ShoppingCartItemModel
            {
                Id = savedItem.Id,
                CartId = savedItem.CartId,
                Price = savedItem.Price,
                ProductId = savedItem.ProductId,
                ProductName = savedItem.ProductName,
                Qty = savedItem.Qty
            };
        }

        public async Task<bool> SaveCustomerAddress(CustomerModel model,int CustId)
        {
            Address address = new Address
            {
                Street1 = model.Address1,
                Street2 = model.Address2,
                City = model.City,
                Zipcode = model.ZipCode,
                Country = model.Country,
                State = model.State
            };
            UserAddress ua = new UserAddress
            {
                Address = address,
                CustomerId = CustId,
            };
            var savedAddress = await _customerRepository.SaveCustomerAddress(address, ua);
            return savedAddress != null;
        }

        public async Task<bool> SaveOrder(OrderRequestModel order)
        {
            Order val = new Order
            {
                CustomerId = order.CustomerId,
                OrderDate = DateTime.UtcNow,
                CustomerName = order.CustomerName,
                PaymentMethodId = order.PaymentMethodId,
                ShippingAddress = order.ShippingAddress,
                PaymentName = order.PaymentName,
                ShippingMethod = order.ShippingMethod,
                BillAmount = order.BillAmount,
                OrderStatus = "Pending"
            };
            var savedOrder = await _orderRepository.Insert(val);
            return savedOrder != null;
        }

        public async Task<PaymentModel> SavePayment(PaymentModel model)
        {
           PaymentMethod val = new PaymentMethod { 
                AccountNumber = model.AccountNumber,
                Expiry = model.Expiry,
                IsDefault = model.IsDefault,
                PaymentTypeId = model.PaymentTypeId,
                Provider = model.Provider
            };
            var savedPayment = await _paymentRepository.Insert(val);
            if (savedPayment != null)
            {
                return new PaymentModel
                {
                    Id = savedPayment.Id,
                    AccountNumber = savedPayment.AccountNumber,
                    Expiry = savedPayment.Expiry,
                    IsDefault = savedPayment.IsDefault,
                    PaymentTypeId = savedPayment.PaymentTypeId,
                    Provider = savedPayment.Provider
                };
            }
            else
            {
                return null;
            }
        }

        public async Task<OrderViewModel> UpdateOrder(OrderRequestModel order, int Id)
        {
            var oldOrder = await _orderRepository.GetById(Id);
            if (oldOrder == null)
            {
                return null;
            }
            Order newOrder = new Order
            {
                Id = Id,
                CustomerId = oldOrder.CustomerId,
                OrderDate = oldOrder.OrderDate,
                CustomerName = order.CustomerName,
                PaymentMethodId = order.PaymentMethodId,
                ShippingAddress = order.ShippingAddress,
                PaymentName = order.PaymentName,
                ShippingMethod = order.ShippingMethod,
                BillAmount = order.BillAmount,
                OrderStatus = oldOrder.OrderStatus 
            };  

            var res = await _orderRepository.Update(newOrder);
            return OrderEntityToModel(res);
        }

        public async Task<PaymentModel> UpdatePayment(PaymentModel model)
        {
            PaymentMethod newPayment = new PaymentMethod
            {
                Id = model.Id,
                AccountNumber = model.AccountNumber,
                Expiry = model.Expiry,
                IsDefault = model.IsDefault,
                PaymentTypeId = model.PaymentTypeId,
                Provider = model.Provider
            };

            var res = await _paymentRepository.Update(newPayment);
            if (res != null)
            {
                return new PaymentModel
                {
                    Id = res.Id,
                    AccountNumber = res.AccountNumber,
                    Expiry = res.Expiry,
                    IsDefault = res.IsDefault,
                    PaymentTypeId = res.PaymentTypeId,
                    Provider = res.Provider
                };
            }
            else
            {
                return null;
            }

        }


        public OrderViewModel OrderEntityToModel(Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                CustomerName = order.CustomerName,
                ShippingAddress = order.ShippingAddress,
                ShippingMethod = order.ShippingMethod,
                OrderDate = order.OrderDate,
                BillAmount = order.BillAmount,
                OrderStatus = order.OrderStatus
            };
        }
    }
}
