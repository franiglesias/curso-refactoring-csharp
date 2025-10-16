// Translated from CalisthenicsExamples/small-entities.ts
// Breaks responsibilities into small entities: Order, Items, Item, Discount
using System;
using System.Collections.Generic;

namespace CalisthenicsExamples
{
    public class Order
    {
        private Items items = new Items(new List<Item>());
        private Discount discount = new Discount(0);

        public void AddItem(string name, decimal price, int quantity)
        {
            this.items.AddItem(name, price, quantity);
        }

        public void SetDiscount(decimal discount)
        {
            this.discount = new Discount(discount);
        }

        public decimal CalculateTotal()
        {
            var total = this.items.CalculateTotal();
            return this.discount.ApplyTo(total);
        }

        public void PrintInvoice()
        {
            Console.WriteLine("INVOICE");
            this.items.Print();
            this.discount.Print();
            Console.WriteLine($"Total: ${this.CalculateTotal()}");
        }
    }

    public class Item
    {
        private string name;
        private decimal price;
        private int quantity;

        public Item(string name, decimal price, int quantity)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;
        }

        public void Print()
        {
            Console.WriteLine($"{this.name} x{this.quantity}: ${this.price * this.quantity}");
        }

        public decimal Amount()
        {
            return this.price * this.quantity;
        }
    }

    public class Items
    {
        private List<Item> items;
        public Items(List<Item> items)
        {
            this.items = items;
        }

        public void AddItem(string name, decimal price, int quantity)
        {
            this.items.Add(new Item(name, price, quantity));
        }

        public decimal CalculateTotal()
        {
            decimal total = 0;
            foreach (var item in this.items)
            {
                total += item.Amount();
            }
            return total;
        }

        public void Print()
        {
            foreach (var item in this.items)
            {
                item.Print();
            }
        }
    }

    public class Discount
    {
        private decimal amount;
        public Discount(decimal amount)
        {
            this.amount = amount;
        }

        public void Print()
        {
            Console.WriteLine($"Discount: ${this.amount}");
        }

        public decimal ApplyTo(decimal total)
        {
            return total - this.amount;
        }
    }
}
