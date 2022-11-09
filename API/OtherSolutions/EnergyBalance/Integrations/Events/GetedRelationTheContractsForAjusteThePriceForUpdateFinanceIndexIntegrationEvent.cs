namespace API.OtherSolutions.EnergyBalance.Integrations.Events
{
    public class GetedRelationTheContractsForAjusteThePriceForUpdateFinanceIndexIntegrationEvent
    {
        public GetedRelationTheContractsForAjusteThePriceForUpdateFinanceIndexIntegrationEvent(string sagaId, IEnumerable<string> contracts)
        {
            SagaId = sagaId;
            Contracts = contracts;
        }

        public string SagaId { get; set; }
        public IEnumerable<string> Contracts { get; private set; }

    }
}
