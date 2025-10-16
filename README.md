# Curso de Refactoring - Versión C#

Este proyecto es la conversión a C# del curso de refactoring original en TypeScript. Contiene ejemplos de **code smells**, **Object Calisthenics**, y técnicas de **refactoring** como el **Golden Master**.

## Estructura del Proyecto

```
CursoRefactoring.csproj          # Archivo de proyecto .NET
CursoRefactoring.sln             # Archivo de solución
├── Calisthenics/                # Object Calisthenics - versión solucionada/ejemplo
├── CalisthenicsExamples/        # Object Calisthenics - ejemplos para demostración
├── CalisthenicsExercises/       # Object Calisthenics - ejercicios sin resolver
├── CodeSmells/                  # Ejemplos de code smells organizados por categoría
│   ├── Bloaters/               # Code smells que hacen crecer el código
│   ├── ChangePreventers/       # Code smells que impiden cambios
│   ├── Couplers/               # Code smells de acoplamiento
│   ├── Dispensables/           # Code smells innecesarios
│   └── OopAbusers/             # Abuso de conceptos OOP
└── Refactoring/                 # Técnicas de refactoring
    └── GoldenMaster/           # Técnica Golden Master para legacy code
```

## Cómo Ejecutar

### Requisitos
- .NET 8.0 SDK o superior
- Un IDE como Visual Studio, Visual Studio Code, o JetBrains Rider

### Compilar el Proyecto
```bash
dotnet build
```

### Ejecutar las Pruebas
```bash
dotnet test
```

### Ejecutar desde un IDE
Abre el archivo `CursoRefactoring.sln` en tu IDE preferido y ejecuta las pruebas desde allí.

## Contenido

### Object Calisthenics
Reglas para escribir código más expresivo y mantenible:
- No usar abreviaciones
- No usar `else`
- No usar primitivos (wrap them)
- No usar getters/setters
- Una sola expresión por línea
- Un solo nivel de indentación
- No más de 2 variables de instancia
- Colecciones de primera clase
- Entidades pequeñas

### Code Smells
Ejemplos organizados por categoría:

**Bloaters (Infladores):**
- Data Clump - Grupos de datos que viajan juntos
- Large Class - Clases con demasiadas responsabilidades
- Long Method - Métodos que hacen demasiado
- Long Parameter List - Listas de parámetros muy largas
- Primitive Obsession - Uso excesivo de tipos primitivos

**Couplers (Acopladores):**
- Feature Envy - Una clase usa demasiado otra clase
- Message Chains - Cadenas largas de llamadas a métodos

**Dispensables (Prescindibles):**
- Duplicated Code - Código duplicado en múltiples lugares

### Técnicas de Refactoring

**Golden Master:**
Técnica para refactorizar código legacy de forma segura. Captura el comportamiento actual del sistema en un "snapshot" para detectar regresiones durante el refactoring.

## Propósito Educativo

Este proyecto está diseñado para:
1. **Identificar** code smells en código existente
2. **Practicar** técnicas de refactoring
3. **Aplicar** Object Calisthenics para mejorar el diseño
4. **Usar** Golden Master para refactorizar código legacy

Cada ejemplo incluye comentarios explicativos y ejercicios sugeridos para profundizar el aprendizaje.

## Diferencias con la Versión TypeScript

- Uso de tipos y interfaces de C# en lugar de TypeScript
- Convenciones de nomenclatura de C# (PascalCase para métodos públicos)
- NUnit en lugar de Vitest para las pruebas
- Uso de características específicas de C# como `decimal` para valores monetarios
- Namespaces estructurados siguiendo convenciones de .NET

## Contribuciones

Este es un proyecto educativo. Si encuentras errores o tienes sugerencias de mejora, son bienvenidas las contribuciones.

# Curso Refactoring

Examples for learning and practice refactoring.
