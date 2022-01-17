using Expeditions.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expeditions.Controllers
{
    public class StatsController : Controller
    {
        private readonly ExpeditionsContext _context;
        public StatsController(ExpeditionsContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var result = _context.Expeditions.Count();
            var result2 = _context.Peaks.Count();
            var result3 = _context.Peaks.Where(x => x.Height >= 8000).Count();
            var result4 = Math.Round((_context.Expeditions.Count(x => x.OxygenUsed) /(double)_context.Expeditions.Count() * 100),1);
            var result5 = Math.Round((_context.Expeditions.Count(x => x.TerminationReason == "Accident (death or serious injury)") / (double)_context.Expeditions.Count() * 100),1); ;
            

            //var result5 = _context.Expeditions.Where(x => x.OxygenUsed == true).Count();

            ViewData["result"] = result;
            ViewData["resultPeaks"] = result2;
            ViewData["resultPeaksOver"] = result3;
            ViewData["resultOxygen"] = result4;
            ViewData["resultDeath"] = result5;

            return View();
        }
    }
}
