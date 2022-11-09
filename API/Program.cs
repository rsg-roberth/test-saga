
using API;
using API.OtherSolutions.CCEARc.Integrations.Commands;
using API.OtherSolutions.CCEARc.Integrations.Events;
using API.OtherSolutions.CCEARc.Internal.Commands;
using API.OtherSolutions.CCEARc.Internal.Events;
using API.OtherSolutions.EnergyBalance.Integrations.Commands;
using API.OtherSolutions.EnergyBalance.Integrations.Events;
using API.OtherSolutions.EnergyBalance.Internal.Commands;
using API.OtherSolutions.Finance.Integrations.Events;
using Rebus.Persistence.InMem;
using Rebus.Routing.TypeBased;
using Rebus.ServiceProvider;
using Rebus.Transport.InMem;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var nomeFila = "fila_rebus";

builder.Services.AddRebus(configure => configure
    .Transport(t => t.UseInMemoryTransport(new InMemNetwork(), nomeFila))
    //.Transport(t => t.UseRabbitMq("amqp://localhost", nomeFila))
    .Subscriptions(s => s.StoreInMemory())
    .Routing(r =>
    {
        r.TypeBased().MapAssemblyOf<MapAssemblyOfRebus>(nomeFila);
    })
    .Sagas(s => s.StoreInMemory())
    .Options(o =>
    {
        o.SetNumberOfWorkers(1);
        o.SetMaxParallelism(1);
        o.SetBusName("Demo Rebus");
    })
);

builder.Services.AutoRegisterHandlersFromAssemblyOf<MapAssemblyOfRebus>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRebus(c =>
{
    c.Subscribe<FinanceIndexUpdatedIntegrationEvent>().Wait();
    //Endpoint do financeiro para atualização de indice é acionado.
    //Financeiro dispara o evento informando que o indice foi atualizado.
    //Ccearc recebe o evento para inicio do processo de atualização dos preços dos contratos.
    
    c.Subscribe<StartSagaForAjusteContractPriceForUpdateFinanceIndexInternalCommand>().Wait();
    //Ccearc faz a checagem se tem contratos que tem que ter o preço atualizado.
    //Se tiver, dispara o command para inicio da Saga.


    c.Subscribe<CalculateTheCcearcContractsAjustedPriceForUpdateFinanceIndexCommandIntegration>().Wait();
    //Ccearc dispara o comando para calcular o preço ajustado dos contratos pela atualização de index financeiro.
    //EnergyBalance recebe o comando.

    c.Subscribe<GetedRelationTheContractsForAjusteThePriceForUpdateFinanceIndexIntegrationEvent>().Wait();
    //EnergyBalance obtem os contratos que terão os preços ajustados e dispara o evento com o id deles.
    //Ccearc recebe o evento e atualiza na Saga a lista dos contratos a serem ajustados.

    c.Subscribe<CalculatePriceOperationsCcearcInternalCommand>().Wait();
    //EnergyBalance dispara command interno para calular o preco dos contratos.

    c.Subscribe<AjustCcearcContractPriceForUpdateFinanceIndexIntegrationCommand>().Wait();
    //EnergyBalance calcula o preço ajustado do contrato e dispara o command para o Ccearc
    //Ccearc recebe o command, ajusta internamente, dispara o evento para o BI e o evento para a Saga.

    c.Subscribe<CcearcContractPriceAjustedForUpdateFinanceIndexInternalEvent>().Wait();
    //Ccearc dispara um evento interno para a Saga falando que o contrato foi ajustado no MS.

    c.Subscribe<GroupContractsForFinanceIndexUpdateInternalCommand>().Wait();
    //Ccearc dispara um command interno para agrupamento dos contratos. Posteriormente são enviado para o financeiro através de outro event/command
    
    c.Subscribe<CcearcContractsGroupPricesAjustedForUpdateFinanceIndexIntegrationEvent>().Wait();
    //Ccearc após atualizar internamente todos os contratos, faz o agrupamento por company e manda para o financeiro.
    //Financeiro, recebe e evento e cria pedido, fatura e pagamentos.
    
    c.Subscribe<CcearcContractPriceAjustedForUpdateFinanceIndexIntegrationEvent>().Wait();
    //Ccearc encaminha o evento de preço do contrato ajustado para o BI.
    //BI recebe o evento para atualizar o contrato.
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
