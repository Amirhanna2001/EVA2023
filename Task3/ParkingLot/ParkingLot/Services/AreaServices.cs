using Microsoft.EntityFrameworkCore;
using ParkingLot.Data;
using ParkingLot.Models;

namespace ParkingLot.Services
{
    public class AreaServices : GeneralTypeServices<Area>
    {
        private readonly ApplicationDbContext _context;

        public AreaServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Area> Get(int id)
            => await _context.Areas.FindAsync(id);

        public async Task<List<Area>> GetAll()
            => await _context.Areas.ToListAsync();public async Task<Area> Add(Area area)
        {
            await _context.Areas.AddAsync(area);
            _context.SaveChanges();
            return area;
        }
       
        public Area Delete(Area area)
        {
            _context.Areas.Remove(area);
            _context.SaveChanges();
            return area;
        }

        


        public Area Update(Area area)
        {
            _context.Areas.Update(area);
            _context.SaveChanges();
            return area;
        }

        
    }
}
