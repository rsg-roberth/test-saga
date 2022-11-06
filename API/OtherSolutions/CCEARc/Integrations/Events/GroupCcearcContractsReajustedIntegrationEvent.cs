namespace API.OtherSolutions.CCEARc.Integrations.Events
{
    public class GroupCcearcContractsReajustedIntegrationEvent
    {
        public GroupCcearcContractsReajustedIntegrationEvent(List<string> contracts)
        {
            Contracts = contracts;
        }

        public List<string> Contracts { get; private set; }
    }
}
