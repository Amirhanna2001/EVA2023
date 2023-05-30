using System.ComponentModel.DataAnnotations;

namespace ParkingLot.ViewModels
{
    public class AreaViewModel
    {
        public string Name { get; set; }
        [Range(1, 1000)]
        public int AvailableSpots { get; set; }

    }
}
