using Microsoft.AspNetCore.Mvc;
using ParkingLot.Models;
using ParkingLot.Services;
using ParkingLot.ViewModels;

namespace ParkingLot.Controllers
{
    public class AreaController : Controller
    {
        private readonly GeneralTypeServices<Area> _areaServices;

        public AreaController(GeneralTypeServices<Area> areaServices)
        {
            _areaServices = areaServices;
        }
        public async Task< IActionResult> Index()
            => View(await _areaServices.GetAll());

       
        public IActionResult Add() => View();
        [HttpPost]
        public async Task<IActionResult>Add(AreaViewModel viewModel)
        {
            if(!ModelState.IsValid)
                return View(viewModel);

            Area area = new()
            {
                Name = viewModel.Name,
                AvailableSpots = viewModel.AvailableSpots,
            };
            await _areaServices.Add(area);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            
            Area area = await _areaServices.Get(id);
            if (area == null)
                return View("NotFound");


            return View(area);

        }
        [HttpPost]
        public IActionResult Update(Area area)
        {
            if(area == null)
                return View("NotFound");
            if (!ModelState.IsValid)
                return View(area);

            _areaServices.Update(area);
            return RedirectToAction(nameof(Index));
        }
        
        public async Task< IActionResult> Delete(int id)
        { 
            Area area =await _areaServices.Get(id);
            if(area == null)
                return View("NotFound");

             _areaServices.Delete(area);

            return RedirectToAction(nameof(Index));
        }

    }
}
