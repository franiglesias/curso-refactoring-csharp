using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;
using CursoRefactoring.Refactoring.GoldenMaster;

namespace CursoRefactoring.Refactoring.GoldenMaster.Tests
{

[TestFixture]
public class GoldenMasterTests
{
    [Test]
    public void ShouldGenerateGoldenMaster()
    {
        var printer = new ReceiptPrinter();

        // Combinations of
        var customers = new[] { "Ana", "Luis", "Mar", "Iván", "Sofía" };
        var items = new[] { 1, 2, 3, 4, 5 };
        var quantities = new[] { 1, 3, 10, 25, 300 };

        var receipts = new List<string>();
        var counter = 0;

        foreach (var customer in customers)
        {
            foreach (var i in items)
            {
                foreach (var quantity in quantities)
                {
                    counter++;
                    var pedido = GoldenMasterHelper.GenerateOrder($"ORD-{counter}", customer, i, quantity);
                    var receipt = printer.Print(pedido);
                    receipts.Add(receipt);
                }
            }
        }

        var result = string.Join("\n==================\n", receipts);

        // Normalize non-deterministic parts (date/time, random discounts, totals)
        var normalized = Normalize(result);

        // Ensure snapshot directory exists under repo root
        var repoRoot = FindRepoRoot();
        var snapshotsDir = Path.Combine(repoRoot, "Refactoring", "GoldenMaster", "__snapshots__");
        Directory.CreateDirectory(snapshotsDir);
        var snapshotFile = Path.Combine(snapshotsDir, "golden-master.csharp.snap");

        if (!File.Exists(snapshotFile))
        {
            File.WriteAllText(snapshotFile, normalized, Encoding.UTF8);
            TestContext.WriteLine($"Snapshot created at: {snapshotFile}");
            Assert.Pass("Snapshot created (first run). Future runs will validate against this snapshot.");
        }
        else
        {
            var expected = File.ReadAllText(snapshotFile, Encoding.UTF8);
            if (!string.Equals(expected, normalized, StringComparison.Ordinal))
            {
                // Write actual to help debugging
                var actualOut = Path.Combine(snapshotsDir, "golden-master.csharp.actual.txt");
                File.WriteAllText(actualOut, normalized, Encoding.UTF8);
                Assert.Fail($"Golden Master mismatch.\nExpected snapshot: {snapshotFile}\nActual written: {actualOut}\nIf the change is intentional, update the snapshot by deleting it and re-running the test.");
            }
        }

        // Also keep a sanity check on how many were produced
        Assert.That(receipts.Count, Is.EqualTo(125));
        Assert.That(normalized, Is.Not.Empty);
    }

    private static string Normalize(string text)
    {
        var sb = new StringBuilder();
        foreach (var rawLine in text.Split('\n'))
        {
            var line = rawLine;
            // Normalize header timestamp after the dash
            line = Regex.Replace(line, @"^(Recibo\s+.+?\s-\s).*$", "$1<timestamp>");
            // Normalize discount line entirely
            if (line.StartsWith("Descuento de la suerte:"))
            {
                line = "Descuento de la suerte: <normalized>";
            }
            // Normalize total line entirely (depends on random discount)
            if (line.StartsWith("TOTAL:"))
            {
                line = "TOTAL: <normalized>";
            }
            sb.AppendLine(line);
        }
        // Recreate the separators exactly as they were (Split removed them). Trailing newline is okay for snapshots.
        var normalized = sb.ToString().Replace("\r\n", "\n");
        return normalized;
    }

    private static string FindRepoRoot()
    {
        var dir = AppContext.BaseDirectory;
        for (int i = 0; i < 10; i++)
        {
            if (File.Exists(Path.Combine(dir, "CursoRefactoring.sln")) || Directory.Exists(Path.Combine(dir, "Refactoring")))
            {
                return dir;
            }
            var parent = Directory.GetParent(dir);
            if (parent == null) break;
            dir = parent.FullName;
        }
        return AppContext.BaseDirectory; // fallback
    }
}

}
