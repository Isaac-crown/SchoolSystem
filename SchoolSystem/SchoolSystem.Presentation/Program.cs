using Microsoft.OpenApi.Models;
using SchoolSystem.Presentation.Extension;


var builder = WebApplication.CreateBuilder(args);


builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigurePostgreSqlContext(builder.Configuration);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.ConfigureCors();


//builder.Services.ConfigureServiceManager();
// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo

    {
        Version = "v1",
        Title = "SchoolSystem API",
        Description = "An ASP.NET Core Web API for managing Teachers and Students",

    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
