using ParkingLot.Models;
using ParkingLot.ViewModels;

namespace ParkingLot.Services
{
    public interface ISpotServices
    {
        List<SpotViewModel> GetAll();
        Task<Spot> Add(Spot entity);
        Task<Spot> Get(int id);
        Spot Update(Spot entity);
        Spot Delete(Spot entity);
    }

}
