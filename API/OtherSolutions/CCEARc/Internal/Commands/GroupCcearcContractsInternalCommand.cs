namespace API.OtherSolutions.CCEARc.Internal.Commands
{
    public class GroupCcearcContractsInternalCommand
    {
        public GroupCcearcContractsInternalCommand(List<string> contracts)
        {
            Contracts = contracts;
        }

        public List<string> Contracts { get; private set; }
    }
}
