using Microsoft.AspNetCore.Mvc;
using ParkingLot.Models;
using ParkingLot.Services;
using ParkingLot.ViewModels;

namespace ParkingLot.Controllers
{
    public class TypeController : Controller
    {
        private readonly GeneralTypeServices<VehicleType> _vehicleServices;

        public TypeController(GeneralTypeServices<VehicleType> vehicleServices)
        {
            _vehicleServices = vehicleServices;
        }

        public async Task< IActionResult> Index() =>View( await _vehicleServices.GetAll());
        public IActionResult Add() => View();
        [HttpPost]
        public async Task<IActionResult> Add(TypeViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            VehicleType type = new()
            {
                Name = viewModel.Name
            };
            await _vehicleServices.Add(type);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            VehicleType area = await _vehicleServices.Get(id);
            if (area == null)
                return View("NotFound");


            return View(area);

        }
        [HttpPost]
        public IActionResult Update(VehicleType type)
        {
            if (type == null)
                return View("NotFound");


            _vehicleServices.Update(type);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            VehicleType type = await _vehicleServices.Get(id);
            if (type == null)
                return View("NotFound");

            _vehicleServices.Delete(type);

            return RedirectToAction(nameof(Index));
        }

    }
}
