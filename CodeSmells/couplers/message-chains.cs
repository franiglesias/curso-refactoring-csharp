// Code smell: Message Chains [Cadenas de mensajes]. La navegación profunda por grafos de objetos acopla a los clientes
// a la estructura de los intermediarios y conduce a código frágil.

// Ejercicio: Inserta un nuevo Level entre Root y Level1, o reubica getValue.

// Observa cómo cada cliente que usa root.getNext().getNext().getValue() debe cambiar,
// revelando cómo las cadenas de mensajes vuelven costosas refactorizaciones simples.

namespace CodeSmells.Couplers
{
    // Traducción directa preservando la cadena de mensajes
    public class Level2
    {
        private int value;
        public Level2(int value) { this.value = value; }
        public int GetValue() => this.value;
    }

    public class Level1
    {
        private Level2 next;
        public Level1(Level2 next) { this.next = next; }
        public Level2 GetNext() => this.next;
    }

    public class Root
    {
        private Level1 next;
        public Root(Level1 next) { this.next = next; }
        public Level1 GetNext() => this.next;
    }

    public static class MessageChains
    {
        public static int ReadDeep(Root root)
        {
            return root.GetNext().GetNext().GetValue();
        }
    }
}
