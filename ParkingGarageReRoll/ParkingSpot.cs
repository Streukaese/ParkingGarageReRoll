using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarageReRoll
{
    public class ParkingSpot
    {
        public int ParkingSpotId { get; set; }
        public int FloorId { get; set; }
        public int AutoId { get; set; }
        public int ParkingPosition { get; set; }
        public ParkingSpot(int parkingSpotId, int floorId, int autoId, int parkingPosition)
        {
            ParkingSpotId = parkingSpotId;
            FloorId = floorId;
            AutoId = autoId;
            ParkingPosition = parkingPosition;
        }
    }
}
