using APIClientes.Core.Interfaces;
using APIClientes.Core.Services;
using APIClientes.Filters;
using APIClientes.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMvc(options =>
{
    options.Filters.Add<TempoDeExecucaoActionFilter>();
    options.Filters.Add<ExceptionalHandlingFilter>();
}
);

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<VerificaCpfExistenteActionFilter>();
builder.Services.AddScoped<VerificaSeRegistroExisteActionFilter>();
builder.Services.AddScoped<BuscarClientePorCpfActionFilter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
