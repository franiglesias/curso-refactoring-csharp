// Este archivo demuestra el code smell "Duplicated Code [Código duplicado]".
// Dos funciones abajo realizan la misma lógica con solo pequeñas diferencias en los nombres.

// Ejercicio: Cambia la regla de impuestos a escalonada (p. ej., 10% hasta $100 y 21% por encima).

// Tendrás que actualizar múltiples implementaciones duplicadas y recordar mantenerlas
// consistentes, mostrando cómo la duplicación multiplica el esfuerzo y el riesgo.

using System;
using System.Collections.Generic;

namespace CodeSmells.Dispensables
{
    public static class DuplicatedCode
    {
        public static double CalculateOrderTotalWithTax(List<ItemA> items, double taxRate)
        {
            double subtotal = 0;
            foreach (var item in items)
            {
                subtotal += item.price * item.qty;
            }
            var tax = subtotal * taxRate;
            return subtotal + tax;
        }

        // Versión duplicada con diferencias menores en nombres pero lógica idéntica.
        public static double ComputeCartTotalIncludingTax(List<ItemB> products, double taxRate)
        {
            double partial = 0;
            foreach (var p in products)
            {
                partial += p.price * p.quantity;
            }
            var tax = partial * taxRate;
            return partial + tax;
        }

        // Ejemplo de uso que (innecesariamente) llama a ambas implementaciones duplicadas
        public static (double, double) DemoDuplicatedCode()
        {
            var itemsA = new List<ItemA>
            {
                new ItemA { price = 10, qty = 2 },
                new ItemA { price = 5, qty = 3 },
            };
            var itemsB = new List<ItemB>
            {
                new ItemB { price = 10, quantity = 2 },
                new ItemB { price = 5, quantity = 3 },
            };
            return (
                CalculateOrderTotalWithTax(itemsA, 0.21),
                ComputeCartTotalIncludingTax(itemsB, 0.21)
            );
        }
    }

    public class ItemA { public double price; public int qty; }
    public class ItemB { public double price; public int quantity; }
}
