using lab12.Models;
using lab12.Pages;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddSqlServer<InternetProviderContext>("Data Source=localhost;Initial Catalog=InternetProvider;trusted_connection=false;encrypt=false;User ID=sa;Password=SQLserver2022");


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapRazorPages();

app.Run();
