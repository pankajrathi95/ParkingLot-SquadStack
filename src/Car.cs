namespace ParkingLot_SquadStack
{
    public class Car
    {
        string vehicleNumber;
        int ageOfDriver;

        public Car(string vehicleNumber, int ageOfDriver)
        {
            this.vehicleNumber = vehicleNumber;
            this.ageOfDriver = ageOfDriver;
        }

        public string GetVehicleNumber()
        {
            return vehicleNumber;
        }

        public int GetAgeOfDriver()
        {
            return ageOfDriver;
        }
    }
}