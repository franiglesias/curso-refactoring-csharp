// Code smell: Temporal Instance Variables [Variables de instancia temporales]. Los campos se configuran solo durante
// una fase específica del ciclo de vida de un objeto, aumentando la probabilidad de mal uso entre fases.

// Ejercicio: Añade una función de auto-guardado que pueda llamarse en cualquier momento.

// Necesitarás manejar estados donde title/range/buffer puedan estar medio inicializados,
// revelando cómo el acoplamiento temporal complica cambios aparentemente simples.

using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeSmells.OopAbusers
{
    public class ReportBuilder
    {
        private string? _title;
        private DateTime? _rangeStart;
        private DateTime? _rangeEnd;
        private List<string> _buffer = new List<string>();

        public void Begin(string title)
        {
            _title = title;
            _buffer = new List<string>();
        }

        public void SetRange(DateTime start, DateTime end)
        {
            _rangeStart = start;
            _rangeEnd = end;
        }

        public void AddLine(string text)
        {
            _buffer.Add(text);
        }

        public string Finish()
        {
            var header = _title ?? string.Empty;
            var range = (_rangeStart.HasValue && _rangeEnd.HasValue)
                ? string.Concat(_rangeStart.Value.ToString("o"), "..", _rangeEnd.Value.ToString("o"))
                : string.Empty;
            var body = string.Join('\n', _buffer);

            // reset internal state
            _title = null;
            _rangeStart = null;
            _rangeEnd = null;
            _buffer = new List<string>();

            // Filter out empty parts and join with newlines
            var parts = new List<string> { header, range, body }.Where(p => !string.IsNullOrEmpty(p));
            return string.Join('\n', parts);
        }
    }

    // Example usage showing the required call order; misuse between phases is easy
    public static class TemporalInstanceVariablesDemo
    {
        public static string DemoTemporalInstanceVariables()
        {
            var b = new ReportBuilder();
            b.Begin("Weekly Report");
            b.SetRange(new DateTime(2025, 10, 01), new DateTime(2025, 10, 07));
            b.AddLine("Line A");
            b.AddLine("Line B");
            return b.Finish();
        }
    }
}
