// Code smell: Shotgun Surgery [Cirugía de escopeta]. La misma regla de impuestos está duplicada en muchas clases;
// cambiarla requiere ediciones en múltiples lugares.

// Ejercicio: Cambia el impuesto del 21% al 18.5% con redondeo a 2 decimales.

// Tendrás que buscar cada copia y asegurar un redondeo consistente en todas partes,
// destacando cómo la duplicación convierte un cambio pequeño en muchas ediciones arriesgadas.

using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeSmells.ChangePreventers
{
    public class PriceCalculator
    {
        public double TotalWithTax(List<LineItem> items)
        {
            var subtotal = items.Aggregate(0.0, (s, i) => s + i.price * i.qty);
            var tax = subtotal * 0.21;
            return subtotal + tax;
        }
    }

    public class InvoiceService
    {
        public double CreateTotal(List<LineItem> items)
        {
            var baseSum = items.Aggregate(0.0, (s, i) => s + i.price * i.qty);
            var vat = baseSum * 0.21;
            return baseSum + vat;
        }
    }

    public class SalesReport
    {
        public string Summarize(List<LineItem> items)
        {
            var sum = items.Aggregate(0.0, (s, i) => s + i.price * i.qty);
            var tax = sum * 0.21;
            var total = sum + tax;
            return $"total={total.ToString("F2")}";
        }
    }

    public class LoyaltyPoints
    {
        public int Points(List<LineItem> items)
        {
            var baseSum = items.Aggregate(0.0, (s, i) => s + i.price * i.qty);
            var withTax = baseSum + baseSum * 0.21;
            return (int)Math.Floor(withTax / 10);
        }
    }

    public class LineItem
    {
        public string name { get; set; }
        public double price { get; set; }
        public int qty { get; set; }
    }

    public static class ShotgunSurgeryDemo
    {
        public static (double, double) DemoShotgun(List<LineItem> items)
        {
            var calc = new PriceCalculator().TotalWithTax(items);
            var inv = new InvoiceService().CreateTotal(items);
            return (calc, inv);
        }
    }
}
