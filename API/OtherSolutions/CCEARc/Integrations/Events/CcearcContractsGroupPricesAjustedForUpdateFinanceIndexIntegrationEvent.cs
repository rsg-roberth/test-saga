namespace API.OtherSolutions.CCEARc.Integrations.Events
{
    public class CcearcContractsGroupPricesAjustedForUpdateFinanceIndexIntegrationEvent
    {
        public CcearcContractsGroupPricesAjustedForUpdateFinanceIndexIntegrationEvent(List<string> contracts)
        {
            Contracts = contracts;
        }

        public List<string> Contracts { get; private set; }
    }
}
