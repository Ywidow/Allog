using Barber.Api.DbContexts;
using Barber.Api.Extensions;
using Barber.Api.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel( //Para colocar o host sempre em 5000
    options => {
        options.ListenLocalhost(5000);
    }
);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<CustomerContext>( //Para usar o Banco de Dados
    options => {
        options.UseNpgsql("Host=localhost;Database=BarberShop;Username=postgres;Password=Gui250504");
    }
);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment()){
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.ResetDatabaseAsync();

app.Run();