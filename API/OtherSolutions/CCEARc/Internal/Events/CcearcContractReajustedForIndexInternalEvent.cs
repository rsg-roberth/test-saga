namespace API.OtherSolutions.CCEARc.Internal.Events
{
    public class CcearcContractReajustedForIndexInternalEvent
    {
        public CcearcContractReajustedForIndexInternalEvent(string sagaId, string contractId)
        {
            SagaId = sagaId;
            ContractId = contractId;
        }

        public string SagaId { get; private set; }
        public string ContractId { get; private set; }
    }
}
