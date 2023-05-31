using Microsoft.EntityFrameworkCore;
using ParkingLot.Data;
using ParkingLot.Models;
using ParkingLot.ViewModels;

namespace ParkingLot.Services
{
    public class SpotServices : ISpotServices
    {
        private readonly ApplicationDbContext _context;

        public SpotServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Spot> Get(int id)
            => await _context.Spots.FindAsync(id);


        public  List<SpotViewModel> GetAll()
        {
            List<SpotViewModel> spots = _context.Spots
                .Join(_context.Areas,
                    spot => spot.AreaId,
                    area => area.Id,
                    (spot, area) => new { Spot = spot, Area = area })
                .Join(_context.VehicleTypes,
                    combined => combined.Spot.TypeId,
                    type => type.Id,
                    (combined, type) => new SpotViewModel
                    {
                        Id = combined.Spot.Id,
                        PlatNumber = combined.Spot.PlatNumber,
                        Area = combined.Area.Name,
                        Type = type.Name
                    })
                .ToList();
            return spots;
        }

        public async Task<Spot> Add(Spot spot)
        {
            _context.Spots.Add(spot);
            _context.SaveChanges();
            return spot;
        }

        public Spot Delete(Spot spot)
        {
            _context.Spots.Remove(spot);
            _context.SaveChanges();
            return spot;
        }



        public Spot Update(Spot spot)
        {
            _context.Spots.Update(spot);
            _context.SaveChanges();
            return spot;
        }

    }
}
