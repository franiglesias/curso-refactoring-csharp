// Regla de calistenia: No más de 2 variables de instancia por clase
// EJEMPLO DE VIOLACIÓN: Demasiadas variables de instancia en una sola clase

using System;
using System.Collections.Generic;
using System.Linq;

namespace CalisthenicsExercises
{
    public class CheckoutSession
    {
        // 8 variables de instancia: claramente por encima del límite
        private List<CartItem> cartItems = new List<CartItem>();
        private string customerId = null; // string | null
        private string shippingAddress = null;
        private string billingAddress = null;
        private string couponCode = null;
        private string paymentMethod = null; // 'CARD' | 'PAYPAL' | null (no modelado)
        private string currency = "USD";
        private double taxRate = 0.21;

        public void AddItem(string id, double price, int qty)
        {
            this.cartItems.Add(new CartItem { id = id, price = price, qty = qty });
        }

        public double Total()
        {
            var subtotal = this.cartItems.Aggregate(0.0, (sum, i) => sum + i.price * i.qty);
            var discount = this.couponCode != null ? 10 : 0; // lógica de descuento primitiva
            var taxed = (subtotal - discount) * (1 + this.taxRate);
            return this.currency == "USD" ? taxed : taxed * 0.9; // conversión simulada
        }

        private class CartItem
        {
            public string id;
            public double price;
            public int qty;
        }
    }

    /*
    Ejercicio (refactorizar hacia la regla):
    - Reducir variables de instancia extrayendo objetos/entidades de valor cohesivos:
    - Aceptación: CheckoutSession no tiene más de 2 variables de instancia; la lógica se distribuye en tipos dedicados.
    */
}
