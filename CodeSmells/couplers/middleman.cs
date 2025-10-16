// Code smell: Middleman [Intermediario]. Shop hace poco más que delegar a Catalog, añadiendo
// una capa innecesaria que oscurece al colaborador real.

// Ejercicio: Añade una funcionalidad searchByPrefix.

// Añadirás métodos a Shop que solo
// pasan a través hacia Catalog, fomentando duplicación accidental y ocultando
// dónde vive el comportamiento real cuando necesites cambiarlo después.

using System;
using System.Collections.Generic;

namespace CodeSmells.Couplers
{
    public class Catalog
    {
        private readonly Dictionary<string, string> items = new Dictionary<string, string>();

        public void Add(string id, string name)
        {
            items[id] = name;
        }

        public string Find(string id)
        {
            items.TryGetValue(id, out var value);
            return value;
        }

        public List<string> List()
        {
            return new List<string>(items.Values);
        }
    }

    public class Shop
    {
        private readonly Catalog catalog;
        public Shop(Catalog catalog) { this.catalog = catalog; }

        public void Add(string id, string name)
        {
            this.catalog.Add(id, name);
        }

        public string Find(string id)
        {
            return this.catalog.Find(id);
        }

        public List<string> List()
        {
            return this.catalog.List();
        }
    }

    public static class MiddlemanDemo
    {
        public static List<string> DemoMiddleman()
        {
            var c = new Catalog();
            var s = new Shop(c);
            s.Add("1", "Book");
            s.Add("2", "Pen");
            return s.List();
        }
    }
}
