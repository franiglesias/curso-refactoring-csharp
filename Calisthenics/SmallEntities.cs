namespace CursoRefactoring.Calisthenics;

public class OrderItem
{
    public string Name { get; }
    public decimal Price { get; }
    public int Quantity { get; }

    public OrderItem(string name, decimal price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public decimal GetTotal()
    {
        return Price * Quantity;
    }
}

public class Order
{
    private readonly List<OrderItem> items = new();
    private decimal discount = 0;

    public void AddItem(string name, decimal price, int quantity)
    {
        items.Add(new OrderItem(name, price, quantity));
    }

    public void SetDiscount(decimal discount)
    {
        this.discount = discount;
    }

    public decimal CalculateTotal()
    {
        decimal total = 0;
        foreach (var item in items)
        {
            total += item.GetTotal();
        }
        return total - discount;
    }

    public void PrintInvoice()
    {
        Console.WriteLine("INVOICE");
        foreach (var item in items)
        {
            Console.WriteLine($"{item.Name} x{item.Quantity}: ${item.GetTotal()}");
        }
        Console.WriteLine($"Discount: ${discount}");
        Console.WriteLine($"Total: ${CalculateTotal()}");
    }
}