using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WorldFlags.Models;
using WorldFlags.Services;

namespace WorldFlags.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public JsonFileFlagService FlagService;
        public IEnumerable<Country> Countries { get; private set; }

        public IndexModel(ILogger<IndexModel> logger, JsonFileFlagService flagService)
        {
            _logger = logger;
            FlagService = flagService;
        }

        public void OnGet()
        {
            World world = FlagService.GetCountries();
            Countries = world.Countries;
            if (world.Date != DateTime.Now.Date)
            {
                //Debug.WriteLine("test");
                FlagService.UpdateData();
            }
        }
    }
}
