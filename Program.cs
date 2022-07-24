using Microsoft.EntityFrameworkCore;
using smallStore.Data;

var builder = WebApplication.CreateBuilder(args);
// for cors
var _loginOrigin = "_localorigin";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("smallStoreDbConnectionString"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(_loginOrigin, builder =>
    {
        //builder.WithOrigins("http://localhost:4200");
        builder.AllowAnyOrigin();
        builder.AllowAnyHeader();
        builder.AllowAnyMethod();
        //builder.AllowCredentials();

    });
});
var app = builder.Build();


    app.UseSwagger();
    app.UseSwaggerUI();


app.UseAuthorization();

app.UseCors(_loginOrigin);

app.MapControllers();

app.Run();
