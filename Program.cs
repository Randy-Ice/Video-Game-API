using DotNetEnv;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Serilog;
using Video_Game_API.Data;
using Video_Game_API.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


//Odata
builder.Services.AddControllers()
    .AddOData(options =>
    {
        options.Select().Filter().OrderBy()
        .Count().Expand();
        //.SetMaxTop(100);

    });

//Connection Strings
Env.Load();
var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

//Database
builder.Services.AddDbContext<Database>(options =>
{
    options.UseSqlServer(connectionString);
});


//Auth
builder.Services.AddDbContext<Auth>(options =>
{
    options.UseSqlServer(connectionString);
});
builder.Services.AddAuthentication();
builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<Auth>();


//Logging
var logger = new LoggerConfiguration()
    .WriteTo.File("Logs/logs.txt", rollingInterval: RollingInterval.Day)
    .MinimumLevel.Warning()
    .CreateLogger();
//builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapIdentityApi<IdentityUser>();
app.UseMiddleware<HandleExceptions>();
app.MapControllers();

app.Run();
