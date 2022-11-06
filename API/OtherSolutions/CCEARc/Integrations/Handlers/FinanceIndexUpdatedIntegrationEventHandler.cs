using API.OtherSolutions.CCEARc.Internal.Commands;
using API.OtherSolutions.Finance.Integrations.Events;
using Rebus.Bus;
using Rebus.Handlers;

namespace API.OtherSolutions.CCEARc.Integrations.Handlers
{
    public class FinanceIndexUpdatedIntegrationEventHandler : IHandleMessages<FinanceIndexUpdatedIntegrationEvent>
    {
        private readonly IBus _bus;

        public FinanceIndexUpdatedIntegrationEventHandler(IBus bus)
        {
            _bus = bus;
        }

        public Task Handle(FinanceIndexUpdatedIntegrationEvent message)
        {
            //Todo: checagens de vai acionar a Saga ou não.
            _bus.Publish(new StartSagaForAjusteContractPriceForUpdateFinanceIndexInternalCommand());
            return Task.CompletedTask;
        }
    }
}
