namespace CursoRefactoring.Calisthenics;

public class Order
{
    public bool IsValid() => true; // Placeholder implementation
    public bool IsPaid() => false; // Placeholder implementation
    public bool HasStock() => true; // Placeholder implementation
    public void Pay() { } // Placeholder implementation
}

public class OrderProcessor
{
    public static void ProcessOrder(Order order)
    {
        if (order.IsValid())
        {
            if (!order.IsPaid())
            {
                if (order.HasStock())
                {
                    order.Pay();
                    Console.WriteLine("Order processed successfully");
                }
                else
                {
                    Console.WriteLine("Out of stock");
                }
            }
            else
            {
                Console.WriteLine("Order already paid");
            }
        }
        else
        {
            Console.WriteLine("Invalid order");
        }
    }
}