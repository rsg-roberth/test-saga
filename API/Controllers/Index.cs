using API.OtherSolutions.Finance.Integrations.Events;
using Microsoft.AspNetCore.Mvc;
using Rebus.Bus;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Index : ControllerBase
    {                        
        private readonly IBus _bus;

        public Index(IBus bus)
        {            
            _bus = bus;
        }

        [HttpPost("update")]
        public IActionResult Post()
        {
            _bus.Publish(new FinanceIndexUpdatedIntegrationEvent());
            return Ok();
        }
    }
}