using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ministry.BlogPage.EfCore;
using Ministry.BlogPage.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ministry.BlogPage.Controllers
{
    public class MainController : Controller
    {
        private readonly AppDbContext context;

        public MainController(AppDbContext context)
        {
            this.context = context;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetMainPage()
        {
            var action = RouteData.Values["action"].ToString();
            var data = context.News.OrderByDescending(i=>i.CreatedDate).Take(6).ToList();
            return View(data);
        }

        [HttpGet("{lang}/MEDA/Haqqimizda")]
        public async Task<IActionResult> GetAboutPage()
        {
            return View();
        }

        [HttpGet("{lang}/MEDA/FeliyyetSahesi")]
        public async Task<IActionResult> GetWorkDirections()
        {
            return View();
        }

        [HttpGet("{lang}/MEDA/Layihelerimiz")]
        public async Task<IActionResult> GetProjects()
        {
            return View();
        }

        [HttpGet("{lang}/MEDA/Media/Xeberler")]
        public async Task<IActionResult> GetMediasNews()
        {
            var data = context.News.ToList();
            return View(data);
        }

        [HttpGet("{lang}/MEDA/Media/Bloglar")]
        public async Task<IActionResult> GetMediaBlogs()
        {
            var data = context.Announcements.ToList();
            return View(data);
        }

        [HttpGet("{lang}/MEDA/Qanunvericilik")]
        public async Task<IActionResult> GetRules()
        {
            var data = await context.RuleFiles.ToListAsync();
            return View(data);
        }

        [HttpGet("{lang}/MEDA/Elage")]
        public async Task<IActionResult> GetContacts()
        {
            return View();
        }

        [HttpGet("{lang}/MEDA/Xeberler/{slug}/{id}")]
        public async Task<IActionResult> GetBlogBySlug(string slug,int id)
        {
            var data = await context.News.FirstOrDefaultAsync(i => i.Slug.ToLower() == slug.ToLower() && i.Id==id);
            ViewBag.LastestPosts = context.News.OrderByDescending(i => i.CreatedDate).Take(4).ToList();
            return View(data);
        }

        [HttpGet("{lang}/Meda/Medialar/{slug}/{id}")]
        public async Task<IActionResult> GetAnnouncementBySlug(string slug,int id)
        {
            var data = await context.Announcements.FirstOrDefaultAsync(i => i.Slug.ToLower() == slug.ToLower() && i.Id==id);
            ViewBag.LastestPosts = context.Announcements.OrderByDescending(i => i.CreatedDate).Take(4).ToList();
            return View(data);
        }
        [HttpGet("{lang}/MEDA/Haqqimizda/Agentlik-Haqqinda")]
        public IActionResult GetAboutAgency()
        {
            return View();
        }
        [HttpGet("{lang}/MEDA/Haqqimizda/Rehberlik")]
        public IActionResult GetBosses()
        {
            return View();
        }

        [HttpGet("{lang}/MEDA/Haqqimizda/Struktur")]
        public IActionResult GetStructure()
        {
            return View();
        }
        [HttpGet("{lang}/MEDA/Haqqimizda/emekdashliqlar")]
        public IActionResult GetCollobration()
        {
            return View();
        }

        [HttpGet("{lang}/MEDA/FealiyyetSaheleri/Geoloji-Kesfiyyat")]
        public IActionResult GetGeolojiSurvey()
        {
            return View();
        }

        [HttpGet("{lang}/MEDA/FealiyyetSaheleri/yer-tekinden-istifade")]
        public IActionResult GetUseFromEarth()
        {
            return View();
        }
        [HttpGet("{lang}/MEDA/FealiyyetSaheleri/Monitorinq")]
        public IActionResult GetMonitoring()
        {
            return View();
        }
        [HttpGet("{lang}/MEDA/FealiyyetSaheleri/Herraclar")]
        public IActionResult GetAuction()
        {
            return View();
        }
    }

    public class LinkModel
    {
        public string Title { get; set; }
        public string Link { get; set; }
    }
}
