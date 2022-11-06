
using API;
using API.OtherSolutions.CCEARc.IntegrationsCommands;
using API.OtherSolutions.CCEARc.IntegrationsEvents;
using API.OtherSolutions.CCEARc.IntegrationsHandlers;
using API.OtherSolutions.CCEARc.InternalCommands;
using API.OtherSolutions.CCEARc.InternalEvents;
using API.OtherSolutions.EnergyBalance.IntegrationsCommands;
using API.OtherSolutions.EnergyBalance.IntegrationsHandlers;
using API.OtherSolutions.EnergyBalance.InternalCommand;
using API.OtherSolutions.Finance.IntegrationsEvents;
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
    c.Subscribe<FinancialIndexValuesChangedIntegrationEvent>().Wait();//Recebendo indice do financeiro - ajuste
    c.Subscribe<FinancialIndexValuesChangedInternalCommand>().Wait();//Realizando checagem ccearc e iniciando a saga
    c.Subscribe<CalculateCcearcContractsForIndexReadjustmentCommandIntegration>().Wait();//Disparando evento para o Energy Balance
    c.Subscribe<CcearcContractForReajustmentCommandIntegration>().Wait();//Recebendo lista com os ids dos contratos que ser�o recalculados no EnergyBalance
    c.Subscribe<CalculatePriceOperationsCcearcInternalCommand>().Wait();//Disparando o comando interno no EnergyBalance para calular o preco dos contratos.
    c.Subscribe<PriceCcearcReajustedIntegrationCommand>().Wait();//Disparando do Energy Balance para o Ccearc o evento com o contrato com o pre�o ajustado.
    c.Subscribe<CcearcContractReajustedForIndexInternalEvent>().Wait();//Recebendo o contrato que foi ajustado internamente e enviado para o BI
    c.Subscribe<GroupCcearcContractsInternalCommand>().Wait();//Realizando o agrupamento para enviar para o financeiro.
    c.Subscribe<GroupCcearcContractsReajustedIntegrationEvent>().Wait();//Recebendo no financeiro os o agrupamento das opera��es ccearc para ajustar o pedido/fatura/pagamentos
    c.Subscribe<CcearcContractReajustedIntegrationEvent>().Wait();//Recebendo no BI o evento do ccearc para ajuste 
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
