using InspimoDesignPattern.ChainOfResponsibility;
using InspimoDesignPattern.Models;
using Microsoft.AspNetCore.Mvc;

namespace InspimoDesignPattern.Controllers
{
    public class DefaultControllercs : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CustomerProcessViewModel model)
        {
            Employee cashier = new Cashier();
            Employee assistantManager = new AssistantManager();
            Employee regionManager = new RegionManager();
            Employee manager = new Manager();

            cashier.SetNextApprover(assistantManager);
            assistantManager.SetNextApprover(manager);
            manager.SetNextApprover(regionManager);

            cashier.ProcessRequest(model);
            return View();
        }
    }
}
