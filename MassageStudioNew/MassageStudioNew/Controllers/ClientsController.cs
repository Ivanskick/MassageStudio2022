using MassageStudioApp.Abstractions;
using MassageStudioApp.Entities;
using MassageStudioApp.Models.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MassageStudioApp.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientService _clientService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ClientsController(IClientService clientService, UserManager<ApplicationUser> userManager)
        {
            _clientService = clientService;
            _userManager = userManager;
        }

        // GET: ClientsController
        public async Task<ActionResult> Index()
        {
            var users = (await this._userManager.GetUsersInRoleAsync("Client"))
                  .Select(u => new ClientListingVM
                  {
                      Id = _clientService.GetClientByUserId(u.Id).Id,
                      FirstName = _clientService.GetClientByUserId(u.Id).FirstName,
                      LastName = _clientService.GetClientByUserId(u.Id).LastName,
                      Email = u.Email,
                      Phone = _clientService.GetClientByUserId(u.Id).Phone,
                      BirthDate = _clientService.GetClientByUserId(u.Id).BirthDate
                  }).ToList();

            return this.View(users);
        }

        // GET: ClientsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClientsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateClientVM client)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userIdAlreadyClient = this._clientService
                .GetClients()
                .Any(d => d.UserId == userId);

            if (!ModelState.IsValid)
            {
                return View(client);
            }
            var created = _clientService.CreateClient(client.FirstName, client.LastName, client.Phone, client.BirthDate, userId);


            if (created)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }

        }

        // GET: ClientsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClientsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClientsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
