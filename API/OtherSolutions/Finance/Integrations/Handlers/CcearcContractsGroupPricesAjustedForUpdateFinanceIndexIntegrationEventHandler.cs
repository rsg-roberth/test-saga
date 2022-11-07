using API.OtherSolutions.CCEARc.Integrations.Events;
using Rebus.Handlers;

namespace API.OtherSolutions.Finance.Integrations.Handlers
{
    public class CcearcContractsGroupPricesAjustedForUpdateFinanceIndexIntegrationEventHandler : IHandleMessages<CcearcContractsGroupPricesAjustedForUpdateFinanceIndexIntegrationEvent>
    {
        public Task Handle(CcearcContractsGroupPricesAjustedForUpdateFinanceIndexIntegrationEvent message)
        {
            var contracts = message.Contracts;
            //Todo: ajustar o contrato pedido/fatura/pagamentos no Financeiro
            return Task.CompletedTask;
        }
    }
}
