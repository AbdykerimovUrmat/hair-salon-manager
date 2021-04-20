using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HairSalon.Data;
using HairSalon.Data.Entities;
using MapsterMapper;
using Mapster;
using HairSalon.Models;
using HairSalon.Services;
using HairSalon.Common.Extensions;

namespace HairSalon.Controllers
{
    public class ClientsController : Controller
    {
        private ClientService Service { get; }

        public ClientsController(ClientService service)
        {
            Service = service;
        }

        // GET: Clients
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var lst = await Service.List<ClientModel.Base>();
            return View(lst);
        }

        // GET: Clients/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await Service.ById<ClientModel.Base>(id);
            return View(model);
        }

        // GET: Clients/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClientModel.Base model)
        {
            if (ModelState.IsValid)
            {
                await Service.Add<ClientModel.Base>(model);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: Clients/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await Service.ById<ClientModel.Base>(id);
            return View(model);
        }

        // POST: Clients/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ClientModel.Base model)
        {
            if (ModelState.IsValid)
            {
                await Service.Edit<ClientModel.Base>(model);
                
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: Clients/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await Service.ById<ClientModel.Base>(id);

            return View(model);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await Service.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ClientExists(int id)
        {
            var model = await Service.ById<ClientModel.Base>(id);
            return model.IsNotNull();
        }
    }
}
