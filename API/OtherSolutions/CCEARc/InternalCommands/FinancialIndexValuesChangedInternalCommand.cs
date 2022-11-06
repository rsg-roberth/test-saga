namespace API.OtherSolutions.CCEARc.InternalCommands
{
    public class FinancialIndexValuesChangedInternalCommand
    {
        public string SagaId { get; set; }

        public FinancialIndexValuesChangedInternalCommand()
        {
            SagaId = Guid.NewGuid().ToString();
        }
    }
}
