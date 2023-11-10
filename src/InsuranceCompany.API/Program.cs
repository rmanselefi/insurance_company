
using InsuranceCompany.Infrastructure.Repositories;
using InsuranceCompany.Application.Services;
using InsuranceCompany.Domain.Interfaces;
using InsuranceCompany.Infrastructure.Persistence;
using InsuranceCompany.Application.Interfaces;
using InsuranceCompany.API.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options =>
{
    options.Filters.Add(new GlobalExceptionFilter());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProposalService, ProposalService>();
builder.Services.AddScoped<IPlanService, PlanService>();

builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddSingleton<IPlanRepository, InMemoryPlanRepository>();


builder.Services.AddSingleton<IProposalRepository, InMemoryProposalRepository>();
builder.Services.AddSingleton<ICompanyRepository, InMemoryCompanyRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
