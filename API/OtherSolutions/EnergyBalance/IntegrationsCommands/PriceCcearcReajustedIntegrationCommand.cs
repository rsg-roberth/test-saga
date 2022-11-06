﻿namespace API.OtherSolutions.EnergyBalance.IntegrationsCommands
{
    public class PriceCcearcReajustedIntegrationCommand
    {
        public PriceCcearcReajustedIntegrationCommand(string sagaId, string contractId)
        {
            SagaId = sagaId;
            ContractId = contractId;
        }

        public string SagaId { get; private set; }
        public string ContractId { get; private set; }
    }
}
