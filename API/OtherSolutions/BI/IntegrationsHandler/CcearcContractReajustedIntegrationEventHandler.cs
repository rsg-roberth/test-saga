using API.OtherSolutions.CCEARc.IntegrationsEvents;
using Rebus.Handlers;

namespace API.OtherSolutions.BI.IntegrationsHandler
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
