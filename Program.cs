using System.Net;
using CS68.Service;
using Microsoft.AspNetCore.Routing.Constraints;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<ProductService>();
builder.Services.AddSingleton<PlanetService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseStatusCodePages(appError =>
{
    appError.Run(async context =>
    {
        var response = context.Response;
        var code = response.StatusCode;

        var content = @$"<html>
        <head>
            <meta charset='UTF-8' />
            <title>Lỗi {code}</title>
        </head>
        <body>
            <p style='color:red'>
                Có lỗi xảy ra: {code} - {(HttpStatusCode)code}
            </p>
        </body>
        </html>";

        await response.WriteAsync(content);
    });
});

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "first",
    pattern: "{url}/{id?}",
    defaults: new {
        controller = "First",
        action = "ViewProduct"
    },
    constraints: new {
        url = new StringRouteConstraint("xemsanpham")
    }
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
    
app.UseEndpoints(endpoints => 
{
    endpoints.MapGet("sayhi", async (context) => {
        await context.Response.WriteAsync($"Hello fen {DateTime.Now}");
    });
});

app.Run();
