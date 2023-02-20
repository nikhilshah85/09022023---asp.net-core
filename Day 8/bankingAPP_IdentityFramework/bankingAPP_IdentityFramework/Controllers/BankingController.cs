using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bankingAPP_IdentityFramework.Controllers
{
    [Authorize]
    public class BankingController : Controller
    {

        [AllowAnonymous]
        public IActionResult BankingHome()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult TypeOfAccounts()
        {
            return View();
        }
        public IActionResult DownloadStatement()
        {
            return View();
        }
        public IActionResult TransferFunds()
        {
            return View();
        }

    }
}
