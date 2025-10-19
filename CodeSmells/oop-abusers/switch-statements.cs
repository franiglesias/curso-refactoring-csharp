// Code smell: Switch Statements [Sentencias switch]. El comportamiento se ramifica en códigos de tipo en lugar de usar
// polimorfismo, lo que genera lógica condicional dispersa que crece con cada variante.

// Ejercicio: Añade un nuevo tipo de empleado (contractor) con una regla de pago especial.

// Tendrás que modificar el switch y cualquier código relacionado, repitiendo este cambio
// en muchos lugares a medida que se acumulen nuevos tipos.

using System;

namespace CodeSmells.OopAbusers
{
    public enum EmployeeKind
    {
        Engineer,
        Manager,
        Sales
    }

    public class EmployeeRecord
    {
        public EmployeeKind Kind { get; set; }
        public decimal Base { get; set; }
        public decimal? Bonus { get; set; }
        public decimal? Commission { get; set; }
    }

    public static class SwitchStatementsDemo
    {
        public static decimal CalculatePay(EmployeeRecord rec)
        {
            switch (rec.Kind)
            {
                case EmployeeKind.Engineer:
                    return rec.Base;
                case EmployeeKind.Manager:
                    return rec.Base + (rec.Bonus ?? 0m);
                case EmployeeKind.Sales:
                    return rec.Base + (rec.Commission ?? 0m);
                default:
                    throw new ArgumentOutOfRangeException(nameof(rec.Kind), rec.Kind, "Unknown employee kind");
            }
        }

        // Example usage evaluating different employee kinds through the switch
        public static decimal[] DemoSwitchStatements()
        {
            return new[]
            {
                CalculatePay(new EmployeeRecord { Kind = EmployeeKind.Engineer, Base = 1000 }),
                CalculatePay(new EmployeeRecord { Kind = EmployeeKind.Manager, Base = 1000, Bonus = 200 }),
                CalculatePay(new EmployeeRecord { Kind = EmployeeKind.Sales, Base = 800, Commission = 500 }),
            };
        }
    }
}
