using CourierServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourierServices.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public List<History> history;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            history = new List<History>();
        }

        public void OnPost()
        {
            string packageId = Request.Form["numPackage"];
            int searchId;
            if (!string.IsNullOrWhiteSpace(packageId))
            {
                searchId = int.Parse(packageId);

                CourierServicesContext db = new CourierServicesContext();
                history = db.History.Where(x => x.ShipmentId == searchId).ToList();
            }
        }
    }
}
