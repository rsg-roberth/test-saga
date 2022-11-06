using Rebus.Sagas;

namespace API.OtherSolutions.CCEARc.Saga
{
    public class FinancialIndexUpdateSagaData:SagaData
    {
        public string CorrelationId { get; set; } = string.Empty;
        public List<string> ContratcToReajust { get; set; } = new();
        public List<string> ReajustedContracts { get; set; } = new();
        public bool IsDone()=> !ContratcToReajust.Except(ReajustedContracts).ToList().Any();        
    }
}
