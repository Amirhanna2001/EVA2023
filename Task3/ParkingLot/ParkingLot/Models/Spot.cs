namespace ParkingLot.Models
{
    public class Spot
    {
        public int Id { get; set; }
        public string PlatNumber { get; set; }
        public int AreaId { get; set; }
        public Area Area { get; set; }

        public int TypeId { get; set; }
        public VehicleType VehicleType { get; set; }
    }
}
