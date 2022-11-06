namespace API.OtherSolutions.EnergyBalance.InternalCommand
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
