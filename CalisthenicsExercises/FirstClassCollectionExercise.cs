// Regla de calistenia: Colecciones de primera clase
// EJEMPLO DE VIOLACIÓN: Se pasa una colección cruda con lógica de dominio en cualquier parte

using System.Collections.Generic;
using System.Linq;

namespace CalisthenicsExercises
{
    // Traducción directa: mantener funciones que operan sobre List<Product>
    public class Product
    {
        public string id;
        public double price;
    }

    public static class FirstClassCollectionExercise
    {
        // Efectos secundarios sobre la lista cruda
        public static void AddProduct(List<Product> products, Product product)
        {
            var exists = products.Any(p => p.id == product.id);
            if (!exists) products.Add(product);
        }

        // Todo el mundo reimplementa reglas de negocio sobre listas
        public static double TotalPrice(List<Product> products)
        {
            return products.Select(p => p.price).Aggregate(0.0, (a, b) => a + b);
        }
    }

    /*
    Ejercicio (refactorizar hacia la regla):
    - Introducir un tipo de colección de primera clase Products con la lista oculta dentro:
      1) Encapsular los comportamientos.
      2) Exponer la iteración mediante métodos.
      3) Prohibir la mutación externa.
    - Aceptación: Ninguna función del módulo manipula directamente List<Product> cruda; todas pasan por la clase Products.
    */
}
