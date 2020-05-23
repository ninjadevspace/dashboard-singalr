using InteractiveDashboard.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace InteractiveDashboard.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IHubContext<DashboardHub> _hubContext;

        public UsuarioController(IHubContext<DashboardHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string nome)
        {
            await _hubContext.Clients.All.SendAsync("CadastroUsuarioEvent", new
            {
                NomeUsuario = nome
            });

            return View();
        }
    }
}
