// Translated from CalisthenicsExamples/dont-use-abbreviations.ts
// Intentional simplicity and naming kept to mirror the example (including smells if any)
using System;

namespace CalisthenicsExamples
{
    public class Employee
    {
        private double salary;
        private int experience;

        public Employee(double salary, int experience)
        {
            this.salary = salary;
            this.experience = experience;
        }

        public double CalculateBonus()
        {
            if (this.experience > 5)
            {
                return this.salary * 0.2;
            }
            return this.salary * 0.1;
        }
    }
}
