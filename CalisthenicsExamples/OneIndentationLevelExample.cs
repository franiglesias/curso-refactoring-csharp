// Translated from CalisthenicsExamples/one-indentation-level.ts
// Keeps early returns and simple processing logic
using System;

namespace CalisthenicsExamples
{
    public interface IOrder
    {
        bool IsValid();
        bool IsPaid();
        bool HasStock();
        void Pay();
    }

    public static class OrderProcessor
    {
        public static void ProcessOrder(IOrder order)
        {
            if (!order.IsValid())
            {
                Console.WriteLine("Invalid order");
                return;
            }
            if (order.IsPaid())
            {
                Console.WriteLine("Order already paid");
                return;
            }
            if (!order.HasStock())
            {
                Console.WriteLine("Out of stock");
                return;
            }

            order.Pay();
            Console.WriteLine("Order processed successfully");
        }
    }
}
