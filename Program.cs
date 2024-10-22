using AlzBuddy;
using AlzBuddy.Receivers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddHttpClient(); // Add HttpClient support
builder.Services.AddSingleton<DataIncoming>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AlzBuddy API", Version = "v1" });
});
builder.Services.AddScoped<AlzBuddyDB>();
builder.Services.AddCors(o =>
{
    o.AddPolicy("_specifiOrigin", p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

// Add the RequestService as a hosted service
builder.Services.AddHostedService<RequestService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(
        c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "AlzBuddy API v1");
           
        });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("_specifiOrigin");
app.MapControllers();

await app.RunAsync();
