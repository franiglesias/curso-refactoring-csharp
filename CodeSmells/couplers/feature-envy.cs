// Code smell: Feature Envy [Envidia de características]. ShippingCalculator se mete en los datos de Customer para tomar
// decisiones, lo que indica que el comportamiento quizá debería pertenecer a Customer.

// Ejercicio: Añade envío gratis para clientes en ciertas ciudades y un recargo de fin de semana.

// Probablemente seguirás añadiendo condiciones dentro de ShippingCalculator que dependen de
// detalles internos de Customer, esparciendo reglas en el lugar equivocado y volviendo frágiles los cambios.

namespace CodeSmells.Couplers
{
    // Traducción directa preservando la envidia de características
    public class Customer
    {
        public string name;
        public string street;
        public string city;
        public string zip;

        public Customer(string name, string street, string city, string zip)
        {
            this.name = name;
            this.street = street;
            this.city = city;
            this.zip = zip;
        }
    }

    public class ShippingCalculator
    {
        public double Cost(Customer customer)
        {
            var @base = customer.zip.StartsWith("9") ? 10 : 20;
            var distant = customer.city.Length > 6 ? 5 : 0;
            return @base + distant;
        }
    }

    public static class FeatureEnvyDemo
    {
        public static double DemoFeatureEnvy(Customer c)
        {
            return new ShippingCalculator().Cost(c);
        }
    }
}
