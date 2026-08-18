using Inter_seller_task.Data;
using Inter_seller_task.Data.Seed;
using Inter_seller_task.Extensions;
using Inter_seller_task.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using QuestPDF.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

QuestPDF.Settings.License = LicenseType.Evaluation;
builder.Services.AddApplicationServices(builder.Configuration); 
builder.Services.AddJwtAuthentication(builder.Configuration);



// Add services to the container.


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerConfiguration();



var app = builder.Build();

using (var scope = app.Services.CreateScope()) 
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ApplicationDbContext>();
    
    var passwordHasher = services.GetRequiredService<PasswordHasher<User>>();
    await DbSeeder.SeedAsync(context, passwordHasher);

}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
