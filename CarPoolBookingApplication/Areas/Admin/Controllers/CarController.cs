using CarPoolBooking.Models.ViewModels;
using CarPoolTicket.DataAccess.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPoolBookingApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CarController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult GetAllCar()
        {
            var car = _unitOfWork.CarRepository.GetAll();
            return Json(new { data = car });
        }

        public IActionResult CreateUpdate(int? id)
        {
            CarVm vm = new CarVm();

            if (id == null || id == 0)
            {
                return View(vm);
            }
            else
            {
                vm.Car = _unitOfWork.CarRepository.GetFirstOrDefault(x => x.Id == id);
                if (vm.Car == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(vm);
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUpdate(CarVm vm)
        {
            if (ModelState.IsValid)
            {
                if (vm.Car.Id == 0)
                {
                    _unitOfWork.CarRepository.Insert(vm.Car);
                    TempData["success"] = "Car Created Done!";
                }
                else
                {
                    _unitOfWork.CarRepository.Update(vm.Car);
                    TempData["success"] = "Car Update Done!";
                }

                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var Car = _unitOfWork.CarRepository.GetFirstOrDefault(x => x.Id == id);
            if (Car == null)
            {
                return Json(new { success = false, message = "Error in fetching data" });
            }
            else
            {
                _unitOfWork.CarRepository.Delete(Car);
                _unitOfWork.Save();
                return Json(new { success = true, message = "Car Deleted" });
            }
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
