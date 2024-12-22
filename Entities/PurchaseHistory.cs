namespace Kyrsach.Entities;

public class PurchaseHistory
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public DateTime PurchaseDate { get; set; }
}