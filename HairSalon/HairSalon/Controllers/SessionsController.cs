using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using HairSalon.Services;
using HairSalon.Common.Extensions;

namespace HairSalon.Controllers
{
    public class SessionsController : Controller
    {
        private SessionService Service { get; }

        public SessionsController(SessionService service)
        {
            Service = service;
        }

        // GET: Sessions
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var lst = await Service.List<SessionModel>();
            return View(lst);
        }

        // GET: Sessions/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await Service.ById<SessionModel>(id);
            return View(model);
        }

        // GET: Sessions/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sessions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SessionModel model)
        {
            if (ModelState.IsValid)
            {
                await Service.Add<SessionModel>(model);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: Sessions/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await Service.ById<SessionModel>(id);
            return View(model);
        }

        // POST: Sessions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SessionModel model)
        {
            if (ModelState.IsValid)
            {
                await Service.Edit<SessionModel>(model);

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: Sessions/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await Service.ById<SessionModel>(id);

            return View(model);
        }

        // POST: Sessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await Service.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> SessionExists(int id)
        {
            var model = await Service.ById<SessionModel>(id);
            return model.IsNotNull();
        }
    }
}
