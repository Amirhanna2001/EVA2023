using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingLot.Data;
using ParkingLot.Models;
using ParkingLot.Services;
using ParkingLot.ViewModels;

namespace ParkingLot.Controllers
{
    public class SpotController : Controller
    {
        private readonly GeneralTypeServices<Spot> _spotServices;
        private readonly GeneralTypeServices<VehicleType> _typeServices;
        private readonly GeneralTypeServices<Area> _areaServices;
        private readonly ApplicationDbContext _context;

        public SpotController(GeneralTypeServices<Spot> spotServices, ApplicationDbContext context,
            GeneralTypeServices<VehicleType> typeServices, GeneralTypeServices<Area> areaServices)
        {
            _spotServices = spotServices;
            _context = context;
            _typeServices = typeServices;
            _areaServices = areaServices;
        }
        public async Task< IActionResult> Index()
        {
           
            List<SpotViewModel> spotViewModels = _context.Spots
                 .Join(_context.Areas,
                     spot => spot.AreaId,
                     area => area.Id,
                     (spot, area) => new { Spot = spot, Area = area })
                 .Join(_context.VehicleTypes,
                     combined => combined.Spot.TypeId,
                     type => type.Id,
                     (combined, type) => new SpotViewModel
                     {
                         
                         Area = combined.Area.Name,
                         Type = type.Name
                     })
                 .ToList(); List<SpotViewModel> viewModel = new();

            return View(spotViewModels);
        }
        public IActionResult Add()
        {
            AddSpotViewModel viewModel = new()
            {
                Areas = _areaServices.GetAll().Result,
                Types = _typeServices.GetAll().Result,
            };
            return View(viewModel);
        }
            

        [HttpPost]
        public async Task<IActionResult> Add(AddSpotViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            Spot spot =await _context.Spots.FirstAsync(s => s.PlatNumber == viewModel.PlateNumber);
            if(spot != null)
            {
                ModelState.AddModelError("PlateNumber", "This Vhicle Aready Exsits");
                return View(viewModel);
            }
            Spot spotToInsert = new()
            {
                PlatNumber = viewModel.PlateNumber,
                AreaId = viewModel.AreaId,
                TypeId = viewModel.TypeId,
            };

            await _spotServices.Add(spotToInsert);
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
            if (area == null)
                return View("NotFound");
            if (!ModelState.IsValid)
                return View(area);

            _areaServices.Update(area);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            Area area = await _areaServices.Get(id);
            if (area == null)
                return View("NotFound");

            _areaServices.Delete(area);

            return RedirectToAction(nameof(Index));
        }
    }
}
