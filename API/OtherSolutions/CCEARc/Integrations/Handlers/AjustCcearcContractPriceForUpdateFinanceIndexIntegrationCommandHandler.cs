using API.OtherSolutions.CCEARc.Integrations.Events;
using API.OtherSolutions.CCEARc.Internal.Events;
using API.OtherSolutions.EnergyBalance.Integrations.Commands;
using Rebus.Bus;
using Rebus.Handlers;

namespace API.OtherSolutions.CCEARc.Integrations.Handlers
{
    public class AjustCcearcContractPriceForUpdateFinanceIndexIntegrationCommandHandler : IHandleMessages<AjustCcearcContractPriceForUpdateFinanceIndexIntegrationCommand>
    {
        public readonly IBus _bus;

        public AjustCcearcContractPriceForUpdateFinanceIndexIntegrationCommandHandler(IBus bus)
        {
            _bus = bus;
        }

        public Task Handle(AjustCcearcContractPriceForUpdateFinanceIndexIntegrationCommand message)
        {
            //Todo: ajustar o preço do contrato internamente no MS.
            _bus.Publish(new CcearcContractPriceAjustedForUpdateFinanceIndexIntegrationEvent(message.ContractId));
            _bus.Publish(new CcearcContractPriceAjustedForUpdateFinanceIndexInternalEvent(message.SagaId, message.ContractId));
            return Task.CompletedTask;
        }
    }
}
