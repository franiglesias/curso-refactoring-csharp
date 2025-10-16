// Code smell: Long Method [Método largo]. El método process mezcla validación, cálculo, descuentos,
// persistencia simulada, envío de emails e impresión en un solo bloque largo.
// Esto dificulta leerlo, probarlo y cambiar una parte sin arriesgar las demás.
//
// Exercise: Añade soporte de cupones con expiración y multi‑moneda (USD/EUR) con
// reglas de redondeo distintas.
//
// Verás que tienes que tocar múltiples secciones dentro de este método largo
// (validación, cálculo, descuentos, salida), aumentando el riesgo y el esfuerzo.

using System;
using System.Collections.Generic;

namespace CodeSmells.Bloaters
{
    // Traducción directa preservando el método largo
    public class OrderService
    {
        public void Process(Order order)
        {
            // Validar el pedido
            if (order.Items == null || order.Items.Count == 0)
            {
                Console.WriteLine("El pedido no tiene productos");
                return;
            }

            // Calcular total
            double total = 0;
            foreach (var item in order.Items)
            {
                total += item.Price * item.Quantity;
            }

            // Aplicar descuento si el cliente es VIP
            if (order.CustomerType == "VIP")
            {
                total *= 0.9;
                Console.WriteLine("Descuento VIP aplicado");
            }

            // Registrar en la base de datos (simulado)
            Console.WriteLine($"Guardando pedido con total {total}");

            // Enviar correo de confirmación
            Console.WriteLine($"Enviando correo a {order.CustomerEmail}");

            // Imprimir resumen
            Console.WriteLine("Resumen del pedido:");
            foreach (var item in order.Items)
            {
                Console.WriteLine($"{item.Name} x{item.Quantity} = ${item.Price * item.Quantity}");
            }

            Console.WriteLine($"Total final: ${total}");
        }
    }

    public class Order
    {
        public string CustomerEmail { get; set; }
        public string CustomerType { get; set; } // 'NORMAL' | 'VIP' (no modelado como enum intencionalmente)
        public List<OrderItem> Items { get; set; }
    }

    public class OrderItem
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }

    // Ejemplo de uso que expone los problemas al usar esta clase tal cual:
    // cambiar el cálculo o la salida obliga a reejecutar todo el flujo monolítico.
    public static class LongMethodDemo
    {
        public static void DemoLongMethod()
        {
            var service = new OrderService();
            var order = new Order
            {
                CustomerEmail = "cliente@example.com",
                CustomerType = "VIP",
                Items = new List<OrderItem>
                {
                    new OrderItem { Name = "Producto A", Price = 10, Quantity = 2 },
                    new OrderItem { Name = "Producto B", Price = 5, Quantity = 1 },
                }
            };
            service.Process(order);
        }
    }
}
