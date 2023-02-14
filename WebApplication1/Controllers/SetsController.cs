using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class SetsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Sets()
        {
            return View();
        }
        [Authorize]
        public IActionResult SetBeige()
        {
            return View();
        }
        [Authorize]
        public IActionResult SetGray()
        {
            return View();
        }
        [Authorize]
        public IActionResult SetOrange()
        {
            return View();
        }
        [Authorize]
        public IActionResult SetPink()
        {
            return View();
        }
        [Authorize]
        public IActionResult SetPurple()
        {
            return View();
        }
        [Authorize]
        public IActionResult SetSea()
        {
            return View();
        }
    }
}
