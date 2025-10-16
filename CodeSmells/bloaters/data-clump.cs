// Code smell: Data Clump [Grupo de datos].
// El mismo grupo de campos de datos viaja junto por muchos lugares,
// lo que sugiere un Value Object faltante y duplicación.

// Ejercicio: Añade país/provincia y reglas de formateo internacional.

// Necesitarás modificar constructores, impresores y cualquier lugar que pase estos campos juntos,
// multiplicando la superficie de cambio.

using System;

namespace CodeSmells.Bloaters
{
    // Traducción directa desde TypeScript preservando el "data clump"
    public class Invoice
    {
        private string customerName;
        private string customerStreet;
        private string customerCity;
        private string customerZip;

        public Invoice(string customerName, string customerStreet, string customerCity, string customerZip)
        {
            this.customerName = customerName;
            this.customerStreet = customerStreet;
            this.customerCity = customerCity;
            this.customerZip = customerZip;
        }

        public void Print()
        {
            Console.WriteLine($"Factura para: {this.customerName}");
            Console.WriteLine($"Dirección: {this.customerStreet}, {this.customerCity}, {this.customerZip}");
        }
    }

    public class ShippingLabel
    {
        private string customerName;
        private string customerStreet;
        private string customerCity;
        private string customerZip;

        public ShippingLabel(string customerName, string customerStreet, string customerCity, string customerZip)
        {
            this.customerName = customerName;
            this.customerStreet = customerStreet;
            this.customerCity = customerCity;
            this.customerZip = customerZip;
        }

        public void Print()
        {
            Console.WriteLine($"Enviar a: {this.customerName}");
            Console.WriteLine($"{this.customerStreet}, {this.customerCity}, {this.customerZip}");
        }
    }
}
