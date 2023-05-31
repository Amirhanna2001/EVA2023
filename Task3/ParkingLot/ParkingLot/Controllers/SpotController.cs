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
        private readonly ISpotServices _spotServices;
        private readonly GeneralTypeServices<VehicleType> _typeServices;
        private readonly GeneralTypeServices<Area> _areaServices;
        private readonly ApplicationDbContext _context;

        public SpotController(ISpotServices spotServices,
            GeneralTypeServices<VehicleType> typeServices, GeneralTypeServices<Area> areaServices)
        {
            _spotServices = spotServices;
            _typeServices = typeServices;
            _areaServices = areaServices;
        }
        public async Task<IActionResult> Index()
            => View( _spotServices.GetAll());
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

            Spot spot = await _context.Spots.FirstAsync(s => s.PlatNumber == viewModel.PlateNumber);
            if (spot != null)
            {
                ModelState.AddModelError("PlateNumber", "This Vhicle Aready Exsits");
                return View(viewModel);
            }
            Area area = await _areaServices.Get(viewModel.AreaId);
            if (area == null)
            {
                ModelState.AddModelError("AreaId", "This Area Not Found");
                return View(viewModel);
            }

            VehicleType type = await _typeServices.Get(viewModel.TypeId);
            if (type == null)
            {
                ModelState.AddModelError("TypeId", "This Type Not Found");
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
    
       

        public async Task<IActionResult> Delete(int id)
        {
           Spot spot = await _spotServices.Get(id);
            if (spot == null)
                return View("NotFound");

            _spotServices.Delete(spot);

            return RedirectToAction(nameof(Index));
        }
    }
}
