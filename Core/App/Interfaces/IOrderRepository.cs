using Optique_Domaine.Entities;
using System;
using System.Collections.Generic;

namespace Core.App.Interfaces;

public interface IOrderRepository
{
    Order AddOrder(Order order, List<Guid> productIds);
    Order GetOrderById(Guid orderId);
    IEnumerable<Order> GetAllOrders();
    void UpdateOrder(Order order, List<Guid> productIds);
    void DeleteOrder(Guid orderId);
}
