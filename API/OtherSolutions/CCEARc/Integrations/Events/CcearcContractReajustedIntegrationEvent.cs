namespace API.OtherSolutions.CCEARc.Integrations.Events
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
