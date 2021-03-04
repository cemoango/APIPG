using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using API.Models;

namespace API.Controllers
{
    public class UtilsController : Controller
    {
        public string urlmetadata = "Data/metadata.csv";
        public string urlstats = "Data/stats.csv";

        public IActionResult Index()
        {
            ReadMetadataCVS();
            return View();
        }

        public List<Movie> ReadMetadataCVS()
        {

            List<Movie> metadata = new List<Movie>();

            try
            {
                using (var readFile = new StreamReader(urlmetadata))
                {
                    string line;
                    string[] parts;
                    int i = 0;
                    while ((line = readFile.ReadLine()) != null)
                    {
                        if (i > 0)
                        {
                            parts = line.Split(',');
                            metadata.Add(new Movie()
                            {
                                id = int.Parse(parts[0]),
                                duration = parts[4],
                                language = parts[3],
                                movieId = int.Parse(parts[1]),
                                releaseYear = int.Parse(parts[5]),
                                title = parts[2]
                            });
                        }
                        i++;
                    }

                }
            }
            catch (Exception ex)
            {

            }
            return metadata;
        }
        public List<Stats> ReadStatsCVS()
        {
            List<Stats> metadata = new List<Stats>();

            try
            {
                using (var readFile = new StreamReader(urlmetadata))
                {
                    string line;
                    string[] parts;
                    int i = 0;
                    while ((line = readFile.ReadLine()) != null)
                    {
                        if (i > 0)
                        {
                            parts = line.Split(',');
                            metadata.Add(new Stats
                            {
                                watchDurationMs = int.Parse(parts[1]),
                                movieId = int.Parse(parts[0])
                            });
                        }
                        i++;

                    }
                }
            }
            catch (Exception ex)
            {

            }
            return metadata;
        }
        public void WriteMovieCSV(Movie m)
        {
            using (TextWriter textWriter = new StreamWriter(urlmetadata, true))
            {
                textWriter.WriteLine("{0},{1},{2},{3},{4},{5}", ReadMetadataCVS().Count + 1, m.movieId, m.title, m.language, m.duration, m.releaseYear);
            }

        }
        public List<StatsMovie> statsMoviesList()
        {
            List<StatsMovie> lstStatsMovie = new List<StatsMovie>();

            List<Movie> lstMovie = ReadMetadataCVS();
            List<Stats> lstStats = ReadStatsCVS();

            lstMovie.ForEach(i => {
                if (lstStats.Exists(a => a.movieId == i.movieId) && !lstStatsMovie.Exists(a => a.movieId == i.movieId))
                {
                    List<int> t = new List<int>();
                    double v = lstStats.Average(a => a.watchDurationMs);
                    lstStatsMovie.Add(new StatsMovie
                    {
                        movieId = i.movieId,
                        releaseYear = i.releaseYear,
                        title = i.title,
                        watchDurationMs = v
                    });
                }
            });
            return lstStatsMovie;
        }

    }
}
