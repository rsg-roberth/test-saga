using API.OtherSolutions.CCEARc.InternalCommands;
using API.OtherSolutions.Finance.IntegrationsEvents;
using Rebus.Bus;
using Rebus.Handlers;

namespace API.OtherSolutions.CCEARc.IntegrationsHandlers
{
    public class FinancialIndexValuesChangedIntegrationEventHandler : IHandleMessages<FinancialIndexValuesChangedIntegrationEvent>
    {
        private readonly IBus _bus;

        public FinancialIndexValuesChangedIntegrationEventHandler(IBus bus)
        {
            _bus = bus;
        }

        public Task Handle(FinancialIndexValuesChangedIntegrationEvent message)
        {
            //Todo: checagens de vai acionar a Saga ou não.

            _bus.Publish(new FinancialIndexValuesChangedInternalCommand());
            return Task.CompletedTask;
        }
    }
}
