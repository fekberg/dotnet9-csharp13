public partial class User
{
    private string? name;
    public partial string Name 
    {
        get => name.ToUpperInvariant();
        set => name = value;
    }

    public partial string Process()
    {
        return string.Join("", Name.Reverse());
    }
}