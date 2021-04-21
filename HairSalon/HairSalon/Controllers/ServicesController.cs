using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using HairSalon.Services;
using HairSalon.Common.Extensions;

namespace HairSalon.Controllers
{
    public class ServicesController : Controller
    {
        private ServiceService Service { get; }

        public ServicesController(ServiceService service)
        {
            Service = service;
        }

        // GET: Service
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var lst = await Service.List<ServiceModel.Base>();
            return View(lst);
        }

        // GET: Service/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await Service.ById<ServiceModel.Base>(id);
            return View(model);
        }

        // GET: Service/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Service/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceModel.Base model)
        {
            if (ModelState.IsValid)
            {
                await Service.Add<ServiceModel.Base>(model);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: Service/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await Service.ById<ServiceModel.Base>(id);
            return View(model);
        }

        // POST: Service/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ServiceModel.Base model)
        {
            if (ModelState.IsValid)
            {
                await Service.Edit<ServiceModel.Base>(model);

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: Service/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await Service.ById<ServiceModel.Base>(id);

            return View(model);
        }

        // POST: Service/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await Service.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ServiceExists(int id)
        {
            var model = await Service.ById<ServiceModel.Base>(id);
            return model.IsNotNull();
        }
    }
}
