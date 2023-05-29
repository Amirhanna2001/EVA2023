using Microsoft.EntityFrameworkCore;
using ParkingLot.Data;
using ParkingLot.Models;

namespace ParkingLot.Services
{
    public class VehicleServices : GeneralTypeServices<VehicleType>
    {
        private readonly ApplicationDbContext _context;

        public VehicleServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<VehicleType> Get(int id)
            =>await _context.VehicleTypes.FindAsync(id);


        public async Task<List<VehicleType>> GetAll()
            => await _context.VehicleTypes.ToListAsync();

        public async Task<VehicleType> Add(VehicleType type)
        {
            _context.VehicleTypes.Add(type);
            _context.SaveChanges();
            return type;
        }

        public VehicleType Delete(VehicleType type)
        {
            _context.VehicleTypes.Remove(type);
            _context.SaveChanges();
            return type;
        }

       

        public VehicleType Update(VehicleType type)
        {
            _context.VehicleTypes.Update(type);
            _context.SaveChanges ();
            return type;
        }
    }
}
