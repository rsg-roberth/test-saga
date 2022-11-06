using API.OtherSolutions.CCEARc.Integrations.Events;
using API.OtherSolutions.CCEARc.Internal.Commands;
using Rebus.Bus;
using Rebus.Handlers;

namespace API.OtherSolutions.CCEARc.Internal.Handlers
{
    public class GroupCcearcContractsInternalCommandHandler : IHandleMessages<GroupCcearcContractsInternalCommand>
    {
        public readonly IBus _bus;

        public GroupCcearcContractsInternalCommandHandler(IBus bus)
        {
            _bus = bus;
        }

        public Task Handle(GroupCcearcContractsInternalCommand message)
        {
            //Todo: fazer o agrupamento para envio ao financeiro.
            _bus.Publish(new GroupCcearcContractsReajustedIntegrationEvent(message.Contracts));
            return Task.CompletedTask;
        }
    }
}
