// Code smell: Parallel Inheritance Hierarchy [Jerarquía de herencia paralela]. Agregar un nuevo componente de UI obliga a agregar
// métodos correspondientes en cada renderer, haciendo que ambas jerarquías crezcan al unísono.

// Ejercicio: Añade un componente Image.

// Necesitarás añadir Image, añadir renderImage a Renderer,
// e implementarlo en todos los renderers, mostrando cambios en paralelo.

namespace CodeSmells.ChangePreventers
{
    // Traducción directa preservando jerarquías paralelas
    public abstract class Component
    {
        public abstract string Draw(Renderer renderer);
    }

    public class Button : Component
    {
        public string Label { get; }
        public Button(string label) { Label = label; }
        public override string Draw(Renderer renderer) => renderer.RenderButton(this);
    }

    public class TextBox : Component
    {
        public string Text { get; }
        public TextBox(string text) { Text = text; }
        public override string Draw(Renderer renderer) => renderer.RenderTextBox(this);
    }

    public abstract class Renderer
    {
        public abstract string RenderButton(Button b);
        public abstract string RenderTextBox(TextBox t);
    }

    public class HtmlRenderer : Renderer
    {
        public override string RenderButton(Button b) => $"<button>{b.Label}</button>";
        public override string RenderTextBox(TextBox t) => $"<input value=\"{t.Text}\"/>";
    }

    public class MarkdownRenderer : Renderer
    {
        public override string RenderButton(Button b) => $"[{b.Label}]";
        public override string RenderTextBox(TextBox t) => $"_{t.Text}_";
    }

    public static class ParallelHierarchyDemo
    {
        public static string[] DemoParallelHierarchy()
        {
            Component[] comps = { new Button("Save"), new TextBox("name") };
            var renderer = new HtmlRenderer();
            var results = new string[comps.Length];
            for (int i = 0; i < comps.Length; i++) results[i] = comps[i].Draw(renderer);
            return results;
        }
    }
}
