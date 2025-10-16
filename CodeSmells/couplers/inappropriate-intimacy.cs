// Code smell: Inappropriate Intimacy [Intimidad inapropiada]. Team y Manager exponen y modifican el estado
// interno del otro, creando un acoplamiento fuerte y diseños frágiles.

// Ejercicio: Añade una traza de auditoría cuando cambien los presupuestos y aplica reglas de presupuesto mínimo.

// Como Team y Manager tocan libremente los campos del otro, tendrás que esparcir
// comprobaciones y registros en muchos lugares, aumentando el acoplamiento y las regresiones.

namespace CodeSmells.Couplers
{
    // Traducción directa preservando intimidad inapropiada
    public class Team
    {
        public string name;
        public double budget;
        public Manager manager; // acceso cruzado

        public Team(string name, double budget)
        {
            this.name = name;
            this.budget = budget;
        }

        public void AssignManager(Manager m)
        {
            this.manager = m;
            m.team = this;
        }
    }

    public class Manager
    {
        public string name;
        public Team team; // acceso cruzado

        public Manager(string name)
        {
            this.name = name;
        }

        public void RaiseTeamBudget(double amount)
        {
            if (this.team != null) this.team.budget += amount;
        }

        public void RenameTeam(string newName)
        {
            if (this.team != null) this.team.name = newName;
        }
    }

    public static class InappropriateIntimacyDemo
    {
        public static Team DemoInappropriateIntimacy()
        {
            var t = new Team("Core", 1000);
            var m = new Manager("Alice");
            t.AssignManager(m);
            m.RaiseTeamBudget(200);
            m.RenameTeam("Platform");
            return t;
        }
    }
}
