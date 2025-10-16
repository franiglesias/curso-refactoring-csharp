// Code smell: Middleman [Intermediario]. Shop hace poco más que delegar a Catalog, añadiendo
// una capa innecesaria que oscurece al colaborador real.

// Ejercicio: Añade una funcionalidad searchByPrefix.

// Añadirás métodos a Shop que solo
// pasan a través hacia Catalog, fomentando duplicación accidental y ocultando
// dónde vive el comportamiento real cuando necesites cambiarlo después.

export class Catalog {
  private items = new Map<string, string>()

  add(id: string, name: string): void {
    this.items.set(id, name)
  }

  find(id: string): string | undefined {
    return this.items.get(id)
  }

  list(): string[] {
    return Array.from(this.items.values())
  }
}

export class Shop {
  constructor(private catalog: Catalog) {
  }

  add(id: string, name: string): void {
    this.catalog.add(id, name)
  }

  find(id: string): string | undefined {
    return this.catalog.find(id)
  }

  list(): string[] {
    return this.catalog.list()
  }
}

export function demoMiddleman(): string[] {
  const c = new Catalog()
  const s = new Shop(c)
  s.add('1', 'Book')
  s.add('2', 'Pen')
  return s.list()
}
