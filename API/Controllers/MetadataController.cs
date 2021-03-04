using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MetadataController : ControllerBase
    {
        // GET: api/<MovieController>
        [HttpGet]
        public List<Movie> Get()
        {
            List<Movie> l = new List<Movie>();
            l.Add(new Movie
            {
                duration = "1:49:00",
                language = "EN",
                movieId = 3,
                releaseYear = 2013,
                title = "Elysium"
            });
            return l;
        }

        // GET <MovieController>/5
        [Route("Get/id")]
        [HttpGet("{id}")]
        public List<Movie> Get(int id)
        {
            UtilsController utils = new UtilsController();
            List<Movie> lists = utils.ReadMetadataCVS().Where(i => i.movieId == id).OrderBy(n => n.language).ToList();

            return lists;
        }


        // POST api/<MovieController>
        [Route("Post")]
        [HttpPost]
        public void Post([FromBody] Movie value)
        {
            UtilsController utils = new UtilsController();
            utils.WriteMovieCSV(value);

        }
    }
}
