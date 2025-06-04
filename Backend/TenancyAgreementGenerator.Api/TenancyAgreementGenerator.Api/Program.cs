using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TenancyAgreementGenerator.Api.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

//Add Interfaces here
builder.Services.AddScoped<IPdfGeneratorService, PdfGeneratorService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
}); 

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();
app.Run();