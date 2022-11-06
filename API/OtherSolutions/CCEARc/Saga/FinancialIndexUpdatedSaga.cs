using API.OtherSolutions.CCEARc.IntegrationsCommands;
using API.OtherSolutions.CCEARc.InternalCommands;
using API.OtherSolutions.CCEARc.InternalEvents;
using API.OtherSolutions.EnergyBalance.IntegrationsCommands;
using Rebus.Bus;
using Rebus.Handlers;
using Rebus.Messages;
using Rebus.Sagas;

namespace API.OtherSolutions.CCEARc.Saga
{
    public class FinancialIndexUpdatedSaga :
            Saga<FinancialIndexUpdateSagaData>,
            IAmInitiatedBy<FinancialIndexValuesChangedInternalCommand>,
            IHandleMessages<CcearcContractForReajustmentCommandIntegration>,
            IHandleMessages<CcearcContractReajustedForIndexInternalEvent>        
    {
        private readonly IBus _bus;

        public FinancialIndexUpdatedSaga(IBus bus)
        {
            _bus = bus;
        }

        public Task Handle(FinancialIndexValuesChangedInternalCommand message)
        {
            _bus.Publish(new CalculateCcearcContractsForIndexReadjustmentCommandIntegration(message.SagaId));
            return Task.CompletedTask;
        }

        public Task Handle(CcearcContractForReajustmentCommandIntegration message)
        {
            Data.ContratcToReajust = message.Contracts.ToList();
            return Task.CompletedTask;
        }

        public Task Handle(CcearcContractReajustedForIndexInternalEvent message)
        {            
            Data.ReajustedContracts.Add(message.ContractId);
            if (Data.IsDone())
            {
                _bus.Publish(new GroupCcearcContractsInternalCommand(Data.ReajustedContracts));
                MarkAsComplete();
            }
            return Task.CompletedTask;
        }

        protected override void CorrelateMessages(ICorrelationConfig<FinancialIndexUpdateSagaData> config)
        {
            config.Correlate<FinancialIndexValuesChangedInternalCommand>(message => message.SagaId, d => d.CorrelationId);
            config.Correlate<CcearcContractForReajustmentCommandIntegration>(message => message.SagaId, d => d.CorrelationId);
            config.Correlate<CcearcContractReajustedForIndexInternalEvent>(message => message.SagaId, d => d.CorrelationId);
        }
    }
}
