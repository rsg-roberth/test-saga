namespace API.OtherSolutions.EnergyBalance.IntegrationsCommands
{
    public class CcearcContractForReajustmentCommandIntegration
    {
        public CcearcContractForReajustmentCommandIntegration(string sagaId, IEnumerable<string> contracts)
        {
            SagaId = sagaId;
            Contracts = contracts;
        }

        public string SagaId { get; set; }
        public IEnumerable<string> Contracts { get; private set; }
        
    }
}
