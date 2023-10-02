using playground.Common.Interfaces;
using playground.Infrastructures;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddWebServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();
EnsureDbConnected();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseExceptionHandler(options => { });


app.MapEndpoints();
app.Run();

async void EnsureDbConnected()
{
    var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
    using var scope = scopeFactory.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<IApplicationDbContext>();
    if (await dbContext.CanConnectAsync())
        Console.WriteLine("🚀 Database connected!");
    else
        Console.WriteLine("⚠️ Database connection failed!");
}