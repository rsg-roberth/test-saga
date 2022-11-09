using API.OtherSolutions.CCEARc.Integrations.Commands;
using API.OtherSolutions.EnergyBalance.Integrations.Events;
using API.OtherSolutions.EnergyBalance.Internal.Commands;
using Rebus.Bus;
using Rebus.Handlers;

namespace API.OtherSolutions.EnergyBalance.Integrations.Handlers
{
    public class CalculateTheCcearcContractsAjustedPriceForUpdateFinanceIndexCommandIntegrationHandler : IHandleMessages<CalculateTheCcearcContractsAjustedPriceForUpdateFinanceIndexCommandIntegration>
    {
        public readonly IBus _bus;

        public CalculateTheCcearcContractsAjustedPriceForUpdateFinanceIndexCommandIntegrationHandler(IBus bus)
        {
            _bus = bus;
        }

        public Task Handle(CalculateTheCcearcContractsAjustedPriceForUpdateFinanceIndexCommandIntegration message)
        {
            var contracts = new List<string>()
            {
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
            };

            _bus.Publish(new GetedRelationTheContractsForAjusteThePriceForUpdateFinanceIndexIntegrationEvent(message.SagaId, contracts));

            foreach (var item in contracts)
            {
                _bus.Publish(new CalculatePriceOperationsCcearcInternalCommand(message.SagaId, item));
            }

            return Task.CompletedTask;
        }
    }
}
