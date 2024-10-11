using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using MinimalAPIs.Models;
using MinimalAPIs.Services;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddAuthentication().AddCookie(CookieAuthenticationDefaults.AuthenticationScheme);
builder.Services.AddAuthorization();
builder.Services.AddDataProtection();
builder.Services.AddTransient<DataService>();

// /openapi/v1.json
builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => TypedResults.InternalServerError());

app.MapGet("/500", () => TypedResults.InternalServerError("Oh no!"));

app.MapGet("/sign-in", async (HttpContext context) => {
    IEnumerable<Claim> claims = [new Claim("name", "Filip")];
    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
    var principal = new ClaimsPrincipal(identity);

    context.Response.Cookies.Append("data", "here is some additional data");

    await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

    return new User { FirstName = "Filip", LastName = "Ekberg" };
});

app.MapGet("/data", async (DataService service) => {
    return await service.GetAsync();
});

app.Run();
