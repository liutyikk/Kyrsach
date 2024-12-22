using Kyrsach.Entities;
using Kyrsach.Repository;

namespace Kyrsach.Service;

public class PurchaseHistoryService : IPurchaseHistoryService
{
    private readonly IProductRepository _productRepository;
    private readonly IPurchaseHistoryRepository _purchaseHistoryRepository;

    public PurchaseHistoryService(IProductRepository productRepository, IPurchaseHistoryRepository purchaseHistoryRepository)
    {
        _productRepository = productRepository;
        _purchaseHistoryRepository = purchaseHistoryRepository;
    }

    public void PurchaseProduct(User user, int productId, int quantity)
    {
        var product = _productRepository.Read(productId);
        if (product == null || product.Quantity < quantity)
        {
            throw new Exception("Product not available or insufficient quantity.");
        }

        var totalCost = product.Price * quantity;
        if (user.Balance < totalCost)
        {
            throw new Exception("Insufficient balance.");
        }

        user.Balance -= totalCost;
        product.Quantity -= quantity;
        _productRepository.Update(product);

        var purchase = new PurchaseHistory
        {
            Id = _purchaseHistoryRepository.ReadByUserId(user.Id).Count + 1,
            UserId = user.Id,
            ProductId = productId,
            Quantity = quantity,
            PurchaseDate = DateTime.Now
        };

        _purchaseHistoryRepository.Create(purchase);
    }

    public List<PurchaseHistory> GetPurchaseHistory(User user) => _purchaseHistoryRepository.ReadByUserId(user.Id);
}