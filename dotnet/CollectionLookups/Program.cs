Dictionary<string, string> cache = new();

ReadOnlySpan<char> key = "Filip";

var lookup = cache.GetAlternateLookup<ReadOnlySpan<char>>();

lookup[key] = "Hello";

Console.WriteLine(lookup[key]);

