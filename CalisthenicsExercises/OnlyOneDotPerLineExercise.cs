// Regla de calistenia: Solo un punto por línea
// EJEMPLO DE VIOLACIÓN: Envidia de funciones y cadenas largas

using System.Collections.Generic;
using System.Linq;

namespace CalisthenicsExercises
{
    public static class OnlyOneDotPerLineExercise
    {
        // Traducción directa manteniendo cadenas de métodos con muchos puntos
        public static string LastCityInUpper(List<PersonLike> people)
        {
            // ¡múltiples puntos en una sola cadena!
            return people
                .Where(p => p.Address != null && p.Address.City != null)
                .Select(p => p.Address.City)
                .Where(c => c.Length > 0)
                .Last()
                .ToUpper();
        }
    }

    public class PersonLike
    {
        public Address Address { get; set; }
    }

    public class Address
    {
        public string City { get; set; }
    }

    /*
    Ejercicio (refactorizar hacia la regla):
    - Romper las cadenas de métodos moviendo lógica a objetos/funciones de dominio:
    - Aceptación: Ninguna línea contiene más de un operador punto; las responsabilidades están mejor distribuidas.
    */
}
