﻿using API.OtherSolutions.CCEARc.IntegrationsEvents;
using API.OtherSolutions.CCEARc.InternalEvents;
using API.OtherSolutions.EnergyBalance.IntegrationsCommands;
using Rebus.Bus;
using Rebus.Handlers;

namespace API.OtherSolutions.CCEARc.IntegrationsHandlers
{
    public class PriceCcearcReajustedIntegrationCommandHandler : IHandleMessages<PriceCcearcReajustedIntegrationCommand>
    {
        public readonly IBus _bus;

        public PriceCcearcReajustedIntegrationCommandHandler(IBus bus)
        {
            _bus = bus;
        }

        public Task Handle(PriceCcearcReajustedIntegrationCommand message)
        {
            //Todo: ajustar o preço do contrato internamente no MS.
            _bus.Publish(new CcearcContractReajustedIntegrationEvent(message.ContractId));
            _bus.Publish(new CcearcContractReajustedForIndexInternalEvent(message.SagaId, message.ContractId));
            return Task.CompletedTask;            
        }
    }
}
