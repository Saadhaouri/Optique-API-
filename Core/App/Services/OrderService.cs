using AutoMapper;
using Core.App.Dto.OrderDTO;
using Core.App.Interfaces;
using Core.App.IServices;
using Optique_Domaine.Entities;

namespace Core.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public OrderDto CreateOrder(CreateUpdateOrderDto createOrderDto)
        {
            var order = _mapper.Map<Order>(createOrderDto);
            order.Id = Guid.NewGuid();
            order.OrderDate = DateTime.UtcNow;

            var addedOrder = _orderRepository.AddOrder(order, createOrderDto.ProductIds);

            return _mapper.Map<OrderDto>(addedOrder);
        }

        public OrderDto GetOrderById(Guid orderId)
        {
            var order = _orderRepository.GetOrderById(orderId);

            if (order == null)
                throw new ArgumentNullException(nameof(order));

            return _mapper.Map<OrderDto>(order);
        }

        public IEnumerable<OrderDto> GetAllOrders()
        {
            var orders = _orderRepository.GetAllOrders();
            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }

        public void UpdateOrder(Guid orderId, CreateUpdateOrderDto updateOrderDto)
        {
            var order = _orderRepository.GetOrderById(orderId);

            if (order == null)
                throw new ArgumentNullException(nameof(order));

            // Map the updated properties to the existing order
            order.FournisseurId = updateOrderDto.FournisseurId;
            
            order.Status = updateOrderDto.Status;
            order.TotalAmount = updateOrderDto.TotalAmount;

            // Update OrderProducts
            order.OrderProducts.Clear();
            foreach (var productId in updateOrderDto.ProductIds)
            {
                order.OrderProducts.Add(new OrderProduct { OrderId = order.Id, ProductId = productId });
            }

            _orderRepository.UpdateOrder(order, updateOrderDto.ProductIds);
        }

        public void DeleteOrder(Guid orderId)
        {
            _orderRepository.DeleteOrder(orderId);
        }
    }
}
