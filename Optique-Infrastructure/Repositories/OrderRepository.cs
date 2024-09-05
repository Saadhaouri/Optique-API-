using Core.App.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Optique_Domaine.Entities;
namespace Infra.Repository;

public class OrderRepository : IOrderRepository
{
    private readonly OpDbContext _context;

    public OrderRepository(OpDbContext context)
    {
        _context = context;
    }

    public Order AddOrder(Order order, List<Guid> productIds)
    {
        _context.Orders.Add(order);

        foreach (var productId in productIds)
        {
            _context.OrderProducts.Add(new OrderProduct { Order = order, ProductId = productId });
        }

        _context.SaveChanges();
        return order;
    }

    public Order GetOrderById(Guid orderId)
    {
        return _context.Orders
            .Include(o => o.OrderProducts)
            .FirstOrDefault(o => o.Id == orderId) ?? throw new Exception(" Order not found ");
    }

    public IEnumerable<Order> GetAllOrders()
    {
        return _context.Orders
            .Include(o => o.OrderProducts)
            .ToList();
    }

    public void UpdateOrder(Order order, List<Guid> productIds)
    {
        var existingOrder = _context.Orders
           .Include(o => o.OrderProducts)
           .FirstOrDefault(o => o.Id == order.Id);

        if (existingOrder != null)
        {
            // Update order details
            existingOrder.FournisseurId = order.FournisseurId;
            existingOrder.OrderDate = order.OrderDate;
            existingOrder.TotalAmount = order.TotalAmount;
            existingOrder.Status = order.Status;
      
            // Detach existing order products to avoid tracking issues
            foreach (var op in existingOrder.OrderProducts.ToList())
            {
                var trackedEntity = _context.OrderProducts.Local
                    .FirstOrDefault(ep => ep.OrderId == op.OrderId && ep.ProductId == op.ProductId);
                if (trackedEntity != null)
                {
                    _context.Entry(trackedEntity).State = EntityState.Detached;
                }
            }

            // Clear existing order products
            _context.OrderProducts.RemoveRange(existingOrder.OrderProducts);

            // Add new order products
            foreach (var productId in productIds)
            {
                var newOrderProduct = new OrderProduct { OrderId = existingOrder.Id, ProductId = productId };

                var trackedEntity = _context.OrderProducts.Local
                    .FirstOrDefault(op => op.OrderId == newOrderProduct.OrderId && op.ProductId == newOrderProduct.ProductId);
                if (trackedEntity != null)
                {
                    _context.Entry(trackedEntity).State = EntityState.Detached;
                }

                _context.OrderProducts.Add(newOrderProduct);
            }

            _context.SaveChanges();
        }
    }

    public void DeleteOrder(Guid orderId)
    {
        var order = _context.Orders
            .Include(o => o.OrderProducts)  // Include related OrderProducts
            .FirstOrDefault(o => o.Id == orderId);

        if (order != null)
        {
            // Remove related OrderProducts first
            _context.OrderProducts.RemoveRange(order.OrderProducts);

            // Now remove the order
            _context.Orders.Remove(order);

            _context.SaveChanges();
        }
    }

}
