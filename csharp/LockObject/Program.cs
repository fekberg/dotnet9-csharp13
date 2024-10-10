internal class Program
{
    // What happens if the lang version is incorrect?
    private readonly Lock _lock = new();

    void RunSomething()
    {
        lock (_lock)
        {

        }
    }

    static void Main(string[] args)
    {
        new Program().RunSomething();
    }
}
