using FluentValidation;
using Microsoft.EntityFrameworkCore;
using NoteWebApi.Datas;
using NoteWebApi.Dtos;
using NoteWebApi.Mapping;
using NoteWebApi.Repository.Concretes;
using NoteWebApi.Repository.Interface;
using NoteWebApi.Services.Concretes;
using NoteWebApi.Services.Repositories;
using NoteWebApi.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(NoteProfile));
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IValidator<CreateNoteDto>, CreateNoteDtoValidator>();

//Repository
builder.Services.AddScoped<INoteRepository, NoteRepository>();

//service
builder.Services.AddScoped<INoteService, NoteService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
