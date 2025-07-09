using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using PrivilegiosAPI.Data;

var builder = WebApplication.CreateBuilder(args);

//Conexion a SqlServer
builder.Services.AddDbContext<PrivilegiosContext>(
    options =>
        options.UseSqlServer("Server=THIAGO-ANT\\SQLEXPRESS; Database=PrivilegiosDb; Trusted_Connection=True; TrustServerCertificate=True;"));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTodo", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


var app = builder.Build();

app.UseCors("PermitirTodo");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using(var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<PrivilegiosContext>();
    context.Database.EnsureCreated();
    DataSeeder.Inicializar(context);
}

app.Run();
