using FluxoCaixa.Application;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

//Start Check. Verifica se todas as informações necessarias para a aplicação funcionar foram passadas

if (string.IsNullOrWhiteSpace(configuration["SERVICE_NAME"]))
{
    throw new ApplicationException("SERVICE_NAME não especificado");
}

if (string.IsNullOrWhiteSpace(configuration["SERVICE_VERSION"]))
{
    throw new ApplicationException("SERVICE_VERSION não especificado");
}

if (string.IsNullOrWhiteSpace(configuration["ASPNETCORE_ENVIRONMENT"]))
{
    throw new ApplicationException("ENVIRONMENT não especificado");
}

if (string.IsNullOrWhiteSpace(configuration["MAX_MEMORY"]))
{
    throw new ApplicationException("MAX_MEMORY não especificado");
}

//builder.Services.AddScoped<IFluxoCaixaAppService, FluxoCaixaAppService>();
builder.Services.AddScoped<IFluxoCaixaAppService, FluxoCaixaValidator>(provider =>
    new FluxoCaixaValidator(
        new FluxoCaixaAppService()));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();