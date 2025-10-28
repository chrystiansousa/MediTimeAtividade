using MediTime.Application.Interfaces; // <-- ADICIONE ESTE USING
using MediTime.Application.ViewModels; // <-- ADICIONE ESTE USING
using MediTime.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MediTime.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMedicamentoService _medicamentoService; // <-- ADICIONE ESTA LINHA

        // --- MUDE O CONSTRUTOR ---
        // De: public HomeController(ILogger<HomeController> logger)
        // Para:
        public HomeController(ILogger<HomeController> logger, IMedicamentoService medicamentoService)
        {
            _logger = logger;
            _medicamentoService = medicamentoService; // <-- ADICIONE ESTA LINHA
        }

        // --- MUDE A AÇÃO INDEX ---
        // De: public IActionResult Index()
        // Para:
        public async Task<IActionResult> Index()
        {
            // Busca a lista de medicamentos
            var model = await _medicamentoService.GetAllAsync();
            
            // Envia a lista para a View
            return View(model);
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
    }
}