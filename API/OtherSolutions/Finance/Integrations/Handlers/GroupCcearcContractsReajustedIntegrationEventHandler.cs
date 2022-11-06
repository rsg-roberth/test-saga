using API.OtherSolutions.CCEARc.Integrations.Events;
using Rebus.Handlers;

namespace API.OtherSolutions.Finance.Integrations.Handlers
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
