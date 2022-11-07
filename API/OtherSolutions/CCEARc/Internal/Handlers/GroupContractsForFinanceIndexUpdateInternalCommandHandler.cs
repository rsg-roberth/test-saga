using API.OtherSolutions.CCEARc.Integrations.Events;
using API.OtherSolutions.CCEARc.Internal.Commands;
using Rebus.Bus;
using Rebus.Handlers;

namespace API.OtherSolutions.CCEARc.Internal.Handlers
{
    public class GroupContractsForFinanceIndexUpdateInternalCommandHandler : IHandleMessages<GroupContractsForFinanceIndexUpdateInternalCommand>
    {
        public readonly IBus _bus;

        public GroupContractsForFinanceIndexUpdateInternalCommandHandler(IBus bus)
        {
            _bus = bus;
        }

        public Task Handle(GroupContractsForFinanceIndexUpdateInternalCommand message)
        {
            //Todo: fazer o agrupamento para envio ao financeiro.
            _bus.Publish(new CcearcContractsGroupPricesAjustedForUpdateFinanceIndexIntegrationEvent(message.Contracts));
            return Task.CompletedTask;
        }
    }
}
