using API.OtherSolutions.Finance.IntegrationsEvents;
using Microsoft.AspNetCore.Mvc;
using Rebus.Bus;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReajustmentIndexController : ControllerBase
    {                        
        private readonly IBus _bus;

        public ReajustmentIndexController(IBus bus)
        {            
            _bus = bus;
        }

        [HttpPost]
        public IActionResult Post()
        {
            _bus.Publish(new FinancialIndexValuesChangedIntegrationEvent());

            //var a = new List<string>() { "a", "b", "c" };
            //var b = new List<string>() { "a", "b", "c" };

            //var c = a.Except(b).ToList();

            return Ok();
        }
    }
}