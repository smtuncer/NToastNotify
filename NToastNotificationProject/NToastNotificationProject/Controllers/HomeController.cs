using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NToastNotificationProject.Models;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NToastNotificationProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IToastNotification _toast;

        public HomeController(ILogger<HomeController> logger, IToastNotification toast)
        {
            _logger = logger;
            _toast = toast;
        }

        public IActionResult Index(string p)
        {
            if (!String.IsNullOrEmpty(p))
            {
                if (p == "ErrorNotify")
                {
                    _toast.AddErrorToastMessage("Hata Bildirimi");
                }
                else if (p == "WarningNotify")
                {
                    _toast.AddWarningToastMessage("Uyarı Bildirimi");
                }
                else if (p == "SuccessNotify")
                {
                    _toast.AddSuccessToastMessage("Başarılı Bildirimi");
                }
                else if (p == "InfoNotify")
                {
                    _toast.AddInfoToastMessage("Bilgilendirme Bildirimi");
                }
                else
                {
                    return View();
                }
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
