namespace API.OtherSolutions.CCEARc.Internal.Commands
{
    public class GroupContractsForFinanceIndexUpdateInternalCommand
    {
        public GroupContractsForFinanceIndexUpdateInternalCommand(List<string> contracts)
        {
            Contracts = contracts;
        }

        public List<string> Contracts { get; private set; }
    }
}
