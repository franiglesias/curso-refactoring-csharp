// Code smell: Divergent Change [Cambio divergente]. ProfileManager maneja validación, persistencia,
// exportación y envío de emails—múltiples razones para cambiar concentradas en una sola clase.

// Ejercicio: Añade un número de teléfono con validación, inclúyelo en las exportaciones y envía un SMS.

// Tocarás validación, almacenamiento, exportAsJson/Csv y mensajería en un solo lugar,
// demostrando cómo un cambio fuerza ediciones en responsabilidades no relacionadas.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace CodeSmells.ChangePreventers
{
    // Traducción directa preservando múltiples razones para cambiar
    public class ProfileManager
    {
        private readonly Dictionary<string, User> store = new Dictionary<string, User>();

        public void Register(User user)
        {
            if (string.IsNullOrWhiteSpace(user.name)) throw new Exception("invalid name");
            if (!user.email.Contains("@")) throw new Exception("invalid email");
            store[user.id] = user;
        }

        public void UpdateEmail(string id, string newEmail)
        {
            if (!newEmail.Contains("@")) throw new Exception("invalid email");
            if (!store.TryGetValue(id, out var u)) throw new Exception("not found");
            store[id] = new User { id = u.id, name = u.name, email = newEmail };
        }

        public string ExportAsJson()
        {
            return JsonSerializer.Serialize(store.Values.ToList());
        }

        public string ExportAsCsv()
        {
            var rows = new List<string> { "id,name,email" };
            rows.AddRange(store.Values.Select(u => $"{u.id},{u.name},{u.email}"));
            return string.Join("\n", rows);
        }

        public string SendWelcomeEmail(User user)
        {
            return $"Welcome {user.name}! Sent to {user.email}";
        }
    }

    public class User
    {
        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
    }

    public static class DivergentChangeDemo
    {
        public static string DemoDivergentChange(ProfileManager pm, User u)
        {
            pm.Register(u);
            pm.UpdateEmail(u.id, u.email);
            return pm.ExportAsJson();
        }
    }
}
