using Rebus.Sagas;

namespace API.OtherSolutions.CCEARc.Saga
{
    public class FinancialIndexUpdateSagaData:SagaData
    {
        public string CorrelationId { get; set; } = string.Empty;
        public IEnumerable<string> ContratcToReajust { get; set; } = Enumerable.Empty<string>();
        public List<string> ReajustedContracts { get; set; } = new();
        public bool IsDone()=> !ContratcToReajust.Except(ReajustedContracts).ToList().Any();        
    }
}
