namespace API.OtherSolutions.EnergyBalance.Internal.Commands
{
    public class CalculatePriceOperationsCcearcInternalCommand
    {
        public CalculatePriceOperationsCcearcInternalCommand(string sagaId, string contractId)
        {
            SagaId = sagaId;
            ContractId = contractId;
        }

        public string SagaId { get; private set; }
        public string ContractId { get; private set; }
    }
}
