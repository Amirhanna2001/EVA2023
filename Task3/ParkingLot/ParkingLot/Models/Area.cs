using System.ComponentModel.DataAnnotations;

namespace ParkingLot.Models
{
    public class Area
    {
        public int Id { get; set; }
        [Range(0, 1000)]
        public int AvailableSpots { get; set; }

        public string Name { get; set; }
    }
}
