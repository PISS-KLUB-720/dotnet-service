using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Text;
using TennisServe.Database;
using TennisServe.Web.Models;
using static System.Net.Mime.MediaTypeNames;

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
        public async Task<IActionResult> Predict(PointViewModel viewModel)
        {
            var newRequestedServe = new PredictedServe
            {
                Names = viewModel.Names,
                Points = viewModel.Points,
                Sets = viewModel.Sets,
                Side = viewModel.Side,
                Games = viewModel.Games,
            };
  
            var servePositionPrediction = await GetServicePredict(newRequestedServe);

            newRequestedServe.Position = servePositionPrediction;

            context.PredictedServes.Add(newRequestedServe);
            context.SaveChanges();

            return View();
        }

        private async Task<string> GetServicePredict(PredictedServe newRequestedServe)
        {
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(newRequestedServe);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("http://localhost:5002/player", httpContent);
            var responseBody = await response.Content.ReadAsStringAsync();

            var predictedServe = JsonConvert.DeserializeObject<PredictResponseModel>(responseBody);

            return predictedServe.ServePosition;
        }
    }
}
