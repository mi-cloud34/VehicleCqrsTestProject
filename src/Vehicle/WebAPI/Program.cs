using Application;
using Core.CrossCuttingConcerns.Exceptions;

using Microsoft.EntityFrameworkCore;
using Persistance;
using Persistance.Contexts;

using Persistance;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddHttpContextAccessor();

//var app = builder.Build();
//using (var scope = builder.Services.CreateScope())
//{
//    var db = scope.ServiceProvider.GetRequiredService<BaseDbContext>();
//    db.Database.Migrate();
//}

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(opt => opt.AddDefaultPolicy(p => { p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }));
builder.Services.AddDistributedMemoryCache(); // InMemory
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
if (app.Environment.IsProduction())
    app.ConfigureCustomExceptionMiddleware();

//app.MigratonDatabase();

app.UseAuthorization();

app.MapControllers();

app.Run();
