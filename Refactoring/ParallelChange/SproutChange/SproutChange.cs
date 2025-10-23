using System;
using System.Collections.Generic;
using System.Linq;

public class CartItem
{
    public string Id { get; set; }
    public double Price { get; set; }
    public int Qty { get; set; }
    public string? Category { get; set; } // 'general' | 'books' | 'food'
}

public enum Region
{
    US,
    EU
}

// Regla existente: un único impuesto plano por región; los libros y la comida están exentos en la UE
// (reglas embebidas en línea)
public class TaxCalculator
{
    public static double CalculateTotal(List<CartItem> cart, Region region)
    {
        double subtotal = cart.Sum(it => it.Price * it.Qty);

        double tax = 0;
        if (region == Region.US)
        {
            tax = subtotal * 0.07; // 7% plano
        }
        else if (region == Region.EU)
        {
            // exenciones ingenuas en línea
            double taxable = cart
                .Where(it => it.Category != "books" && it.Category != "food")
                .Sum(it => it.Price * it.Qty);
            tax = taxable * 0.2; // 20% plano solo sobre los ítems gravables
        }

        return RoundCurrency(subtotal + tax);
    }

    public static double RoundCurrency(double amount)
    {
        return Math.Round(amount * 100) / 100;
    }

    // Uso de ejemplo, mantenido simple para estudiantes
    public static double DemoSprout()
    {
        var cart = new List<CartItem>
        {
            new CartItem { Id = "p1", Price = 10, Qty = 2, Category = "general" },
            new CartItem { Id = "b1", Price = 20, Qty = 1, Category = "books" }
        };
        return CalculateTotal(cart, Region.EU);
    }
}
