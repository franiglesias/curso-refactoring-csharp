// Regla de calistenia: Un solo nivel de indentación por método
// EJEMPLO DE VIOLACIÓN: Múltiples bloques if/for anidados (3+ niveles)

using System.Collections.Generic;

namespace CalisthenicsExercises
{
    public static class OneIndentationLevelExercise
    {
        // Traducción directa con múltiples niveles de indentación
        public static double ProcessOrdersWithDiscounts(List<Order> orders)
        {
            double total = 0;
            foreach (var order in orders)
            {
                // nivel 1
                if (order.Items != null && order.Items.Count > 0)
                {
                    // nivel 2
                    foreach (var item in order.Items)
                    {
                        // nivel 3
                        if (order.Customer != null && order.Customer.IsVip)
                        {
                            // nivel 4
                            if (item.Price > 100)
                            {
                                // nivel 5
                                total += item.Price * 0.8; // gran descuento VIP
                            }
                            else
                            {
                                total += item.Price * 0.9; // pequeño descuento VIP
                            }
                        }
                        else
                        {
                            if (item.Price > 100)
                            {
                                total += item.Price * 0.95; // gran descuento regular
                            }
                            else
                            {
                                total += item.Price; // sin descuento
                            }
                        }
                    }
                }
            }
            return total;
        }
    }

    // Tipos de apoyo mínimos para reflejar las estructuras anónimas de TypeScript
    public class Order
    {
        public List<Item> Items { get; set; }
        public Customer Customer { get; set; }
    }

    public class Item
    {
        public double Price { get; set; }
    }

    public class Customer
    {
        public bool IsVip { get; set; }
    }

    /*
    Ejercicio (refactorizar hacia la regla):
    - Objetivo: Reducir a un solo nivel de indentación por función.
    - Pasos:
      1) Introducir cláusulas de guarda: retornar temprano cuando orders esté vacío, cuando un pedido no tenga items, etc.
      2) Extraer funciones: priceWithVipDiscount, priceWithRegularDiscount, isVipCustomer.
      3) Reemplazar cadenas de if anidados con polimorfismo o un mapa de estrategias (p. ej., DiscountPolicy).
      4) Aplanar bucles: usar map/reduce cuando sea apropiado para evitar anidamiento.
    - Aceptación: Ningún cuerpo de función debe tener más de un bloque de indentación.
    */
}
