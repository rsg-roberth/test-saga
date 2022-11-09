namespace API.OtherSolutions.CCEARc.Internal.Commands
{
    public class StartSagaForAjusteContractPriceForUpdateFinanceIndexInternalCommand
    {
        public string SagaId { get; set; }

        public StartSagaForAjusteContractPriceForUpdateFinanceIndexInternalCommand()
        {
            SagaId = Guid.NewGuid().ToString();
        }
    }
}
