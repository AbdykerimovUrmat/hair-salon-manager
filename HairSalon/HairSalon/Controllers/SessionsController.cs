using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using HairSalon.Services;
using HairSalon.Common.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HairSalon.Controllers
{
    public class SessionsController : Controller
    {
        private SessionService Service { get; }

        private ServiceService ServiceService { get; }

        public SessionsController(SessionService service, ServiceService serviceService)
        {
            Service = service;
            ServiceService = serviceService;
        }

        // GET: Sessions
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var lst = await Service.List<SessionModel.Base>();
            return View(lst);
        }

        // GET: Sessions/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await Service.ById<SessionModel.Base>(id);
            return View(model);
        }

        // GET: Sessions/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View(await GenerateModel());
        }

        // POST: Sessions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SessionModel.Base model)
        {
            if (ModelState.IsValid)
            {
                await Service.Add<SessionModel.Base>(model, model.ServiceId);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: Sessions/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await Service.ById<SessionModel.Create>(id);
            return View(model);
        }

        // POST: Sessions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SessionModel.Base model)
        {
            if (ModelState.IsValid)
            {
                await Service.Edit<SessionModel.Base>(model);

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: Sessions/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await Service.ById<SessionModel.Base>(id);

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
            var model = await Service.ById<SessionModel.Base>(id);
            return model.IsNotNull();
        }

        private async Task<SessionModel.Create> GenerateModel()
        {
            var lst = await ServiceService.List<ServiceModel.Base>();
            var model = new SessionModel.Create
            {
                SelectListServiceItems = lst.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                })
            };
            return model;
        }
    }
}
