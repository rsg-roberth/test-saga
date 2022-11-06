
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

    c.Subscribe<CalculatePriceOperationsCcearcInternalCommand>().Wait();//Disparando o comando interno no EnergyBalance para calular o preco dos contratos.
    c.Subscribe<PriceCcearcReajustedIntegrationCommand>().Wait();//Disparando do Energy Balance para o Ccearc o evento com o contrato com o preço ajustado.
    c.Subscribe<CcearcContractReajustedForIndexInternalEvent>().Wait();//Recebendo o contrato que foi ajustado internamente e enviado para o BI
    c.Subscribe<GroupCcearcContractsInternalCommand>().Wait();//Realizando o agrupamento para enviar para o financeiro.
    c.Subscribe<GroupCcearcContractsReajustedIntegrationEvent>().Wait();//Recebendo no financeiro os o agrupamento das operações ccearc para ajustar o pedido/fatura/pagamentos
    c.Subscribe<CcearcContractReajustedIntegrationEvent>().Wait();//Recebendo no BI o evento do ccearc para ajuste 
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
