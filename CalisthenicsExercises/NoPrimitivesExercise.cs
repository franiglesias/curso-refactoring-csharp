// Regla de calistenia: No usar primitivos (obsesión por primitivos)
// EJEMPLO DE VIOLACIÓN: Usar strings/numbers para conceptos de dominio fuertes

using System;

namespace CalisthenicsExercises
{
    public static class NoPrimitivesExercise
    {
        public static string Transfer(double amount, string fromIban, string toIban, string currency)
        {
            if (string.IsNullOrWhiteSpace(fromIban) || string.IsNullOrWhiteSpace(toIban) || string.IsNullOrWhiteSpace(currency))
            {
                throw new Exception("Missing data");
            }
            if (amount <= 0)
            {
                throw new Exception("Invalid amount");
            }
            // simular una transferencia
            return $"{amount} {currency} from {fromIban} to {toIban}";
        }
    }

    /*
    Ejercicio (refactorizar hacia la regla):
    - Introducir tiny types/value objects:
      1) Money.
      2) Validar dentro de constructores/fábricas en lugar de ifs dispersos.
      3) Reemplazar la firma de la función con tipos de dominio para prevenir mal uso.
    - Aceptación: la firma de transfer no contiene primitivos desnudos para conceptos de dominio.
    */
}
