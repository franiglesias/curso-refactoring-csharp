namespace CursoRefactoring.Refactoring.GoldenMaster
{

// Técnica de pruebas: Golden Master
// Propósito: Capturar el comportamiento ACTUAL de un sistema/función legado en un "maestro" (snapshot)
// para poder refactorizar con seguridad, detectando cualquier cambio accidental en la salida.
//
// Escenario: Tenemos una función legada que imprime un recibo de compra con formato de texto. Este código
// mezcla lógica, formato y dependencias de tiempo/aleatoriedad, lo que dificulta crear una prueba precisa.
// Practicaremos cómo aplicar Golden Master para caracterizar el comportamiento sin entender todo el código.
//
// Idea clave: Genera muchas entradas representativas, ejecuta la función, captura su salida exacta y
// congélala como "master". En futuras ejecuciones, compara contra el master para detectar regresiones.
// Si hay fuentes de no-determinismo (fecha/hora, aleatoriedad), introdúcete costuras (seams) para poder fijarlas.

public class OrderItem
{
    public string Sku { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public string? Category { get; set; } // "general", "food", "books"
}

public class Order
{
    public string Id { get; set; } = string.Empty;
    public string CustomerName { get; set; } = string.Empty;
    public OrderItem[] Items { get; set; } = Array.Empty<OrderItem>();
}

// "Código legado" intencionalmente enredado con dependencias de tiempo y aleatoriedad.
public class ReceiptPrinter
{
    // NO cambies esta función al inicio del ejercicio; primero crea el Golden Master.
    public string Print(Order order)
    {
        // Dependencia de tiempo (no determinista): la fecha actual cambia en cada ejecución
        var now = DateTime.Now;

        // Encabezado con fecha/hora local (esto varía según zona horaria/locale)
        var header = $"Recibo {order.Id} - {now:yyyy-MM-dd} {now:HH:mm:ss}";

        // Cálculo de subtotal
        decimal subtotal = 0;
        var lines = order.Items.Select((item, idx) =>
        {
            var lineTotal = Round(item.UnitPrice * item.Quantity);
            subtotal = Round(subtotal + lineTotal);
            // Formato deliberadamente frágil: números con formato, espacios, índices, etc.
            return $"{idx + 1}. {item.Description} ({item.Sku}) x{item.Quantity} = ${lineTotal:F2}";
        }).ToArray();

        // Regla con aleatoriedad (no determinista): "descuento de la suerte" con probabilidad 10%
        // y porcentaje aleatorio hasta 5%.
        var random = new Random();
        decimal luckyDiscountPct = 0;
        if (random.NextDouble() < 0.1)
        {
            luckyDiscountPct = (decimal)(random.NextDouble() * 0.05);
        }
        var luckyDiscount = Round(subtotal * luckyDiscountPct);

        // Impuesto ingenuo: 7% general, libros exentos, comida 3%
        var taxableGeneral = order.Items
            .Where(i => i.Category != "books")
            .Sum(i => i.Category == "food" ? 0 : i.UnitPrice * i.Quantity);
        var foodTax = order.Items
            .Where(i => i.Category == "food")
            .Sum(i => i.UnitPrice * i.Quantity * 0.03m);
        var generalTax = taxableGeneral * 0.07m;
        var taxes = Round(generalTax + foodTax);

        var total = Round(subtotal - luckyDiscount + taxes);

        // Pie con resumen. Observa el orden y los formatos: parte de la superficie del Golden Master.
        var summary = new[]
        {
            $"Subtotal: ${subtotal:F2}",
            luckyDiscount > 0
                ? $"Descuento de la suerte: -${luckyDiscount:F2} ({(luckyDiscountPct * 100):F2}%)"
                : "Descuento de la suerte: $0.00 (0.00%)",
            $"Impuestos: ${taxes:F2}",
            $"TOTAL: ${total:F2}"
        };

        return string.Join("\n", new[] { header }.Concat(lines).Concat(new[] { "---" }).Concat(summary));
    }

    private static decimal Round(decimal n)
    {
        return Math.Round(n, 2);
    }
}

public static class GoldenMasterHelper
{
    private static readonly OrderItem[] Products =
    {
        new() { Sku = "BK-001", Description = "Libro: Clean Code", UnitPrice = 30, Category = "books" },
        new() { Sku = "FD-010", Description = "Café en grano 1kg", UnitPrice = 12.5m, Category = "food" },
        new() { Sku = "GN-777", Description = "Cuaderno A5", UnitPrice = 5.2m, Category = "general" },
        new() { Sku = "GN-123", Description = "Bolígrafos (pack 10)", UnitPrice = 3.9m, Category = "general" },
        new() { Sku = "FD-222", Description = "Té verde 200g", UnitPrice = 6.75m, Category = "food" }
    };

    private static readonly string[] Customers = { "Ana", "Luis", "Mar", "Iván", "Sofía" };

    // Utilidad para generar pedidos
    public static Order GenerateOrder(string id, string customerName, int numItems, int quantity)
    {
        var items = new OrderItem[numItems];
        for (int i = 0; i < numItems; i++)
        {
            var p = Products[i];
            items[i] = new OrderItem
            {
                Sku = p.Sku,
                Description = p.Description,
                UnitPrice = p.UnitPrice,
                Category = p.Category,
                Quantity = quantity
            };
        }

        return new Order { Id = id, CustomerName = customerName, Items = items };
    }

    // Utilidad para generar pedidos de ejemplo (también usa Random -> no determinista)
    public static Order GenerateRandomOrder(string id)
    {
        var random = new Random();
        var customerName = Customers[random.Next(Customers.Length)];
        var numItems = 2 + random.Next(3); // 2..4 ítems
        var items = new OrderItem[numItems];

        for (int i = 0; i < numItems; i++)
        {
            var p = Products[random.Next(Products.Length)];
            items[i] = new OrderItem
            {
                Sku = p.Sku,
                Description = p.Description,
                UnitPrice = p.UnitPrice,
                Category = p.Category,
                Quantity = 1 + random.Next(4) // 1..4 qty
            };
        }

        return new Order { Id = id, CustomerName = customerName, Items = items };
    }

    // Demostración mínima
    public static string DemoGoldenMaster()
    {
        var pedido = new Order
        {
            Id = "ORD-1",
            CustomerName = "Cliente Demo",
            Items = new[]
            {
                new OrderItem
                {
                    Sku = "BK-001",
                    Description = "Libro: Refactoring",
                    UnitPrice = 28.0m,
                    Quantity = 1,
                    Category = "books"
                },
                new OrderItem
                {
                    Sku = "GN-777",
                    Description = "Cuaderno A5",
                    UnitPrice = 5.25m,
                    Quantity = 3,
                    Category = "general"
                }
            }
        };
        return new ReceiptPrinter().Print(pedido);
    }
}

}
