namespace API.OtherSolutions.CCEARc.IntegrationsEvents
{
    public class CcearcContractReajustedIntegrationEvent
    {
        public CcearcContractReajustedIntegrationEvent(string contract)
        {
            Contract = contract;
        }

        public string Contract { get; private set; }
    }
}
