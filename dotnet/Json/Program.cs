using System.Text.Json;
using System.Text.Json.Schema;

var user = new User("Filip", "Ekberg");

IndentationOptions();

#region Indentation Options
void IndentationOptions()
{
    JsonSerializerOptions options = new()
    {
        WriteIndented = true,
        IndentCharacter = '\t',
        IndentSize = 1
    };
    var json = JsonSerializer.Serialize(user, options);

    Console.WriteLine(json);
}
#endregion

#region ASP.NET Core Defaults
void AspNetCoreDefaults()
{
    var json = JsonSerializer.Serialize(user, JsonSerializerOptions.Web);

    Console.WriteLine(json);
}
#endregion

#region Export Schema for OpenAPI
void ExportSchema()
{
    var schema = JsonSchemaExporter.GetJsonSchemaAsNode(JsonSerializerOptions.Default, typeof(User));

    Console.WriteLine(schema);
}
#endregion

#region Respect Nullable
void RespectNullable()
{
    var json = 
    """
    {
        "FirstName" : null,
        "LastName": "Ekberg"
    }
    """;

    var options = new JsonSerializerOptions { RespectNullableAnnotations = true }; 

    user = JsonSerializer.Deserialize<User>(json, options);
}
#endregion

#region Respect Nullable (Generics?)
void RespectNullableGenerics()
{
    var options = new JsonSerializerOptions { RespectNullableAnnotations = true };

    var json =
    """
    {
        "Data": null
    }
    """;

    var data = JsonSerializer.Deserialize<Generic<string>>(json, options);

}
#endregion

#region Respect Constructor Parameters
void RespectConstructorParameters()
{
    var json =
        """
        {}
        """;
    
    //json = """
    //    {
    //        "FirstName" : "Filip",
    //        "LastName": null
    //    }
    //    """;

    var options = new JsonSerializerOptions { 
        RespectRequiredConstructorParameters = true 
    }; 
    var user = JsonSerializer.Deserialize<User>(json, options);

    Console.WriteLine($"Name is: '{user?.FirstName}'");
}
#endregion

record User(string FirstName, string LastName);

record Generic<T>(T Data);