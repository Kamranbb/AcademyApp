using AcademyApp.Application.Dtos.GroupDtos;
using AcademyApp.Application.Implementations;
using AcademyApp.Application.Interfaces;
using AcademyApp.Application.Profiles;
using AcademyApp.Data.Data;
using FluentValidation;
using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AcademyAppContext>(opt =>
{
    opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IGroupService, GroupService>();
builder.Services.AddScoped<IStudentService, StudentService>();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

builder.Services.AddValidatorsFromAssemblyContaining<GroupCreateDtoValidator>();

builder.Services.AddFluentValidationRulesToSwagger();

builder.Services.AddAutoMapper(opt =>
{
    opt.AddProfile(new MapperProfile());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
