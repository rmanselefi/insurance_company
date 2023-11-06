var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProposalService, ProposalService>();
builder.Services.AddScoped<IClientCompanyService, ClientCompanyService>();
builder.Services.AddScoped<IInsurancePlanService, InsurancePlanService>();

services.AddSingleton<IProposalRepository, InMemoryProposalRepository>();
services.AddSingleton<ICompanyRepository, InMemoryCompanyRepository>();


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
