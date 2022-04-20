using MassageStudioApp.Abstractions;
using MassageStudioApp.Entities;
using MassageStudioApp.Models.Category;
using MassageStudioApp.Models.Reservation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MassageStudioApp.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly IReservationService _reservationService;
        
        private readonly ICategoryService _categoryService;
        private readonly IHourService _hourService;

        public ReservationsController(IReservationService reservationService, ICategoryService categoryService, IHourService hourService)
        {
            _reservationService = reservationService;
            _categoryService = categoryService;
            _hourService = hourService;
        }


        // GET: ReservationsController
        public ActionResult Index()
        {
            List<AllReservationsVM> reservations = _reservationService.GetReservations()
               .Select(item => new AllReservationsVM()
               {
                   Id = item.Id,
                   CategoryName = item.Category.Name,
                   HourStart = item.Hour.FreeHour,
                   ClientFullName = item.Client.FirstName + " " + item.Client.LastName,
                   EmployeeFullName = item.Hour.Employee.FirstName + " " + item.Hour.Employee.LastName,
               }).ToList();
            return View(reservations);
        }

        // GET: ReservationsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReservationsController/Create
        [Authorize(Roles="Client")]
        public ActionResult Create(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Hour item = _hourService.GetHourById(id);
            if (item == null)
            {
                return NotFound();
            }

            var reservation = new AddReservationVM();
            reservation.Categories = _categoryService.GetCategories()
                .Select(c => new CategoryPairVM()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();

            reservation.HourId = item.Id;

            return View(reservation);
        }

        // POST: ReservationsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Client")]
        public ActionResult Create(int id, AddReservationVM model)
        {
            if (!this.ModelState.IsValid)
            {
                return NotFound();
            }

            string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var created = _reservationService.CreateReservation(id, currentUserId, model.CategoryId);
            if (created)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        // GET: ReservationsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReservationsController/Edit/5
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

        // GET: ReservationsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReservationsController/Delete/5
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

        public ActionResult My()
        {
            string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<AllReservationsVM> reservations = this._reservationService.GetReservations()
                .Where(o => o.Client.UserId == currentUserId)
                .Select(item => new AllReservationsVM()
                {
                    Id = item.Id,
                    CategoryName = item.Category.Name,
                    HourStart = item.Hour.FreeHour,
                    ClientFullName = item.Client.FirstName + " " + item.Client.LastName,
                    EmployeeFullName = item.Hour.Employee.FirstName + " " + item.Hour.Employee.LastName,
                }).ToList();
            return View(reservations);
        }
    }
}
