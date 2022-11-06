using API.OtherSolutions.CCEARc.Integrations.Events;
using Rebus.Handlers;

namespace API.OtherSolutions.BI.Integrations.Handlers
{
    public class CcearcContractReajustedIntegrationEventHandler : IHandleMessages<CcearcContractReajustedIntegrationEvent>
    {
        public Task Handle(CcearcContractReajustedIntegrationEvent message)
        {
            //Todo: ajustar o contrato no BI
            return Task.CompletedTask;
        }
    }
}
