
using System.Collections.Immutable;
using System.Runtime.CompilerServices;

Processor processor = new();
Span<string> names = ["Filip Ekberg", "Sofie Ekberg", "Mila E", "Elise E"];

var result = processor.ProcessNames("Filip Ekberg", "Sofie Ekberg", "Mila E", "Elise E");
result = processor.ProcessNames(["Filip Ekberg", "Sofie Ekberg", "Mila E", "Elise E"]);

foreach (var name in result) Console.WriteLine(name);

public class Processor
{
    [OverloadResolutionPriority(0)]
    public IEnumerable<string> ProcessNames(params List<string> names)
    {
        foreach (var name in names)
        {
            yield return name.Split(" ")
                .First()
                .ToUpperInvariant();
        }
    }

    public IEnumerable<string> ProcessNames(params IEnumerable<string> names)
    {
        foreach (var name in names)
        {
            yield return name.Split(" ")
                .First()
                .ToUpperInvariant();
        }
    }

    [OverloadResolutionPriority(1)]
    public IEnumerable<string> ProcessNames(params ReadOnlySpan<string> names)
    {
        var result = new string[names.Length];

        for (int i = 0; i < names.Length; i++)
        {
            var name = names[i];
            result[i] = name[..name.IndexOf(" ")]
                .ToUpperInvariant();
        }

        return result;
    }

    public IEnumerable<string> ProcessNames(params Span<string> names)
    {
        var result = new string[names.Length];

        for (int i = 0; i < names.Length; i++)
        {
            var name = names[i];
            result[i] = name[..name.IndexOf(" ")]
                .ToUpperInvariant();
        }

        return result;
    }

    public IEnumerable<string> ProcessNames(params string[] names)
    {
        foreach (var name in names)
        {
            yield return name.Split(" ")
                .First()
                .ToUpperInvariant();
        }
    }
    public IEnumerable<string> ProcessNames(params ImmutableList<string> names)
    {
        foreach (var name in names)
        {
            yield return name.Split(" ")
                .First()
                .ToUpperInvariant();
        }
    }
}
//public class Person
//{
//    public string Name { get => field.Trim() ; set; }
//}