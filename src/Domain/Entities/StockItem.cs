namespace GMAO.Domain.Entities;

public class StockItem
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public int Quantity { get; private set; }

    private StockItem() {}

    private StockItem(Guid id, string name, int quantity)
    {
        Id = id;
        Name = name;
        Quantity = quantity;
    }

    public static StockItem Create(Guid id, string name, int quantity)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required", nameof(name));
        if (quantity < 0)
            throw new ArgumentException("Quantity cannot be negative", nameof(quantity));
        return new StockItem(id, name, quantity);
    }
}
