using API.OtherSolutions.CCEARc.Integrations.Events;
using Rebus.Handlers;

namespace API.OtherSolutions.BI.Integrations.Handlers
{
    public class CcearcContractPriceAjustedForUpdateFinanceIndexIntegrationEventHandler : IHandleMessages<CcearcContractPriceAjustedForUpdateFinanceIndexIntegrationEvent>
    {
        public Task Handle(CcearcContractPriceAjustedForUpdateFinanceIndexIntegrationEvent message)
        {
            //Todo: ajustar o contrato no BI
            return Task.CompletedTask;
        }
    }
}
