using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Contact = new OpenApiContact
        {
            Email = "waqarkabir10@gmail.com",
            Name = "Waqar Kabir",
            Url = new Uri("https://www.codewithmind.com")
        },
        Description = "Sample API using .NET 6 to implement Web API with MS SQL Server and Entity Framework Core.",
        Title = "Hostel API",
        Version = "v1",
        License = new OpenApiLicense
        {
            Name = "Open Source",
            Url = new Uri("https://www.codewithmind.com")
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(setup =>
    {
        setup.DocumentTitle = "Hostel Web API";
        setup.DocExpansion(DocExpansion.None);
        setup.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        setup.RoutePrefix = string.Empty;
        setup.InjectStylesheet("/swagger-ui/custom.css");
    });
}

app.UseHttpsRedirection();

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseAuthorization();

app.MapControllers();

app.Run();
