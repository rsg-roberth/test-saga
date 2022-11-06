namespace API.OtherSolutions.CCEARc.IntegrationsCommands
{
    public class CalculateCcearcContractsForIndexReadjustmentCommandIntegration 
    {
        public CalculateCcearcContractsForIndexReadjustmentCommandIntegration(string sagaId)
        {
            SagaId = sagaId;
        }

        public string SagaId { get; private set; }
    }    
}
