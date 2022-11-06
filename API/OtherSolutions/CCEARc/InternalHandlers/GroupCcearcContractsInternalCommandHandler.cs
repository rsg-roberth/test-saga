using API.OtherSolutions.CCEARc.IntegrationsEvents;
using API.OtherSolutions.CCEARc.InternalCommands;
using Rebus.Bus;
using Rebus.Handlers;

namespace API.OtherSolutions.CCEARc.InternalHandlers
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
