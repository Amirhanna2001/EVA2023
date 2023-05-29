using Microsoft.EntityFrameworkCore;
using ParkingLot.Data;
using ParkingLot.Models;

namespace ParkingLot.Services
{
    public class SpotServices : GeneralTypeServices<Spot>
    {
        private readonly ApplicationDbContext _context;

        public SpotServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Spot> Get(int id)
            => await _context.Spots.FindAsync(id);


        public async Task<List<Spot>> GetAll()
            => await _context.Spots.ToListAsync();

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
