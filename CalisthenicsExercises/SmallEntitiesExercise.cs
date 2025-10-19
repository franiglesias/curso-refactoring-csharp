// Regla de calistenia: Entidades pequeñas (clases/métodos pequeños)
// Este archivo VIOLA intencionalmente la regla creando una clase grande que hace de todo.
// También incluye una propuesta de ejercicio para refactorizar hacia la regla.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace CalisthenicsExercises
{
    // EJEMPLO DE VIOLACIÓN: Objeto dios con muchas responsabilidades
    public class ReportService
    {
        // parseo, validación, formateo, E/S, cálculos y caché en una sola clase
        private readonly Dictionary<string, string> cache = new Dictionary<string, string>();

        public string GenerateCsvReportFromJson(string jsonInput, string delimiter = ",")
        {
            // parsear
            JsonDocument doc;
            try
            {
                doc = JsonDocument.Parse(jsonInput);
            }
            catch (Exception)
            {
                throw new Exception("Invalid JSON");
            }

            var root = doc.RootElement;

            // validar
            if (root.ValueKind != JsonValueKind.Array)
            {
                throw new Exception("Expected array");
            }

            if (root.GetArrayLength() == 0)
            {
                // sin datos: cabecera vacía
                cache["last"] = string.Empty;
                return string.Empty;
            }

            // calcular y formatear
            var first = root.EnumerateArray().First();
            if (first.ValueKind != JsonValueKind.Object)
            {
                throw new Exception("Expected array of objects");
            }

            var headers = first.EnumerateObject().Select(p => p.Name).ToList();
            var lines = new List<string> { string.Join(delimiter, headers) };

            foreach (var row in root.EnumerateArray())
            {
                var values = headers
                    .Select(h => row.TryGetProperty(h, out var val) ? JsonValueToString(val) : string.Empty)
                    .ToList();
                lines.Add(string.Join(delimiter, values));
            }

            var result = string.Join("\n", lines);

            // responsabilidad de caché y E/S
            cache["last"] = result;
            // simular escritura a disco/red devolviendo resultado
            return result;
        }

        private static string JsonValueToString(JsonElement val)
        {
            switch (val.ValueKind)
            {
                case JsonValueKind.String:
                    return val.GetString();
                case JsonValueKind.Number:
                    return val.GetRawText();
                case JsonValueKind.True:
                case JsonValueKind.False:
                    return val.GetBoolean().ToString();
                case JsonValueKind.Null:
                case JsonValueKind.Undefined:
                    return string.Empty;
                default:
                    return val.GetRawText();
            }
        }
    }

    /*
    Ejercicio (refactorizar hacia la regla):
    - Dividir responsabilidades en entidades pequeñas y cohesivas.
    - Aceptación: No hay clase dios; el sistema se compone de entidades pequeñas y de propósito único.
    */
}
