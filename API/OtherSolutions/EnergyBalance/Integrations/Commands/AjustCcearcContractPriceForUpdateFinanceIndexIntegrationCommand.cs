namespace API.OtherSolutions.EnergyBalance.Integrations.Commands
{
    public class AjustCcearcContractPriceForUpdateFinanceIndexIntegrationCommand
    {
        public AjustCcearcContractPriceForUpdateFinanceIndexIntegrationCommand(string sagaId, string contractId)
        {
            SagaId = sagaId;
            ContractId = contractId;
        }

        public string SagaId { get; private set; }
        public string ContractId { get; private set; }
    }
}
