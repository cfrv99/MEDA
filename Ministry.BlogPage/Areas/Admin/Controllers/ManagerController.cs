using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ministry.BlogPage.EfCore;
using Ministry.BlogPage.Entities;
using Ministry.BlogPage.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Ministry.BlogPage.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class ManagerController : Controller
    {
        private readonly AppDbContext context;

        public ManagerController(AppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetNewsPage()
        {
            var data = context.News.ToList();
            return View(data);
        }

        public async Task<IActionResult> AddNews()
        {
            return View(new News());
        }
        [HttpPost]
        public async Task<IActionResult> AddNews(string editordata,string title,IFormFile file,string shortDesc)
        {
            if (shortDesc.Length < 101)
            {
                ViewBag.Error = "Simvol sayi en az 100 olmalidir";
                return View();
            }
            var news = new News
            {
                Title = title,
                Description = editordata,
                Slug = FriendlyUrlHelper.GetFriendlyTitle(title),
                ShortDescription = shortDesc,
                CreatedDate = DateTime.Now
            };
            if (file == null)
            {
                return View();
            }
            var fileName = Guid.NewGuid().ToString() + "" + file.FileName;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", fileName);

            using (var fs = new FileStream(path,FileMode.OpenOrCreate))
            {
                await file.CopyToAsync(fs);
            }
            news.MainImageUrl = fileName;

            await context.News.AddAsync(news);
            await context.SaveChangesAsync();
            return RedirectToAction("GetNewsPage","Manager");
        }

        [HttpGet]
        public async Task<IActionResult> EditNews(int id)
        {
            var data = await context.News.FirstOrDefaultAsync(i => i.Id == id);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> EditNews(string editordata, string title, IFormFile file, string shortDesc,int id)
        {
            var data = await context.News.FirstOrDefaultAsync(i => i.Id == id);
            if (shortDesc.Length < 100)
            {
                ViewBag.Error = "Simvol sayi en az 100 olmalidir";
                return View();
            }
            data.Title = title;
            data.Description = editordata;
            data.ShortDescription = shortDesc;
            if (file != null)
            {
                var fileName = Guid.NewGuid().ToString() + "" + file.FileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", fileName);

                using (var fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    await file.CopyToAsync(fs);
                }
                data.MainImageUrl = fileName;
            }
            

            await context.SaveChangesAsync();
            return RedirectToAction("GetNewsPage", "Manager");
        }
        public async Task<string> UploadImageFromEditor(IFormFile file)
        {
            var fileName = Guid.NewGuid().ToString() + "" + file.FileName;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", fileName);
            var hostUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                await file.CopyToAsync(fs);
                return $"{hostUrl}/img/{fileName}";
            }
        }

        public async Task<IActionResult> DeleteNewsFromBase(int id)
        {
            var data = context.News.FirstOrDefault(i=>i.Id==id);
            context.News.Remove(data);
            await context.SaveChangesAsync();
            return RedirectToAction("GetNewsPage");
        }

        public IActionResult GetAnnouncements()
        {
            var data = context.Announcements.ToList();
            return View(data);
        }

        public IActionResult AddAnnouncement()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAnnouncement(string editordata, string title, IFormFile file)
        {
            var announcement = new Announcement
            {
                Title = title,
                Description = editordata,
                Slug = FriendlyUrlHelper.GetFriendlyTitle(title),
                CreatedDate = DateTime.Now
            };
            if (file == null)
            {
                return View();
            }
            var fileName = Guid.NewGuid().ToString() + "" + file.FileName;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", fileName);

            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                await file.CopyToAsync(fs);
            }
            announcement.MainUrl = fileName;

            await context.Announcements.AddAsync(announcement);
            await context.SaveChangesAsync();
            return RedirectToAction("GetAnnouncements", "Manager");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteAnnouncement(int id)
        {
            var data = context.Announcements.FirstOrDefault(i => i.Id == id);
            context.Announcements.Remove(data);
            await context.SaveChangesAsync();
            return RedirectToAction("GetAnnouncements");
        }

        public IActionResult GetProjects()
        {
            var data = context.Projects.ToList();
            return View(data);
        }

        public IActionResult GetRules()
        {
            var data = context.RuleFiles.ToList();
            return View(data);
        }

        [HttpGet]
        public IActionResult AddRules()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddRules(string link,int type,string title)
        {
            var rule = new RuleFiles
            {
                Type = (RuleType)type,
                Link = link,
                Title = title
            };
            context.RuleFiles.Add(rule);
            context.SaveChanges();
            return Redirect("/Admin/Manager/GetRules");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteRule(int id)
        {
            var data = context.RuleFiles.FirstOrDefault(i => i.Id == id);
            context.RuleFiles.Remove(data);
            await context.SaveChangesAsync();
            return RedirectToAction("GetRules");
        }

    }

}
