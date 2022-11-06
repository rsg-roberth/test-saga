using API.OtherSolutions.CCEARc.IntegrationsCommands;
using API.OtherSolutions.EnergyBalance.IntegrationsCommands;
using API.OtherSolutions.EnergyBalance.InternalCommand;
using Rebus.Bus;
using Rebus.Handlers;

namespace API.OtherSolutions.EnergyBalance.IntegrationsHandlers
{
    public class CalculateCcearcContractsForIndexReadjustmentCommandIntegrationHandler : IHandleMessages<CalculateCcearcContractsForIndexReadjustmentCommandIntegration>
    {
        public readonly IBus _bus;

        public CalculateCcearcContractsForIndexReadjustmentCommandIntegrationHandler(IBus bus)
        {
            _bus = bus;
        }

        public Task Handle(CalculateCcearcContractsForIndexReadjustmentCommandIntegration message)
        {
            var contracts = new List<string>()
            {
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
            };

            _bus.Publish(new CcearcContractForReajustmentCommandIntegration(message.SagaId,contracts));

            foreach (var item in contracts)
            {
                _bus.Publish(new CalculatePriceOperationsCcearcInternalCommand(message.SagaId, item));
            }

            return Task.CompletedTask;             
        }
    }
}
