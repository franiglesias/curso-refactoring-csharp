// Code smell: Long Parameter List [Lista de parámetros larga]. Demasiados parámetros separados hacen las llamadas difíciles de leer
// y propensas a errores. Esto podría reemplazarse con un objeto de parámetros o un builder.

// Ejercicio: Añade dos opciones más (p. ej., locale y pageSize) al reporte.

// Tendrás que encadenar más argumentos a través de cada punto de llamada, aumentando la
// probabilidad de errores y dificultando cambios futuros.

using System;

namespace CodeSmells.Bloaters
{
    // Traducción directa preservando la lista larga de parámetros
    public class ReportGenerator
    {
        public void GenerateReport(
            string title,
            DateTime startDate,
            DateTime endDate,
            bool includeCharts,
            bool includeSummary,
            string authorName,
            string authorEmail
        )
        {
            Console.WriteLine($"Generando reporte: {title}");
            Console.WriteLine($"Desde {startDate.ToShortDateString()} hasta {endDate.ToShortDateString()}");
            Console.WriteLine($"Autor: {authorName} ({authorEmail})");
            if (includeCharts) Console.WriteLine("Incluyendo gráficos...");
            if (includeSummary) Console.WriteLine("Incluyendo resumen...");
            Console.WriteLine("Reporte generado exitosamente.");
        }
    }

    public static class LongParameterListDemo
    {
        public static void DemoLongParameterList()
        {
            var gen = new ReportGenerator();
            gen.GenerateReport(
                "Ventas Q1",
                new DateTime(2025, 1, 1),
                new DateTime(2025, 3, 31),
                true,
                false,
                "Pat Smith",
                "pat@example.com"
            );
        }
    }
}
