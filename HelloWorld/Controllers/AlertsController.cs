//using System;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using HelloWorld.Data;
//using HelloWorld.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.Extensions.DependencyInjection;

//namespace HelloWorld.Controllers
//{
//    public class AlertsController : Controller
//    {
//        private readonly HelloWorldContext _context;
//        private readonly IServiceScopeFactory _scopeFactory;

//        public AlertsController(HelloWorldContext context, IServiceScopeFactory scopeFactory)
//        {
//            _context = context;
//            _scopeFactory = scopeFactory;
//        }

//        // GET: Alerts
//        public async Task<IActionResult> Index()
//        {
//            return View(await _context.Alert.ToListAsync());
//        }

//        // GET: Alerts/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var alert = await _context.Alert
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (alert == null)
//            {
//                return NotFound();
//            }

//            return View(alert);
//        }

//        // GET: Alerts/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        const string AlertMessage = "_Message";
//        const string AlertLink = "_Link";
//        const string pDate = "_pdate";
//        const string eDate = "_edate";

//        // POST: Alerts/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Id,Message,PublishDate,ExpDate,Link")] Alert alert)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(alert);
//                await _context.SaveChangesAsync();

//                HttpContext.Session.SetString(AlertMessage, alert.Message);
//                HttpContext.Session.SetString(AlertLink, alert.Link);
//                HttpContext.Session.SetString(pDate, alert.PublishDate.ToString());
//                HttpContext.Session.SetString(eDate, alert.ExpDate.ToString());

//                return RedirectToAction(nameof(Index));
//            }
//            return View(alert);
//        }

//        // GET: Alerts/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var alert = await _context.Alert.FindAsync(id);
//            if (alert == null)
//            {
//                return NotFound();
//            }
//            return View(alert);
//        }

//        // POST: Alerts/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("Id,Message,PublishDate,ExpDate,Link")] Alert alert)
//        {
//            if (id != alert.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(alert);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!AlertExists(alert.Id))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(alert);
//        }

//        // GET: Alerts/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var alert = await _context.Alert
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (alert == null)
//            {
//                return NotFound();
//            }

//            return View(alert);
//        }

//        // POST: Alerts/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var alert = await _context.Alert.FindAsync(id);
//            if (alert != null)
//            {
//                _context.Alert.Remove(alert);
//            }

//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool AlertExists(int id)
//        {
//            return _context.Alert.Any(e => e.Id == id);
//        }

//        [HttpPost]
//        public async Task<IActionResult> ClearSession()
//        {
//            using (var scope = _scopeFactory.CreateScope())
//            {
//                var context = scope.ServiceProvider.GetRequiredService<HelloWorldContext>();
//                var activeAlert = context.Alert.FirstOrDefault(a => a.IsActive);
//                if (activeAlert != null)
//                {
//                    activeAlert.IsActive = false;
//                    context.Alert.Update(activeAlert);
//                    await context.SaveChangesAsync();
//                }
//            }
//            return Ok();
//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HelloWorld.Data;
using HelloWorld.Models;
using Microsoft.AspNetCore.Session;

namespace HelloWorld.Controllers
{
    public class AlertsController : Controller
    {
        private readonly HelloWorldContext _context;

        public AlertsController(HelloWorldContext context)
        {
            _context = context;
        }

        // GET: Alerts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Alert.ToListAsync());
        }

        // GET: Alerts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alert = await _context.Alert
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alert == null)
            {
                return NotFound();
            }

            return View(alert);
        }

        // GET: Alerts/Create
        public IActionResult Create()
        {
            return View();
        }

        const string AlertMessage = "_Message";
        const string AlertLink = "_Link";
        const string pDate = "_pdate";
        const string eDate = "_edate";

        // POST: Alerts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Message,PublishDate,ExpDate,Link")] Alert alert)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alert);
                await _context.SaveChangesAsync();

                //TempData["message"] = alert.Message;
                //TempData["link"] = alert.Link;
                HttpContext.Session.SetString(AlertMessage, alert.Message);
                HttpContext.Session.SetString(AlertLink, alert.Link);
                HttpContext.Session.SetString(pDate, alert.PublishDate.ToString());
                HttpContext.Session.SetString(eDate, alert.ExpDate.ToString());


                return RedirectToAction(nameof(Index));
            }
            return View(alert);
        }

        public string Alert()
        {
            string? AMessage = HttpContext.Session.GetString(AlertMessage);
            string? ALink = HttpContext.Session.GetString(AlertLink);
            string? PDatestring = HttpContext.Session.GetString(pDate);
            string? EDatestring = HttpContext.Session.GetString(eDate);

            DateTime pdate = DateTime.Parse(PDatestring);
            DateTime edate = DateTime.Parse(EDatestring);

            string Content = $"Message: {AMessage}, Link: {ALink}, pdate: {pdate}, edate: {edate}";
            return Content;
        }

        [HttpPost]
        public IActionResult ClearSession()
        {
            HttpContext.Session.Clear();
            return Ok();
        }

        // GET: Alerts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alert = await _context.Alert.FindAsync(id);
            if (alert == null)
            {
                return NotFound();
            }
            return View(alert);
        }

        // POST: Alerts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Message,PublishDate,ExpDate,Link")] Alert alert)
        {
            if (id != alert.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alert);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlertExists(alert.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(alert);
        }

        // GET: Alerts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alert = await _context.Alert
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alert == null)
            {
                return NotFound();
            }

            return View(alert);
        }

        // POST: Alerts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alert = await _context.Alert.FindAsync(id);
            if (alert != null)
            {
                _context.Alert.Remove(alert);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlertExists(int id)
        {
            return _context.Alert.Any(e => e.Id == id);
        }
    }
}
