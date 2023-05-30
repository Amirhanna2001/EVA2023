using ParkingLot.Models;
using System.ComponentModel;

namespace ParkingLot.ViewModels
{
    public class AddSpotViewModel
    {
        [DisplayName("Plate Number")]
        public string  PlateNumber { get; set; }
        public List<Area> Areas { get; set; }
        [DisplayName("Area Name")]

        public int AreaId { get; set; }
        public List<VehicleType> Types { get; set; }
        [DisplayName("Vhicle Type")]

        public int TypeId { get; set; }
    }
}
