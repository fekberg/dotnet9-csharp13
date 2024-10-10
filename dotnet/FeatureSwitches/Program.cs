using System.Diagnostics.CodeAnalysis;

var service = new UserService();

service.Create("filip@ekberg.dev");

public class UserService
{
    [FeatureSwitchDefinition("UserService.IsEnabled")]
    private static bool IsEnabled => AppContext.TryGetSwitch("UserService.IsEnabled", out bool isEnabled) ? isEnabled : true;

    public void Create(string email)
    {
        if(IsEnabled)
        {
            Console.WriteLine("A");
        }
    }
}
