namespace API.OtherSolutions.CCEARc.Integrations.Events
{
    public class CcearcContractPriceAjustedForUpdateFinanceIndexIntegrationEvent
    {
        public CcearcContractPriceAjustedForUpdateFinanceIndexIntegrationEvent(string contract)
        {
            Contract = contract;
        }

        public string Contract { get; private set; }
    }
}
