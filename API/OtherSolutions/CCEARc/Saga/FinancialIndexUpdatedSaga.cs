using API.OtherSolutions.CCEARc.Integrations.Commands;
using API.OtherSolutions.CCEARc.Internal.Commands;
using API.OtherSolutions.CCEARc.Internal.Events;
using API.OtherSolutions.EnergyBalance.Integrations.Events;
using Rebus.Messages;
using Rebus.Bus;
using Rebus.Handlers;
using Rebus.Sagas;

namespace API.OtherSolutions.CCEARc.Saga
{
    public class FinancialIndexUpdatedSaga :
            Saga<FinancialIndexUpdateSagaData>,
            IAmInitiatedBy<StartSagaForAjusteContractPriceForUpdateFinanceIndexInternalCommand>,
            IHandleMessages<GetedRelationTheContractsForAjusteThePriceForUpdateFinanceIndexIntegrationEvent>,
            IHandleMessages<CcearcContractPriceAjustedForUpdateFinanceIndexInternalEvent>        
    {
        private readonly IBus _bus;

        public FinancialIndexUpdatedSaga(IBus bus)
        {
            _bus = bus;
        }

        public Task Handle(StartSagaForAjusteContractPriceForUpdateFinanceIndexInternalCommand message)
        {
            _bus.Publish(new CalculateTheCcearcContractsAjustedPriceForUpdateFinanceIndexCommandIntegration(message.SagaId));
            return Task.CompletedTask;
        }

        public Task Handle(GetedRelationTheContractsForAjusteThePriceForUpdateFinanceIndexIntegrationEvent message)
        {
            Data.ContratcToReajust = message.Contracts;
            if (!Data.ContratcToReajust.Any())
            {
                MarkAsComplete();
            }
            return Task.CompletedTask;
        }

        public Task Handle(CcearcContractPriceAjustedForUpdateFinanceIndexInternalEvent message)
        {            
            Data.ReajustedContracts.Add(message.ContractId);
            if (Data.IsDone())
            {
                _bus.Publish(new GroupContractsForFinanceIndexUpdateInternalCommand(Data.ReajustedContracts));
                MarkAsComplete();
            }
            return Task.CompletedTask;
        }

        protected override void CorrelateMessages(ICorrelationConfig<FinancialIndexUpdateSagaData> config)
        {
            //config.Correlate<StartSagaForAjusteContractPriceForUpdateFinanceIndexInternalCommand>(message => message.SagaId, d => d.CorrelationId);
            //config.Correlate<GetedRelationTheContractsForAjusteThePriceForUpdateFinanceIndexIntegrationEvent>(message => message.SagaId, d => d.CorrelationId);
            //config.Correlate<CcearcContractPriceAjustedForUpdateFinanceIndexInternalEvent>(message => message.SagaId, d => d.CorrelationId);

            config.CorrelateHeader<StartSagaForAjusteContractPriceForUpdateFinanceIndexInternalCommand>(Headers.CorrelationId, d => d.CorrelationId);
            config.CorrelateHeader<GetedRelationTheContractsForAjusteThePriceForUpdateFinanceIndexIntegrationEvent>(Headers.CorrelationId, d => d.CorrelationId);
            config.CorrelateHeader<CcearcContractPriceAjustedForUpdateFinanceIndexInternalEvent>(Headers.CorrelationId, d => d.CorrelationId);            
        }
    }
}
