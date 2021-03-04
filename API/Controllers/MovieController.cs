using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        [Route("Stats")]
        [HttpGet]
        public List<StatsMovie> Stats()
        {
            UtilsController utils = new UtilsController();
            List<StatsMovie> lists = utils.statsMoviesList();

            return lists;
        }
    }

}
