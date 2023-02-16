using Microsoft.AspNetCore.Mvc;

namespace LitFibre.Interviews.SoftwareEngineer.Controllers
{
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }
    }
}
