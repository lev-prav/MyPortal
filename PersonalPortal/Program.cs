using DBRepository.Factories;
using DBRepository.Interfaces;
using DBRepository.Repositories;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddScoped<IRepositoryContextFactory, RepositoryContextFactory>();
builder.Services.AddScoped<IBlogRepository>(
    provider => 
        new BlogRepository(builder.Configuration.GetConnectionString("DefaultConnection")!, 
            provider.GetService<IRepositoryContextFactory>()!));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.UseRouting(); // используем систему маршрутизации
 
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});
app.Run();

//TODO  add swagger
//TODO make correct blog controllers