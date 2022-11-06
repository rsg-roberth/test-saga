using API.OtherSolutions.EnergyBalance.IntegrationsCommands;
using API.OtherSolutions.EnergyBalance.InternalCommand;
using Rebus.Bus;
using Rebus.Handlers;

namespace API.OtherSolutions.EnergyBalance.InternalHandlers
{
    public class CalculatePriceContractCcearcInternalCommandHandler : IHandleMessages<CalculatePriceOperationsCcearcInternalCommand>
    {
        public readonly IBus _bus;

        public CalculatePriceContractCcearcInternalCommandHandler(IBus bus)
        {
            _bus = bus;
        }

        public Task Handle(CalculatePriceOperationsCcearcInternalCommand message)
        {
            //Todo: implementar o calculo

            _bus.Publish(new PriceCcearcReajustedIntegrationCommand(message.SagaId, message.ContractId));
            return Task.CompletedTask;

        }
    }
}
