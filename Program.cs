using Microsoft.EntityFrameworkCore;
using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using TodoGDS.Data;
using TodoGDS.Services;

var builder = WebApplication.CreateBuilder(args);

// Debug: Log the environment
Console.WriteLine($"Environment: {builder.Environment.EnvironmentName}");

// Add Azure Key Vault configuration (only in production)
if (!builder.Environment.IsDevelopment())
{
    var keyVaultUri = new Uri($"https://{builder.Configuration["KeyVaultName"]}.vault.azure.net/");
    builder.Configuration.AddAzureKeyVault(keyVaultUri, new DefaultAzureCredential());
}

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure database context based on environment
if (builder.Environment.IsDevelopment())
{
    // Use SQLite for development
    builder.Services.AddDbContext<TodoDbContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
}
else
{
    // Use SQL Server for production
    builder.Services.AddDbContext<TodoDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
}

// Register TodoService
builder.Services.AddScoped<TodoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
