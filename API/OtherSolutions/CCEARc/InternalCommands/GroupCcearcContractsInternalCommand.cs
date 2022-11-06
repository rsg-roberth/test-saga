namespace API.OtherSolutions.CCEARc.InternalCommands
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
