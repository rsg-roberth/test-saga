namespace API.OtherSolutions.CCEARc.Internal.Events
{
    public class CcearcContractPriceAjustedForUpdateFinanceIndexInternalEvent
    {
        public CcearcContractPriceAjustedForUpdateFinanceIndexInternalEvent(string sagaId, string contractId)
        {
            SagaId = sagaId;
            ContractId = contractId;
        }

        public string SagaId { get; private set; }
        public string ContractId { get; private set; }
    }
}
