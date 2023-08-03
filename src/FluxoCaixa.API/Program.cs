using FluxoCaixa.Application;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

//Start Check. Verifica se todas as informa��es necessarias para a aplica��o funcionar foram passadas

if (string.IsNullOrWhiteSpace(configuration["SERVICE_NAME"]))
{
    throw new ApplicationException("SERVICE_NAME n�o especificado");
}

if (string.IsNullOrWhiteSpace(configuration["SERVICE_VERSION"]))
{
    throw new ApplicationException("SERVICE_VERSION n�o especificado");
}

if (string.IsNullOrWhiteSpace(configuration["ASPNETCORE_ENVIRONMENT"]))
{
    throw new ApplicationException("ENVIRONMENT n�o especificado");
}

if (string.IsNullOrWhiteSpace(configuration["MAX_MEMORY"]))
{
    throw new ApplicationException("MAX_MEMORY n�o especificado");
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