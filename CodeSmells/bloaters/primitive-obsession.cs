// Code smell: Primitive Obsession [Obsesión por primitivos]. Conceptos de dominio (email, dinero, dirección) se modelan
// con primitivos crudos, esparciendo reglas de validación/formateo por todo el código.

// Ejercicio: Soporta múltiples monedas y valida direcciones por país.

// Terminarás encadenando strings y números con comprobaciones ad‑hoc por todas partes,
// haciendo que una característica simple requiera cambios amplios e inconsistentes.

using System;

namespace CodeSmells.Bloaters
{
    // Traducción directa preservando primitivos desnudos y validación ad-hoc
    public class Order
    {
        private string customerName;
        private string customerEmail;
        private string address;
        private double totalAmount;
        private string currency;

        public Order(string customerName, string customerEmail, string address, double totalAmount, string currency)
        {
            this.customerName = customerName;
            this.customerEmail = customerEmail;
            this.address = address;
            this.totalAmount = totalAmount;
            this.currency = currency;
        }

        public void SendInvoice()
        {
            if (!this.customerEmail.Contains("@"))
            {
                throw new Exception("Email inválido");
            }
            if (this.totalAmount <= 0)
            {
                throw new Exception("El monto debe ser mayor que cero");
            }
            Console.WriteLine($"Factura enviada a {this.customerEmail} por {this.totalAmount} {this.currency}");
        }
    }
}
