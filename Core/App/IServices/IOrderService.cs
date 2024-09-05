using Core.App.Dto.OrderDTO;

namespace Core.App.IServices;
public interface IOrderService
{
    OrderDto CreateOrder(CreateUpdateOrderDto createOrderDto);
    OrderDto GetOrderById(Guid orderId);
    IEnumerable<OrderDto> GetAllOrders();
    void UpdateOrder(Guid orderId, CreateUpdateOrderDto updateOrderDto);
    void DeleteOrder(Guid orderId);
}
