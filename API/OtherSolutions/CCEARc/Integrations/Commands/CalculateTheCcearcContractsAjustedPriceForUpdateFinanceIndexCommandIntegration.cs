namespace API.OtherSolutions.CCEARc.Integrations.Commands
{
    public class CalculateTheCcearcContractsAjustedPriceForUpdateFinanceIndexCommandIntegration
    {
        public CalculateTheCcearcContractsAjustedPriceForUpdateFinanceIndexCommandIntegration(string sagaId)
        {
            SagaId = sagaId;
        }

        public string SagaId { get; private set; }
    }
}
