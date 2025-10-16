using System;

// Code smell: Data Class [Clase de datos]. UserRecord expone datos públicos con poco o ningún comportamiento,
// empujando toda la lógica a otras clases y fomentando modelos de dominio anémicos.

// Ejercicio: Requiere verificación de email y reglas de dominio (p. ej., solo company.com).

// Necesitarás tocar múltiples servicios y lugares que manipulan UserRecord,
// mostrando cómo separar el comportamiento de los datos hace que cambios simples se dispersen ampliamente.

namespace CodeSmells.Dispensables
{
    public class UserRecord
    {
        public string id;
        public string name;
        public string email;
        public DateTime createdAt;

        public UserRecord(string id, string name, string email, DateTime createdAt)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.createdAt = createdAt;
        }
    }

    class UserService
    {
        public UserRecord CreateUser(string name, string email)
        {
            if (!email.Contains("@"))
            {
                throw new Exception("Invalid email");
            }

            return new UserRecord(Guid.NewGuid().ToString(), name, email, DateTime.Now);
        }

        public void UpdateUserEmail(UserRecord user, string newEmail)
        {
            if (!newEmail.Contains("@"))
            {
                throw new Exception("Invalid email");
            }
            user.email = newEmail;
        }
    }

    class UserReportGenerator
    {
        public string GenerateUserSummary(UserRecord user)
        {
            return $"User {user.name} ({user.email}) created on {user.createdAt.ToShortDateString()}";
        }
    }

    // Example usage orchestrating behavior in separate services rather than the data class itself
    public static class DataClassDemo
    {
        public static string DemoDataClass()
        {
            var service = new UserService();
            var report = new UserReportGenerator();
            var user = service.CreateUser("Lina", "lina@example.com");
            service.UpdateUserEmail(user, "lina+news@example.com");
            return report.GenerateUserSummary(user);
        }
    }
}
