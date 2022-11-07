using API.OtherSolutions.CCEARc.Integrations.Events;
using Rebus.Handlers;

namespace API.OtherSolutions.Finance.Integrations.Handlers
{
    public class CcearcContractsGroupPricesAjustedForUpdateFinanceIndexIntegrationEventHandler : IHandleMessages<CcearcContractsGroupPricesAjustedForUpdateFinanceIndexIntegrationEvent>
    {
        public Task Handle(CcearcContractsGroupPricesAjustedForUpdateFinanceIndexIntegrationEvent message)
        {
            var contracts = message.Contracts;
            //Todo: ajustar o contrato no Financeiro
            return Task.CompletedTask;
        }
    }
}
