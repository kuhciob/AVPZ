using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AVPZ.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using AVPZ.Services;

namespace AVPZ.Controllers
{
    //[ApiController]
    public class RiskController : Controller
    {
        private readonly ILogger<RiskController> _logger;
        private SRS _srs;//= new SRS();

        public RiskController(ILogger<RiskController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            _srs = SRSSingletone.getInstance().SRS;
            return View(_srs);
        }

        [HttpPost]
        public IActionResult Index( SRS srs)
        {
            SRSSingletone.getInstance().SRS.Trs = srs.Trs;
            SRSSingletone.getInstance().SRS.Prs = srs.Prs;
            SRSSingletone.getInstance().SRS.Mrs = srs.Mrs;
            SRSSingletone.getInstance().SRS.Crs = srs.Crs;
            

            return View(srs);
        }
        [HttpGet]
        public IActionResult Index2()
        {
            _srs = SRSSingletone.getInstance().SRS;
            return View(_srs);
        }

        [HttpPost]
        public IActionResult Index2(SRS srs)
        {
            SRSSingletone.getInstance().SRS.Tr = srs.Tr;
            SRSSingletone.getInstance().SRS.Pr = srs.Pr;
            SRSSingletone.getInstance().SRS.Mr = srs.Mr;
            SRSSingletone.getInstance().SRS.Cr = srs.Cr;

            return View(srs);
        }
        public IActionResult RiskAnalysis()
        {
            _srs = SRSSingletone.getInstance().SRS;
            return View(_srs);
        }
        [HttpPost]
        public IActionResult RiskAnalysis(SRS srs)
        {
            SRSSingletone.getInstance().SRS.AllRiskPer = srs.AllRiskPer;
            SRSSingletone.getInstance().SRS.LRERp = srs.LRERp;
            return View(srs);
        }
        
        public IActionResult RiskPlan()
        {
            _srs = SRSSingletone.getInstance().SRS;
            return View(_srs);
        }
        [HttpPost]
        public IActionResult RiskPlan(SRS srs)
        {
            SRSSingletone.getInstance().SRS.EVERp = srs.EVERp;
            return View(srs);
        }
        public IActionResult RiskMonitor()
        {
            _srs = SRSSingletone.getInstance().SRS;
            return View(_srs);
        }
        [HttpPost]
        public IActionResult RiskMonitor(SRS srs)
        {
            SRSSingletone.getInstance().SRS.AllRiskPer2 = srs.AllRiskPer2;
            SRSSingletone.getInstance().SRS.ELRERp = srs.ELRERp;

            return View(srs);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
