// Regla de calistenia: No getters ni setters
// EJEMPLO DE VIOLACIÓN: Modelo anémico con getters/setters y el comportamiento en otra parte

using System;

namespace CalisthenicsExercises
{
    public class BankAccount
    {
        private double _balance;

        public BankAccount(double initialBalance = 0)
        {
            _balance = initialBalance;
        }

        public double Balance
        {
            get { return _balance; }
            set
            {
                if (value < 0) throw new Exception("Negative");
                _balance = value;
            }
        }
    }

    // En otro lugar: los consumidores manipulan el estado directamente
    public static class NoGettersOrSettersExercise
    {
        public static void Pay(BankAccount account, double amount)
        {
            account.Balance = account.Balance - amount; // lógica externa usando getter/setter
        }
    }

    /*
    Ejercicio (refactorizar hacia la regla):
    - Mover el comportamiento dentro del objeto y eliminar getters/setters:
      1) Proveer métodos que revelen intención.
      2) Mantener las invariantes internas.
      3) Usar consultas que revelen intención.
    - Aceptación: No hay getters/setters públicos; el comportamiento vive con los datos.
    */
}
