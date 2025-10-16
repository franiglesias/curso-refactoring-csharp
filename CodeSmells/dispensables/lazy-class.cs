// Este archivo demuestra el code smell "Lazy Class [Clase perezosa]".

// Una clase que no aporta valor real: solo envuelve una operación trivial
// que podría ser una función. Mantenerla añade complejidad innecesaria.

// Ejercicio: Reescribir el código para poder deshacernos de la clase ShippingLabelBuilder.

using System;

namespace CodeSmells.Dispensables
{
    // Lazy class: podría ser reemplazada por una función
    public class ShippingLabelBuilder
    {
        public string Build(Address a)
        {
            return $"{a.name} — {a.line1}{(string.IsNullOrEmpty(a.city) ? string.Empty : ", " + a.city)}";
        }
    }

    public class Address { public string name; public string line1; public string city; }

    // Example usage
    public static class LazyClassDemo
    {
        public static void PrintShippingLabel()
        {
            var address = new Address
            {
                name = "John Doe",
                line1 = "123 Main St",
                city = "New York",
            };

            var labelBuilder = new ShippingLabelBuilder();
            var label = labelBuilder.Build(address);
            Console.WriteLine(label);
        }
    }
}
