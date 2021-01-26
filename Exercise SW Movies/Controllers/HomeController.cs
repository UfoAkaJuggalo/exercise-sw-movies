using System.Diagnostics;

using Exercise_SW_Movies.Models;
using Exercise_SW_Movies.Services.Interfaces;
using Exercise_SW_Movies.View_Models;

using Microsoft.AspNetCore.Mvc;

namespace Exercise_SW_Movies.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMoviesService _moviesService;

        public HomeController(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        public IActionResult Index()
        {
            var model = new MovieList();

            model.Movies = _moviesService.GetMoviesList();

            return View(model);
        }

        public IActionResult MovieDetails(int id)
        {
            var model = _moviesService.GetMovieDetails(id);

            return PartialView(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
