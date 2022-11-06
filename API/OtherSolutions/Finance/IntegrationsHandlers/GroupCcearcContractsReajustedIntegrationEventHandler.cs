using API.OtherSolutions.CCEARc.IntegrationsEvents;
using Rebus.Handlers;

namespace API.OtherSolutions.Finance.IntegrationsHandlers
{
    public class GroupCcearcContractsReajustedIntegrationEventHandler : IHandleMessages<GroupCcearcContractsReajustedIntegrationEvent>
    {
        public Task Handle(GroupCcearcContractsReajustedIntegrationEvent message)
        {            
            var contracts = message.Contracts;
            //Todo: ajustar o contrato no Financeiro
            return Task.CompletedTask;
        }
    }
}
