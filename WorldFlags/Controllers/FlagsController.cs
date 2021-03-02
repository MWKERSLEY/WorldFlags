using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldFlags.Models;
using WorldFlags.Services;

namespace WorldFlags.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FlagsController : ControllerBase
    {
        public FlagsController(JsonFileFlagService flagService)
        {
            this.FlagService = flagService;
        }

        public JsonFileFlagService FlagService { get; }

        [HttpGet]
        public World Get()
        {
            return FlagService.GetCountries();
        }
    }
}
