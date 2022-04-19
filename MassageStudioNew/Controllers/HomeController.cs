using MassageStudioApp.Abstractions;
using MassageStudioApp.Models;
using MassageStudioApp.Models.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;

namespace MassageStudioApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeService _employeeService;
        private readonly IClientService _clientService;
        private readonly IReservationService _reservationService;
        private readonly IHourService _hourService;

        public HomeController(ILogger<HomeController> logger,
            IEmployeeService employeeService, IClientService clientService,
            IHourService hourService, IReservationService reservationService)
        {
            _logger = logger;
            _employeeService = employeeService;
            _clientService = clientService;
            _hourService = hourService;
            //_massageService = massageService;
            _reservationService = reservationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Statistic()
        {
            StatisticVM statistic = new StatisticVM();

            statistic.countEmployees = _employeeService.GetEmployees().Count;
            statistic.countClients = _clientService.GetClients().Count();
            //statistic.countHours = _massageService.GetMassages().Count();
            statistic.countHours = _hourService.GetHours().Count();
            return View(statistic);
        }
    }
}
