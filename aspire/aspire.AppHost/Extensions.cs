namespace aspire.AppHost;

public static class Extensions
{
    public static IResourceBuilder<ProjectResource> WithDumpDatabaseCommand(this IResourceBuilder<ProjectResource> builder)
    {
        return builder.WithCommand("Delete database", "Delete database", async context => {
            return new ExecuteCommandResult { Success = true };
        });
    }
}
