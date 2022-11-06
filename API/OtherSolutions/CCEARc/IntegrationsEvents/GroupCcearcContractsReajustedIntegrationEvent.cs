namespace API.OtherSolutions.CCEARc.IntegrationsEvents
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
