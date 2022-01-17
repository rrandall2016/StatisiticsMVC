using Expeditions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore;

namespace Expeditions.Controllers
{
    public class HomeController : Controller
    {
        private readonly ExpeditionsContext _context;
        public HomeController(ExpeditionsContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            //var records = _context.Peaks.OrderByDescending(x=>x.Height).Take(15).ToList();

            var results = _context.Peaks.Include(a => a.Expeditions).OrderByDescending(a => a.Height).ToList();




            return View(results);
        }


    }
}
