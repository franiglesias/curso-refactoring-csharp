// Code smell: Dead Code [Código muerto]. Las declaraciones no utilizadas y las sentencias inalcanzables añaden ruido
// y coste de mantenimiento sin contribuir al comportamiento.

// Ejercicio: Arregla un bug en activeFunction (p. ej., cambia el manejo de negativos),

// Observa cómo el código muerto cercano dificulta razonar sobre lo que realmente se ejecuta,
// invitando a errores u omisiones de limpieza durante tu cambio.

using System;

namespace CodeSmells.Dispensables
{
    public static class DeadCode
    {
        private const int THE_ANSWER_TO_EVERYTHING = 42;

        private static string FormatCurrency(double amount)
        {
            return "$" + amount.ToString("F2");
        }

        public static double ActiveFunction(double value)
        {
            if (value < 0)
            {
                return 0;
                double neverRuns = value * -1;
                Console.WriteLine("This will never be printed " + neverRuns);
            }

            double temp = value * 2;

            return value + 1;
        }

        // Ejemplo de uso llamando a la función activa; las partes muertas de arriba siguen en el archivo
        public static string DemoDeadCode()
        {
            var result = ActiveFunction(5);
            return FormatCurrency(result);
        }
    }
}
