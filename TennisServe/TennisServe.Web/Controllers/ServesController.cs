using Microsoft.AspNetCore.Mvc;
using TennisServe.Database;
using TennisServe.Web.Models;

namespace TennisServe.Web.Controllers
{
    public class ServesController : Controller
    {
        private TennisDbContext context;
        public ServesController(TennisDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Predict()
        {
            var allServes = context.PredictedServes.ToList();
            return View();
        }

        [HttpPost]
        [Route("")]
        public IActionResult Predict(PointViewModel viewModel)
        {
            var newRequestedServe = new PredictedServe
            {
                Names = viewModel.Names,
                Points = viewModel.Points,
                Sets = viewModel.Sets,
                Side = viewModel.Side,
                Games = viewModel.Games,
            };

            //api call
            var result = "l";

            newRequestedServe.Position = result;

            context.PredictedServes.Add(newRequestedServe);
            context.SaveChanges();

            return View();
        }
    }
}
