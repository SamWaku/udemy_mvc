using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("Default");
app.UseHttpsRedirection();
app.MapControllers();

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.Run();