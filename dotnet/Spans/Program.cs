#region File helpers
ReadOnlySpan<char> text = "Hello NDC, how are you doing?";

File.WriteAllText("output.txt", text);
#endregion

#region Extension methods
var doesSpanStartWith = text.StartsWith("Hello", StringComparison.OrdinalIgnoreCase);

ReadOnlySpan<byte> data = [0xff, 0xa1, 0x12];

ReadOnlySpan<byte> pattern = [0x12];

var doesSpanEndWith = data.EndsWith(pattern); // If they add support for params the above wont be necessary!
#endregion

#region params

string.Join(" ", "Filip", "Ekberg");

#endregion

#region Split

string input = "Filip,Sofie,Mila,Elise";
ReadOnlySpan<char> inputAsSpan = input;

MemoryExtensions.SpanSplitEnumerator<char> ranges = inputAsSpan.Split(',');
foreach(var range in ranges)
{
    ReadOnlySpan<char> name = inputAsSpan[range];

    Console.WriteLine(name.ToString());
}

#endregion