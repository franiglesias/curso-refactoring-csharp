// Code smell: Alternative Classes with Different Interfaces [Clases alternativas con interfaces diferentes].
// Dos clases son intercambiables pero exponen nombres de métodos distintos, forzando código condicional
// en los clientes e impidiendo el polimorfismo.

// Ejercicio: Añade logging con marca de tiempo a ambas implementaciones y permite intercambiarlas en tiempo de ejecución.

// Duplicarás la funcionalidad en métodos con nombres distintos y esparcirás condicionales
// en los clientes, haciendo cambios simples tediosos y propensos a errores.

using System;

namespace CodeSmells.OopAbusers
{
    public class TextLogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"[text] {message}");
        }
    }

    public class MessageWriter
    {
        public void Write(string entry)
        {
            Console.WriteLine($"[text] {entry}");
        }
    }

    public static class AlternativeClassesDemo
    {
        public static void UseAltClasses(string choice, string msg)
        {
            if (choice == "logger")
            {
                new TextLogger().Log(msg);
            }
            else
            {
                new MessageWriter().Write(msg);
            }
        }
    }
}
